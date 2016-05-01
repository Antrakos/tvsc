using System;

namespace TVSeriesCompanion.Models
{
    public class Torrent
    {
        private String title;
        private DateTime pubDate;
        private String link;
        private int peers;
        private int seeds;
        private int leechs;
        private double size;

        public Torrent() {}

        public Torrent(String title, DateTime pubDate, String link, int peers, int seeds, int leechs, double size)
        {
            this.title = title;
            this.pubDate = pubDate;
            this.link = link;
            this.peers = peers;
            this.seeds = seeds;
            this.leechs = leechs;
            this.size = size;
        }

        public String getTitle()
        {
            return title;
        }

        public void setTitle(String title)
        {
            this.title = title;
        }

        public DateTime getPubDate()
        {
            return pubDate;
        }

        public void setPubDate(DateTime pubDate)
        {
            this.pubDate = pubDate;
        }

        public String getLink()
        {
            return link;
        }

        public void setLink(String link)
        {
            this.link = link;
        }

        public int getPeers()
        {
            return peers;
        }

        public void setPeers(int peers)
        {
            this.peers = peers;
        }

        public int getSeeds()
        {
            return seeds;
        }

        public void setSeeds(int seeds)
        {
            this.seeds = seeds;
        }

        public int getLeechs()
        {
            return leechs;
        }

        public void setLeechs(int leechs)
        {
            this.leechs = leechs;
        }

        public double getSize()
        {
            return size;
        }

        public void setSize(double size)
        {
            this.size = size;
        }


        public override string ToString()
        {
            return "Torrent{" +
                    "title='" + title + '\'' +
                    ", pubDate=" + pubDate +
                    ", seeds=" + seeds +
                    ", size=" + size +
                    '}';
        }
    }
}