using System;
using System.Data.SQLite;
using System.Globalization;
using System.Xml;

namespace TVSeriesCompanion.Models
{
    public class Episode
    {
        private int id;
        private String name;
        private int number;
        private DateTime firstAired;
        private String overview;
        private double rating;
        private String imdbId;
        private String image;
        private bool watched;
        private Season season;
        private Serial serial;

        public Episode() { }
        public Episode(XmlNode episode)
        {
            foreach (XmlNode data in episode.ChildNodes)
                switch (data.Name)
                {
                    case "id": setId(data.InnerText); break;
                    case "EpisodeName": setName(data.InnerText); break;
                    case "EpisodeNumber": setNumber(data.InnerText); break;
                    case "FirstAired": setFirstAired(data.InnerText); break;
                    case "Overview": setOverview(data.InnerText); break;
                    case "Rating": setRating(data.InnerText == "" ? 0.0 : double.Parse(data.InnerText, CultureInfo.InvariantCulture)); break;
                    case "IMDB_ID": setImdbId(data.InnerText); break;
                    case "filename": setImage(data.InnerText == "" ? "" : @"http://thetvdb.com/banners/" + data.InnerText); break;
                }
            setWatched(false);
        }
        public Episode(SQLiteDataReader r)
        {
            setId(r.GetInt32(0));
            setName(r.GetValue(1).ToString());
            setNumber(r.GetInt16(2));
            setFirstAired(r.GetString(3));
            setOverview(r.GetString(4));
            setRating(r.GetDouble(5));
            setImdbId(r.GetString(6));
            setImage(r.GetString(7));
            setWatched(bool.Parse(r.GetString(8)));
        }
        public string ToQuery()
        {
            return id + ", '" + (name != null ? name.Replace("'", "''") : "") +
                        "', " + number +
                        ", '" + (firstAired.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)) +
                        "', '" + (overview != null ? overview.Replace("'", "''") : "") +
                        "', " + rating.ToString("0.0", CultureInfo.InvariantCulture) +
                        ", '" + (imdbId ?? "") +
                        "', '" + (image ?? "") +
                        "', '" + watched + "'";
        }
        public int getId() { return id; }
        public void setId(int id) { this.id = id; }
        public String getName() { return name; }
        public void setName(String name) { this.name = name; }
        public int getNumber() { return number; }
        public void setNumber(int number) { this.number = number; }
        public DateTime getFirstAired() { return firstAired; }
        public void setFirstAired(DateTime firstAired) { this.firstAired = firstAired; }
        public String getOverview() { return overview; }
        public void setOverview(String overview) { this.overview = overview; }
        public double getRating() { return rating; }
        public void setRating(double rating) { this.rating = rating; }
        public String getImdbId() { return imdbId; }
        public void setImdbId(String imdbId) { this.imdbId = imdbId; }
        public String getImage() { return image; }
        public void setImage(String image) { this.image = image; }
        public bool isWatched() { return watched; }
        public void setWatched(bool watched) { this.watched = watched; }
        public Season getSeason() { return season; }
        public void setSeason(Season season) { this.season = season; }
        public Serial getSerial() { return serial; }
        public void setSerial(Serial serial) { this.serial = serial; }
        public void setId(String id) { this.id = Int32.Parse(id); }
        public void setFirstAired(String firstAired)
        {
            if (firstAired != "")
                this.firstAired = DateTime.ParseExact(firstAired, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
        public void setNumber(String number) { this.number = Int32.Parse(number); }

    }
}