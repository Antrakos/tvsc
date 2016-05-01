using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TVSeriesCompanion.Models
{
    public class Settings
    {
        private string path;
        public string TORRENT_DIR;
        public string SUBS_DIR;
        public bool RUN_TORRENT_AFTER_DOWNLOAD;
        public bool SHOW_HI;
        public string IMAGE_NOT_FOUND;
        public string DOWNLOAD_TORRENT_IMAGE;
        public string CHECK_IMAGE;
        public string UNCHECK_IMAGE;
        public string ADD_IMAGE;
        public string DOWNLOAD_IMAGE;
        public DateTime LAST_UPDATED;
        public TimeSpan UPDATE_INTERVAL;
        public Settings(string settingsPath)
        {
            SetDefaultSettings();
            path = settingsPath;
            if (!File.Exists(settingsPath))
                return;
            var d = JObject.Parse(File.ReadAllText(settingsPath)).GetEnumerator();
            while (d.MoveNext())
                switch (d.Current.Key)
                {
                    case "TORRENT_DIR":                 TORRENT_DIR = (string)d.Current.Value; break;
                    case "SUBS_DIR":                    SUBS_DIR = (string)d.Current.Value; break;
                    case "RUN_TORRENT_AFTER_DOWNLOAD":  RUN_TORRENT_AFTER_DOWNLOAD = (bool)d.Current.Value; break;
                    case "SHOW_HI":                     SHOW_HI = (bool)d.Current.Value; break;
                    case "IMAGE_NOT_FOUND":             IMAGE_NOT_FOUND = (string)d.Current.Value; break;
                    case "DOWNLOAD_TORRENT_IMAGE":      DOWNLOAD_TORRENT_IMAGE = (string)d.Current.Value; break;
                    case "CHECK_IMAGE":                 CHECK_IMAGE = (string)d.Current.Value; break;
                    case "UNCHECK_IMAGE":               UNCHECK_IMAGE = (string)d.Current.Value; break;
                    case "DOWNLOAD_IMAGE":              DOWNLOAD_IMAGE = (string)d.Current.Value; break;
                    case "ADD_IMAGE":                   ADD_IMAGE = (string)d.Current.Value; break;
                    case "LAST_UPDATED":                LAST_UPDATED = d.Current.Value.ToString() == "" ? DateTime.Now : DateTime.Parse((string)d.Current.Value); break;
                    case "UPDATE_INTERVAL":             UPDATE_INTERVAL = d.Current.Value.ToString() == "" ? TimeSpan.FromDays(1) : TimeSpan.Parse((string)d.Current.Value); break;
                }
        }

        public void SetDefaultSettings() 
        {
            TORRENT_DIR = "torrents\\";
            SUBS_DIR = "subtitles\\";
            RUN_TORRENT_AFTER_DOWNLOAD = true;
            SHOW_HI = false;
            IMAGE_NOT_FOUND = "resources\\images\\not-found.png";
            DOWNLOAD_TORRENT_IMAGE = "resources\\images\\arrow-download-icon.png";
            CHECK_IMAGE = "resources\\images\\check_alt-128.png";
            UNCHECK_IMAGE = "resources\\images\\check-icon.png";
            DOWNLOAD_IMAGE = "resources\\images\\download.ico";
            ADD_IMAGE = "resources\\images\\sign-27080_640.png";
            LAST_UPDATED = DateTime.MinValue;
            UPDATE_INTERVAL = TimeSpan.FromDays(1);
        }
        public void save()
        {
            JObject settings = new JObject(
             new JProperty("TORRENT_DIR", TORRENT_DIR),
             new JProperty("SUBS_DIR", SUBS_DIR),
             new JProperty("RUN_TORRENT_AFTER_DOWNLOAD", RUN_TORRENT_AFTER_DOWNLOAD),
             new JProperty("SHOW_HI", SHOW_HI),
             new JProperty("IMAGE_NOT_FOUND", IMAGE_NOT_FOUND),
             new JProperty("DOWNLOAD_TORRENT_IMAGE", DOWNLOAD_TORRENT_IMAGE),
             new JProperty("CHECK_IMAGE", CHECK_IMAGE),
             new JProperty("UNCHECK_IMAGE", UNCHECK_IMAGE),
             new JProperty("DOWNLOAD_IMAGE", DOWNLOAD_IMAGE),
             new JProperty("ADD_IMAGE", ADD_IMAGE),
             new JProperty("LAST_UPDATED", LAST_UPDATED.ToString(CultureInfo.InvariantCulture)),
             new JProperty("UPDATE_INTERVAL", UPDATE_INTERVAL.ToString()));

            using (StreamWriter file = File.CreateText(path))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                    settings.WriteTo(writer);
        }
    }
}