using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace TVSeriesCompanion.Models
{
    public class Serial
    {
        private int id;
        private String name;
        private String banner;
        private String overview;
        private DateTime firstAired;
        private String network;
        private String imdbId;
        private String zap2itId;
        private String[] actors;
        private String airsDayOfWeek;
        private String airsTime;
        private String contentRating;
        private String[] genre;
        private double rating;
        private int runtime;
        private String status;
        private String poster;
        private List<Season> seasons;

        public Serial() { }

        public Serial(XmlNode serial)
        {
            foreach (XmlNode data in serial.ChildNodes)
                switch (data.Name)
                {
                    case "id":              setId(data.InnerText); break;
                    case "SeriesName":      setName(data.InnerText); break;
                    case "banner":          setBanner(@"http://thetvdb.com/banners/" + data.InnerText); break;
                    case "Overview":        setOverview(data.InnerText); break;
                    case "FirstAired":      setFirstAired(data.InnerText); break;
                    case "Network":         setNetwork(data.InnerText); break;
                    case "IMDB_ID":         setImdbId(data.InnerText); break;
                    case "zap2it_id":       setZap2itId(data.InnerText); break;
                    case "Actors":          setActors(data.InnerText.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)); break;
                    case "Airs_DayOfWeek":  setAirsDayOfWeek(data.InnerText); break;
                    case "Airs_Time":       setAirsTime(data.InnerText); break;
                    case "ContentRating":   setContentRating(data.InnerText); break;
                    case "Genre":           setGenre(data.InnerText.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries)); break;
                    case "Rating":          setRating(data.InnerText == "" ? 0.0 : double.Parse(data.InnerText, CultureInfo.InvariantCulture)); break;
                    case "Runtime":         setRuntime(Int16.Parse(data.InnerText)); break;
                    case "Status":          setStatus(data.InnerText); break;
                    case "poster":          setPoster((data.InnerText == ""? "" : @"http://thetvdb.com/banners/") + data.InnerText); break;
                }
        }
        public Serial(SQLiteDataReader r)
        {
            setId(r.GetInt32(0));
            setName(r.GetString(1));
            setBanner(r.GetString(2));
            setOverview(r.GetString(3));
            setFirstAired(r.GetString(4));
            setNetwork(r.GetString(5));
            setImdbId(r.GetString(6));
            setZap2itId(r.GetString(7));
            setActors(r.GetString(8).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
            setAirsDayOfWeek(r.GetString(9));
            setAirsTime(r.GetString(10));
            setContentRating(r.GetString(11));
            setGenre(r.GetString(12).Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries));
            setRating(r.GetDouble(13));
            setRuntime(r.GetInt16(14));
            setStatus(r.GetString(15));
            setPoster(r.GetString(16));
        }
        public string ToQuery()
        {
            return id + ", '" +  (name != null ? name.Replace("'", "''") : "") +
                        "', '" + (banner ?? "") +
                        "', '" + (overview != null ? overview.Replace("'", "''") : "") +
                        "', '" + (firstAired.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)) +
                        "', '" + (network ?? "") +
                        "', '" + (imdbId ?? "") +
                        "', '" + (zap2itId ?? "") +
                        "', '" + (actors != null ? String.Join("|", actors.Select(n => n.Replace("'", "''"))) : "") +
                        "', '" + (airsDayOfWeek ?? "") +
                        "', '" + (airsTime ?? "") +
                        "', '" + (contentRating ?? "") +
                        "', '" + (genre != null ? String.Join("|", genre.Select(n => n.Replace("'", "''"))) : "") +
                        "', " +  rating.ToString("0.0", CultureInfo.InvariantCulture)+
                        ", " +   runtime +
                        ", '" +  (status ?? "") +
                        "', '" + (poster ?? "''") + "'";
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public void setId(String id)
        {
            this.id = Int32.Parse(id);
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getBanner()
        {
            return banner;
        }

        public void setBanner(String banner)
        {
            this.banner = banner;
        }

        public String getOverview()
        {
            return overview;
        }

        public void setOverview(String overview)
        {
            this.overview = overview;
        }

        public DateTime getFirstAired()
        {
            return firstAired;
        }

        public void setFirstAired(DateTime firstAired)
        {
            this.firstAired = firstAired;
        }

        public void setFirstAired(String firstAired)
        {
            this.firstAired = firstAired=="" ? DateTime.MinValue : DateTime.ParseExact(firstAired, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public String getNetwork()
        {
            return network;
        }

        public void setNetwork(String network)
        {
            this.network = network;
        }

        public String getImdbId()
        {
            return imdbId;
        }

        public void setImdbId(String imdbId)
        {
            this.imdbId = imdbId;
        }

        public String getZap2itId()
        {
            return zap2itId;
        }

        public void setZap2itId(String zap2itId)
        {
            this.zap2itId = zap2itId;
        }
        public String[] getActors()
        {
            return actors;
        }

        public void setActors(String[] actors)
        {
            this.actors = actors;
        }

        public String getAirsDayOfWeek()
        {
            return airsDayOfWeek;
        }

        public void setAirsDayOfWeek(String airsDayOfWeek)
        {
            this.airsDayOfWeek = airsDayOfWeek;
        }

        public String getAirsTime()
        {
            return airsTime;
        }

        public void setAirsTime(String airsTime)
        {
            this.airsTime = airsTime;
        }

        public String getContentRating()
        {
            return contentRating;
        }

        public void setContentRating(String contentRating)
        {
            this.contentRating = contentRating;
        }

        public String[] getGenre()
        {
            return genre;
        }

        public void setGenre(String[] genre)
        {
            this.genre = genre;
        }

        public double getRating()
        {
            return rating;
        }

        public void setRating(double rating)
        {
            this.rating = rating;
        }

        public int getRuntime()
        {
            return runtime;
        }

        public void setRuntime(int runtime)
        {
            this.runtime = runtime;
        }

        public String getStatus()
        {
            return status;
        }

        public void setStatus(String status)
        {
            this.status = status;
        }

        public String getPoster()
        {
            return poster;
        }

        public void setPoster(String poster)
        {
            this.poster = poster;
        }

        public List<Season> getSeasons()
        {
            return seasons;
        }

        public void setSeasons(List<Season> seasons)
        {
            this.seasons = seasons;
        }
    }
}