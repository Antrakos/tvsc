﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json.Linq;
using TrayNotification;
using TVSeriesCompanion.Aspects;
using TVSeriesCompanion.Models;

namespace TVSeriesCompanion.Controllers
{
    class SeriesManager
    {
        private static Settings settings = new Settings("settings.json");
        public static SQLiteConnection conn = createConnection("Data Source=MyDatabase.sqlite;Version=3;");
        public static SQLiteTransaction transaction;
        private static SQLiteConnection createConnection(String path)
        {
            SQLiteConnection con = new SQLiteConnection(path);
			con.Open();
            using (SQLiteCommand command = con.CreateCommand())
            {
                try
                {
                    command.CommandText = @"CREATE TABLE TVSeries (
	                                        id integer PRIMARY KEY,
	                                        name string,
	                                        banner string,
	                                        overview text,
	                                        firstAired date,
	                                        network string,
	                                        imdbId string,
	                                        zap2itId string,
	                                        actors string,
	                                        airsDayOfWeek string,
	                                        airsTime string,
	                                        contentRating string,
	                                        genre string,
	                                        rating float,
	                                        runtime integer,
	                                        status string,
	                                        poster string);";
                    command.ExecuteNonQuery();
                }
                catch (SQLiteException) { }
                try
                {
                    command.CommandText = @"CREATE TABLE Seasons (
	                                        id integer PRIMARY KEY AUTOINCREMENT,
	                                        number integer,
	                                        serial integer,
                                            banner string,
                                            FOREIGN KEY(serial) REFERENCES TVSeries(id));";
                    command.ExecuteNonQuery();
                }
                catch (SQLiteException) { }
                try
                {
                    command.CommandText = @"CREATE TABLE Episodes (
	                                        id integer PRIMARY KEY AUTOINCREMENT,
	                                        name string,
	                                        number integer,
	                                        firstAired date,
	                                        overview text,
	                                        rating float,
	                                        imdbId string,
	                                        image string,
	                                        watched boolean,
	                                        season integer,
                                            FOREIGN KEY(season) REFERENCES Seasons(id));";
                    command.ExecuteNonQuery();
                }
                catch (SQLiteException) { }
            }
			con.Close();
            return con;
        }
        public static Settings getSettings() { return settings; }
        public static void setSettings(Settings s) { settings = s; }
        public static List<Serial> findByName(String name)
        {
            XmlDocument doc = DownloadXML(@"http://thetvdb.com/api/GetSeries.php?seriesname=" + String.Join("%20", name.Split(' ')));
            return (from XmlNode serial in doc.DocumentElement.ChildNodes select new Serial(serial)).ToList();
        }
        public static Serial findById(String id)
        {
            XmlNode episodes = DownloadXML(@"http://thetvdb.com/api/CC1D364E3115133D/series/" + id + @"/all").DocumentElement;
            Serial serial = new Serial(episodes.ChildNodes[0]);
            HashSet<string> seasonsNumbers = new HashSet<string>();
            foreach (XmlNode ep in episodes.SelectNodes("//Data//Episode"))
                seasonsNumbers.Add(ep["SeasonNumber"].InnerText);
            var banners = getSeasonBanner(serial, seasonsNumbers);
            List<Season> seasons = seasonsNumbers.Select(number => new Season(episodes.SelectNodes("//Data//Episode[SeasonNumber=" + number + "]"), banners[number])).ToList();
            foreach (Season season in seasons)
                season.setSerial(serial);
            foreach (Season season in seasons)
            {
                foreach (Episode episode in season.getEpisodes())
                {
                    episode.setSerial(serial);
                    episode.setSeason(season);
                }
                season.setSerial(serial);
            }
            serial.setSeasons(seasons);  
            return serial;
        }
        [SqlConnectionAspect]
        public static void saveSerial(Serial serial)
        {
            using (SQLiteCommand command = getTransactionCommand())
            {
                command.Transaction = transaction;
                command.CommandText = "SELECT id FROM TVSeries WHERE id=" + serial.getId();
                if (command.ExecuteScalar() != null)
                    return;
            }
            using (SQLiteCommand command = getTransactionCommand())
            {
                command.CommandText = "Insert into TVSeries Values (" + serial.ToQuery() + ")";
                command.ExecuteNonQuery();
                foreach (Season s in serial.getSeasons())
                {
                    command.CommandText = "Insert into Seasons (number, serial, banner) Values (" + s.getNumber() + "," + serial.getId() + ",'" + s.getBanner() + "')";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT id FROM Seasons WHERE number=" + s.getNumber() + " and serial=" + serial.getId();
                    string seasonId = command.ExecuteScalar().ToString();
                    command.CommandText = s.getEpisodes().Aggregate("", (current, e) => current + ("Insert into Episodes Values (" + e.ToQuery() + ", " + seasonId + "); "));
                    command.ExecuteNonQuery();
                }
            }
        }
        [SqlConnectionAspect]
        public static void updateSerial(Serial serial)
        {
            Serial newSerial = findById(serial.getId().ToString());
            if (serial.ToQuery() != newSerial.ToQuery())
                using (SQLiteCommand command = getTransactionCommand())
                {
                    command.CommandText = "DELETE FROM TVSeries WHERE id=" + serial.getId();
                    command.ExecuteNonQuery();
                    command.CommandText = "Insert into TVSeries Values (" + newSerial.ToQuery() + ")";
                    command.ExecuteNonQuery();
                }
            using (SQLiteCommand command = getTransactionCommand())
                foreach (Season s in newSerial.getSeasons())
                {
                    command.CommandText = "SELECT id FROM Seasons WHERE serial=" + serial.getId() + " AND number=" + s.getNumber();
                    if (command.ExecuteScalar() == null)
                    {
                        command.CommandText = "Insert into Seasons (number, serial, banner) Values (" + s.getNumber() + "," + serial.getId() + ",'" + s.getBanner() + "')";
                        command.ExecuteNonQuery();
                    }
                    command.CommandText = "SELECT id, firstAired FROM Episodes WHERE season=(SELECT id FROM Seasons WHERE serial=" + serial.getId() + " AND number=" + s.getNumber() + " )";
                    SQLiteDataReader episodesReader = command.ExecuteReader();
                    Dictionary<int, string> episodesIDs = new Dictionary<int, string>();
                    while (episodesReader.Read())
                        episodesIDs.Add(episodesReader.GetInt32(0), episodesReader.GetString(1));
                    episodesReader.Close();
                    if (episodesIDs.Count == s.getEpisodes().Count)
                        continue;
                    foreach (Episode e in s.getEpisodes())
                    {
                        bool contains = false;
                        foreach (var id in episodesIDs.Where(id => e.getId() == id.Key && DateTime.Now > DateTime.ParseExact(id.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture)))
                            contains = true;
                        if (contains) continue;
                        command.CommandText = "DELETE FROM Episodes WHERE id=" + e.getId();
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT id FROM Seasons WHERE number=" + s.getNumber() + " and serial=" + serial.getId();
                        String seasonId = command.ExecuteScalar().ToString();
                        command.CommandText = "Insert into Episodes Values (" + e.ToQuery() + ", " + seasonId + ")";
                        command.ExecuteNonQuery();
                    }
                }
        }
        [SqlConnectionAspect]
        public static Serial getSavedSerial(String id)
        {
            Serial serial;
            using (SQLiteCommand command = getTransactionCommand(),
                                 additionalCommand = getTransactionCommand())
            {
                command.CommandText = "SELECT * from TVSeries WHERE id="+id;
                SQLiteDataReader serialReader = command.ExecuteReader();
                serialReader.Read();
                serial = new Serial(serialReader);
                serialReader.Close();
                command.CommandText = "SELECT * from Seasons WHERE serial=" + id;
                SQLiteDataReader seasonsReader = command.ExecuteReader();
                List<Season> seasons = new List<Season>();
                
                while (seasonsReader.Read())
                {
                    additionalCommand.CommandText = "SELECT * from Episodes WHERE season=" + seasonsReader.GetInt16(0)+" ORDER BY number";
                    var episodesReader = additionalCommand.ExecuteReader();
                    var episodes = new List<Episode>();
                    while (episodesReader.Read())
                        episodes.Add(new Episode(episodesReader));
                    seasons.Add(new Season(seasonsReader.GetInt16(1), episodes, seasonsReader.GetString(3)));
                    episodesReader.Close();
                }
                seasonsReader.Close();
                serial.setSeasons(seasons);
                foreach (Season season in serial.getSeasons())
                {
                    foreach (Episode episode in season.getEpisodes())
                    {
                        episode.setSerial(serial);
                        episode.setSeason(season);
                    }
                    season.setSerial(serial);
                }
            }
            return serial;
        }
        [SqlConnectionAspect]
        public static List<Serial> getSavedTVSeries()
        {
            List<Serial> tvSeries = new List<Serial>();
            using (SQLiteCommand serialCommand = getTransactionCommand(),
                                 seasonCommand = getTransactionCommand(),
                                 episodeCommand = getTransactionCommand())
            {
                serialCommand.CommandText = "SELECT * FROM TVSeries";
                SQLiteDataReader serialReader = serialCommand.ExecuteReader();
                while (serialReader.Read())
                {
                    var serial = new Serial(serialReader);
                    seasonCommand.CommandText = "SELECT * from Seasons WHERE serial=" + serial.getId();
                    SQLiteDataReader seasonsReader = seasonCommand.ExecuteReader();
                    List<Season> seasons = new List<Season>();
                    while (seasonsReader.Read())
                    {
                        episodeCommand.CommandText = "SELECT * from Episodes WHERE season=" + seasonsReader.GetInt16(0) + " ORDER BY number";
                        var episodesReader = episodeCommand.ExecuteReader();
                        var episodes = new List<Episode>();
                        while (episodesReader.Read())
                            episodes.Add(new Episode(episodesReader));
                        seasons.Add(new Season(seasonsReader.GetInt16(1), episodes, seasonsReader.GetString(3)));
                        episodesReader.Close();
                    }
                    seasonsReader.Close();
                    serial.setSeasons(seasons);
                    foreach (Season season in serial.getSeasons())
                    {
                        foreach (Episode episode in season.getEpisodes())
                        {
                            episode.setSerial(serial);
                            episode.setSeason(season);
                            episode.setFirstAired(getFullDate(episode));
                        }
                        season.setSerial(serial);
                    }
                    tvSeries.Add(serial);
                }
                serialReader.Close();
            }
            return tvSeries;
        }
        public static List<Torrent> searchTorrent(String query)
        {
            String json;
            using (WebClient wc = new WebClient())
                json = wc.DownloadString("https://kat.cr/json.php?q=" + query + "&field=seeders&order=desc");
            return JObject.Parse(json)["list"].Select(item => new Torrent((string) item["title"], (DateTime) item["pubDate"], (string) item["torrentLink"], (int) item["peers"], (int) item["seeds"], (int) item["leechs"], Convert.ToDouble(((Int64) item["size"])/1048576))).ToList();
        }
        public static void downloadTorrent(Torrent torrent)
        {
            try
            {
                Directory.CreateDirectory(settings.TORRENT_DIR);
                DownloadFile(torrent.getLink(), settings.TORRENT_DIR + torrent.getLink().Split('=')[1] + ".torrent");
            }
            catch (WebException) { /*-----Can't dowload torrent-----*/}
        }
        private static void DownloadFile(string url, string file)
        {
            byte[] buffer = new byte[4096];

            WebRequest wr = WebRequest.Create(url);
            wr.ContentType = "application/x-bittorrent";
                using (WebResponse response = wr.GetResponse())
                {
                    var responseStream = response.Headers["Content-Encoding"] == "gzip"
                                            ? new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)
                                            : response.GetResponseStream();

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        int count;
                        do
                        {
                            count = responseStream.Read(buffer, 0, buffer.Length);
                            memoryStream.Write(buffer, 0, count);
                        } while (count != 0);
                        using (BinaryWriter writer = new BinaryWriter(new FileStream(file, FileMode.Create)))
                            writer.Write(memoryStream.ToArray());
                    }
                }
            if (settings.RUN_TORRENT_AFTER_DOWNLOAD)
                Process.Start(file);
        }
        [SqlConnectionAspect]
        public static void changeWatchStatus(Episode episode)
        {
            episode.setWatched(!episode.isWatched());
            using (SQLiteCommand command = getTransactionCommand())
            {
                command.CommandText = "UPDATE Episodes SET watched='" + episode.isWatched() + "' WHERE id=" + episode.getId();
                command.ExecuteNonQuery();
            }
        }
        [SqlConnectionAspect]
        public static void changeWatchStatusTo(Season season, bool watchStatus)
        {
            foreach (var episode in season.getEpisodes())
                if (episode.getFirstAired().Date <= DateTime.Now.Date && episode.getFirstAired().Date != new DateTime())
                    episode.setWatched(watchStatus);
            using (SQLiteCommand command = getTransactionCommand())
            {
                command.CommandText = "UPDATE Episodes SET watched='" + watchStatus + "' WHERE season=(SELECT season FROM Episodes WHERE id =" + season.getEpisodes()[0].getId() + ")  AND firstAired BETWEEN '0001-01-02' AND CURRENT_TIMESTAMP";
                command.ExecuteNonQuery();
            }
        }
        [SqlConnectionAspect]
        public static void deleteSerial(Serial serial)
        {
            using (SQLiteCommand command = getTransactionCommand())
            {
                foreach (Season season in serial.getSeasons())
                {
                    command.CommandText = "DELETE FROM Episodes WHERE season=(SELECT season FROM Episodes WHERE id =" + season.getEpisodes()[0].getId() + ")";
                    command.ExecuteNonQuery();
                }
                command.CommandText = "DELETE FROM Seasons WHERE serial=" + serial.getId();
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM TVSeries WHERE id=" + serial.getId();
                command.ExecuteNonQuery();
            }
        }

        public static Notification getNotification(Episode episode)
        {
            var coloring = new Coloring
            {
                BackColor = Color.Azure,
                Tile = Color.Transparent,
                Body = new SolidBrush(Color.BlueViolet)
            };
            var notifIcon = new NotifIcon
            {
                Image = (episode.getImage() == "" || !isOnline()) ? Image.FromFile(getSettings().IMAGE_NOT_FOUND) : Image.FromStream(new MemoryStream((new WebClient()).DownloadData(episode.getImage()))),
                Padding = 20
            };
            Notification notification = new Notification(Style.Fade, Direction.Up,500)
            {
                Title = episode.getSeason().getNumber() + "x" + episode.getNumber() + " - " + episode.getName(),
                Body = episode.getOverview(),
                Padding = 10,
                Icon = notifIcon,
                Color = coloring
            };
            return notification;
        }

        public static List<Episode> getEpisodesByDate(DateTime date)
        {
            return (from serial in getSavedTVSeries() from season in serial.getSeasons() from episode in season.getEpisodes() where episode.getFirstAired().Date == date.Date select episode).ToList();
        }

        public static Tuple<bool, Episode> nextToSeeEpisode(Serial serial)
        {
            Episode ep = null;
            foreach (Season season in serial.getSeasons())
                foreach (Episode episode in season.getEpisodes())
                    if (season.getNumber() != 0 && !episode.isWatched())
                        return new Tuple<bool, Episode>(true, episode);
                    else
                        ep = episode;
            return new Tuple<bool, Episode>(false, ep);
        }
        public static Episode nextEpisode(Serial serial)
        {
            return (from season in serial.getSeasons() from episode in season.getEpisodes() where season.getNumber() != 0 && episode.getFirstAired() > DateTime.Now select episode).FirstOrDefault();
        }

        [SqlConnectionAspect]
        public static List<Tuple<string,int>> getTVSeriesNames()
        {
            var res = new List<Tuple<string, int>>();
            using (SQLiteCommand command = getTransactionCommand())
            {
                command.CommandText = "SELECT * FROM TVSeries ORDER BY name";
                SQLiteDataReader r = command.ExecuteReader();
                while (r.Read())
                    res.Add(new Tuple<string, int>(r.GetString(1), r.GetInt32(0)));
            }
            return res;
        }
        public static Dictionary<string, string> getSeasonBanner(Serial serial, HashSet<String> seasonsNumbers)
        {
            Dictionary<string, string> banners = seasonsNumbers.ToDictionary(h => h, h => (string)null);
            XmlNode xml = DownloadXML(@"http://thetvdb.com/api/CC1D364E3115133D/series/" + serial.getId() + @"/banners.xml").DocumentElement;
            foreach (XmlNode banner in xml.ChildNodes.Cast<XmlNode>().Where(banner => banner["BannerType2"].InnerText == "season" && banner["Language"].InnerText == "en" && banners.ContainsKey(banner["Season"].InnerText)))
                banners[banner["Season"].InnerText] = @"http://thetvdb.com/banners/" + banner["BannerPath"].InnerText;
            return banners;
        }
        private static DateTime getFullDate(Episode episode)
        {
            string time = episode.getSerial().getAirsTime();
            DateTime t = episode.getFirstAired();
            if (time == "") return t;
            try
            {
                string timeFormat = "";
                if (new Regex(@"\d[APap]").Match(time).Success)
                    time = time.Insert(new Regex(@"\d[APap]").Match(time).Index + 1, " ");
                if (new Regex(@"\d{2,2}:\d{1,1}\s?[APap][mM]").Match(time).Success)
                    timeFormat = "HH:mm tt";
                else if (new Regex(@"\d{2,2}:\d{1,1}\s?[APap][mM]").Match(time).Success)
                    timeFormat = "HH:m tt";
                else if (new Regex(@"\d{1,1}:\d{2,2}\s?[APap][mM]").Match(time).Success)
                    timeFormat = "h:mm tt";
                else if (new Regex(@"\d{1,1}:\d{1,1}\s?[APap][mM]").Match(time).Success)
                    timeFormat = "h:m tt";
                else if (new Regex(@"\d{2,2}:\d{1,1}").Match(time).Success)
                    timeFormat = "HH:mm";
                else if (new Regex(@"\d{2,2}:\d{1,1}").Match(time).Success)
                    timeFormat = "HH:m";
                else if (new Regex(@"\d{1,1}:\d{2,2}").Match(time).Success)
                    timeFormat = "h:mm";
                else if (new Regex(@"\d{1,1}:\d{1,1}").Match(time).Success)
                    timeFormat = "h:m";
                else if (new Regex(@"\d{2,2}\s?[APap][mM]").Match(time).Success)
                    timeFormat = "HH tt";
                else if (new Regex(@"\d{1,1}\s?[APap][mM]").Match(time).Success)
                    timeFormat = "h tt";
                else if (new Regex(@"\d{2,2}").Match(time).Success)
                    timeFormat = "HH";
                else if (new Regex(@"\d{1,1}").Match(time).Success)
                    timeFormat = "h";
                var addTime = DateTime.ParseExact(time, timeFormat, CultureInfo.InvariantCulture);
                return t.AddHours(addTime.Hour).AddMinutes(addTime.Minute);
            }
            catch(FormatException) { return t; }
        }
        private static XmlDocument DownloadXML(string address)
        {
            XmlDocument doc = new XmlDocument();
            string text;
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                text = client.DownloadString(address);
            }
            doc.LoadXml(text);
            return doc;
        }
        public static bool isOnline()
        {
            try
            {
                using (var client = new WebClient())
                    using (client.OpenRead("http://www.google.com"))
                        return true;
            }
            catch { return false; }
        }

        private static SQLiteCommand getTransactionCommand()
        {
            var command = conn.CreateCommand();
            command.Transaction = transaction;
            return command;
        }
    }
}