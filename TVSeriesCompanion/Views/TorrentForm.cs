using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TVSeriesCompanion.Controllers;
using TVSeriesCompanion.Models;

namespace TVSeriesCompanion.Views
{
    public partial class TorrentForm : Form
    {
        private readonly Form _sender;
        public TorrentForm(Episode episode, Form sender)
        {
                _sender = sender;
                InitializeComponent();
                searchTextBox.Text = episode.getSerial().getName() + @" S" + episode.getSeason().getNumber().ToString("D2") + "E" + episode.getNumber().ToString("D2");
                Download();
         }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Download();
        }
        private void Download()
        {
            torrentFlowPanel.Controls.Clear();
            torrentTableLayout.Controls.Clear();
            torrentTableLayout.RowCount = 1;
            List<Torrent> results = SeriesManager.searchTorrent(searchTextBox.Text);
            if (results.Count == 0)
            {
                torrentFlowPanel.Controls.Add(new Label { Text = @"No results found", AutoSize = true, Font = new Font("Calibri", 20, (FontStyle.Italic | FontStyle.Bold)) });
                return;
            }
            torrentFlowPanel.Controls.Add(torrentTableLayout);
            torrentTableLayout.Controls.Add(new Label());
            torrentTableLayout.Controls.Add(new Label { Text = @"Title", AutoSize = true }, 1, 0);
            torrentTableLayout.Controls.Add(new Label { Text = @"Seeders", AutoSize = true }, 2, 0);
            torrentTableLayout.Controls.Add(new Label { Text = @"Peers", AutoSize = true }, 3, 0);
            torrentTableLayout.Controls.Add(new Label { Text = @"Size", AutoSize = true }, 4, 0);

            foreach (Torrent torrent in results)
            {
                PictureBox downloadPb = new PictureBox();
                downloadPb.ImageLocation = SeriesManager.getSettings().DOWNLOAD_IMAGE;
                downloadPb.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
                downloadPb.SizeMode = PictureBoxSizeMode.Zoom;
                downloadPb.Tag = torrent;
                downloadPb.Click += (s, ev) => SeriesManager.downloadTorrent((((PictureBox)s).Tag) as Torrent);

                Label[] labels = new Label[4];
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i] = new Label
                    {
                        AutoSize = true,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Anchor =
                            ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right
                    };
                }
                labels[0].Text = torrent.getTitle();
                labels[1].Text = torrent.getSeeds().ToString();
                labels[2].Text = torrent.getPeers().ToString();
                labels[3].Text = torrent.getSize() + @"MB";

                torrentTableLayout.RowCount++;
                torrentTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
                torrentTableLayout.Controls.Add(downloadPb, 0, torrentTableLayout.RowCount - 1);
                torrentTableLayout.Controls.Add(labels[0], 1, torrentTableLayout.RowCount - 1);
                torrentTableLayout.Controls.Add(labels[1], 2, torrentTableLayout.RowCount - 1);
                torrentTableLayout.Controls.Add(labels[2], 3, torrentTableLayout.RowCount - 1);
                torrentTableLayout.Controls.Add(labels[3], 4, torrentTableLayout.RowCount - 1);
            }
        }

        private void TorrentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sender.WindowState = FormWindowState.Normal;
        }
    }
}