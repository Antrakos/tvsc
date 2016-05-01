using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Model;

namespace TVSeriesCompanion.Models
{
    public class Season
    {
        private int number;
        private List<Episode> episodes;
        private String banner;
        private Serial serial;
        
        public Season() { }

        public Season(int number, List<Episode> episodes, String banner)
        {
            this.number = number;
            this.episodes = episodes;
            this.banner = banner;
        }
        public Season(int number, List<Episode> episodes)
        {
            this.number = number;
            this.episodes = episodes;
            this.banner = null;
        }
        
        public Season(XmlNodeList season, String banner)
        {
            number = int.Parse(season.Item(0)["SeasonNumber"].InnerText);
            List<Episode> episodes = new List<Episode>();
            foreach (XmlNode episode in season)
                episodes.Add(new Episode(episode));
            this.episodes = episodes;
            this.banner = banner;
        }

        public int getNumber()
        {
            return number;
        }
        public void setNumber(int number)
        {
            this.number = number;
        }

        public List<Episode> getEpisodes()
        {
            return episodes;
        }

        public void setEpisodes(List<Episode> episodes)
        {
            this.episodes = episodes;
        }

        public String getBanner()
        {
            return banner;
        }
        public void setBanner(String banner)
        {
            this.banner = banner;
        }
        public Serial getSerial()
        {
            return serial;
        }
        public void setSerial(Serial serial)
        {
            this.serial = serial;
        }
        public PictureBox getPictureBox()
        {
            PictureBox pb = new PictureBox();
            pb.ImageLocation = (getBanner() != null && getBanner() != "" ? getBanner() : @"https://az853139.vo.msecnd.net/static/images/not-found.png");
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            return pb;
        }
    }
}