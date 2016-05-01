using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TrayNotification;
using TVSeriesCompanion.Aspects;
using TVSeriesCompanion.Controllers;
using TVSeriesCompanion.Models;

namespace TVSeriesCompanion.Views
{
    public partial class MainForm : Form
    {
        private Serial _currentSerial;
        public MainForm()
        {
            InitializeComponent();
            overviewLabel.Paint += (s, e) => overviewLabel.MaximumSize = new Size(middleFlowPanel.Size.Width, 0);
            RepaintDbPage();

        }
        
        private static void OnMouseEnter(object sender, EventArgs e)
        {
            ((Label) sender).BackColor = Color.DarkGray;
        }
        private void OnMouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = tvSeriesListFlowLayout.BackColor;
        }

        public void SetStatus(bool status)
        {
            statusLabel.Text = status ? "In progress..." : "Ready";
            statusLabel.Refresh();
        }

        [StatusAspect]
        private void DrawSerialInfo(Serial serial)
        {
            serialTablePanel.Controls.Clear();
            rightDescriptionPanel.Controls.Clear();
            seasonLabel.Text = "";
            seasonTableLayout.Controls.Clear();
            seasonTableLayout.RowCount = 0;
            episodesTableLayout.Controls.Clear();
            rightFlowPanel.Size = new Size(0, 0);
            _currentSerial = serial;
            serialTablePanel.Controls.Add(getPictureBox((_currentSerial.getPoster() != null && _currentSerial.getPoster() != "" ? _currentSerial.getPoster() : SeriesManager.getSettings().IMAGE_NOT_FOUND)), 0, 0);
            var nameLabel = new Label { Text = _currentSerial.getName(), AutoSize = true, Font = new Font("Calibri", 20, (FontStyle.Italic | FontStyle.Bold)) };
            nameLabel.Paint += (s, e) => nameLabel.MaximumSize = new Size(rightDescriptionPanel.Size.Width, 0);
            rightDescriptionPanel.Controls.Add(nameLabel);
            rightDescriptionPanel.Controls.Add(new Label { Text = @"Rating: " + _currentSerial.getRating(), AutoSize = true });
            if (_currentSerial.getNetwork() != null)
                rightDescriptionPanel.Controls.Add(new Label { Text = @"Network: " + _currentSerial.getNetwork(), AutoSize = true });
            if (_currentSerial.getStatus() != null)
                rightDescriptionPanel.Controls.Add(new Label { Text = @"Status: " + _currentSerial.getStatus(), AutoSize = true });
            rightDescriptionPanel.Controls.Add(new Label { Text = @"First aired: " + _currentSerial.getFirstAired().ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), AutoSize = true });
            if (_currentSerial.getContentRating() != null)
                rightDescriptionPanel.Controls.Add(new Label { Text = @"Content rating: " + _currentSerial.getContentRating(), AutoSize = true });
            if (_currentSerial.getAirsDayOfWeek() != null && _currentSerial.getAirsTime() != null)
                rightDescriptionPanel.Controls.Add(new Label { Text = @"Airs datetime: " + _currentSerial.getAirsDayOfWeek() + " " + _currentSerial.getAirsTime(), AutoSize = true });
            rightDescriptionPanel.Controls.Add(new Label { Text = @"Runtime: " + _currentSerial.getRuntime(), AutoSize = true });
            serialTablePanel.Controls.Add(rightDescriptionPanel, 1, 0);
            overviewLabel.MaximumSize = new Size(serialTablePanel.Width, 0);
            overviewLabel.Text = @"Overview:" + Environment.NewLine + _currentSerial.getOverview();
            RepaintWatchFlowPanel();
            foreach (var season in _currentSerial.getSeasons())
            {
                Label lb = new Label { Text = (season.getNumber() == 0 ? "Extras" : ("Season " + season.getNumber())), AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Tag = season };
                lb.Click += SeasonFlowLabelClick;
                lb.MouseEnter += OnMouseEnter;
                lb.MouseLeave += OnMouseLeave;
                lb.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
                Button checkBtn = getButton(SeriesManager.getSettings().UNCHECK_IMAGE);
                Button uncheckBtn = getButton(SeriesManager.getSettings().CHECK_IMAGE);
                checkBtn.Tag = uncheckBtn.Tag = season;
                checkBtn.Click += seasonCheckClick;
                uncheckBtn.Click += seasonCheckClick;
                PictureBox posterPb = getPictureBox((season.getBanner() != null && season.getBanner() != "" ? season.getBanner() : SeriesManager.getSettings().IMAGE_NOT_FOUND));
                seasonTableLayout.RowCount++;
                seasonTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
                seasonTableLayout.Controls.Add(posterPb, 0, seasonTableLayout.RowCount - 1);
                seasonTableLayout.Controls.Add(lb, 1, seasonTableLayout.RowCount - 1);
                seasonTableLayout.Controls.Add(checkBtn, 2, seasonTableLayout.RowCount - 1);
                seasonTableLayout.Controls.Add(uncheckBtn, 3, seasonTableLayout.RowCount - 1);

            }
        }
        private void RepaintWatchFlowPanel()
        {
            watchFlowPanel.Controls.Clear();
            var nextEpisode = SeriesManager.nextEpisode(_currentSerial);
            var nextToSeeEpisode = SeriesManager.nextToSeeEpisode(_currentSerial);
            if (nextEpisode != null)
                watchFlowPanel.Controls.Add(new Label { Text = @"Next aired: " + nextEpisode.getName(), AutoSize = true, Font = new Font("Calibri", 18, (FontStyle.Italic | FontStyle.Bold)) });
            if (nextToSeeEpisode.Item1 && nextToSeeEpisode.Item2 != nextEpisode)
                watchFlowPanel.Controls.Add(new Label { Text = @"Next to see: " + nextToSeeEpisode.Item2.getName(), AutoSize = true, Font = new Font("Calibri", 18, (FontStyle.Italic | FontStyle.Bold)) });
        }
        [StatusAspect]
        private void seasonCheckClick(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            bool check = btn.Name == "uncheck";
            if (MessageBox.Show(@"Are you sure to " + (check ? "check" : "uncheck") + @" ALL episodes in the season?", @"Confirm operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                SeriesManager.changeWatchStatusTo((Season)btn.Tag, check);
            RepaintWatchFlowPanel();
        }
        private Button getButton(string imageLocation)
        {
            return new Button
            {
                BackgroundImage = Image.FromFile(imageLocation),
                Name = (imageLocation==SeriesManager.getSettings().UNCHECK_IMAGE?"uncheck":""),
                //Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right))),
                Height = 50,
                Width = 50,
                //Dock = DockStyle.Left,
                BackgroundImageLayout = ImageLayout.Stretch
            };
        }
        private PictureBox getPictureBox(string imageLocation)
        {
            return new PictureBox
            {
                Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right,
                ImageLocation = imageLocation,
                SizeMode = PictureBoxSizeMode.Zoom
            };
        }
        private void SeasonFlowLabelClick(object sender, EventArgs e)
        {
            episodesTableLayout.Controls.Clear();
            episodesTableLayout.RowCount = 0;
            Season season = (Season)((Label) sender).Tag;
            seasonLabel.Text = (season.getNumber()==0?"Extras":"Season " + season.getNumber());
            foreach (Episode episode in season.getEpisodes())
                DrawEpisode(episodesTableLayout, episode);
        }
        [StatusAspect]
        private void CheckEpisodeClick(object sender, EventArgs e) 
        {
            Control ctrl = (Control)sender;
            Episode ep = (Episode)ctrl.Tag;
            if (ep.getFirstAired().Date > DateTime.Now.Date || ep.getFirstAired().Date == new DateTime())
                return;
            SeriesManager.changeWatchStatus(ep);
            if (ep.isWatched())
                ctrl.BackgroundImage = Image.FromFile(SeriesManager.getSettings().UNCHECK_IMAGE);
            else
                ctrl.BackgroundImage = Image.FromFile(SeriesManager.getSettings().CHECK_IMAGE);
            RepaintWatchFlowPanel();
        }
        [StatusAspect]
        private void DrawEpisode(TableLayoutPanel panel, Episode episode)
        {
            Button downloadBtn = getButton(SeriesManager.getSettings().DOWNLOAD_TORRENT_IMAGE);
            Button checkBtn = getButton((episode.isWatched() ? SeriesManager.getSettings().UNCHECK_IMAGE : SeriesManager.getSettings().CHECK_IMAGE));
            checkBtn.Tag = downloadBtn.Tag = episode;
            checkBtn.Click += CheckEpisodeClick;
            downloadBtn.Click += (s, ev) => {
                
                                                if (SeriesManager.isOnline())
                                                    (new TorrentForm((s as Button).Tag as Episode, this)).Show();
                                                else
                                                    MessageBox.Show(@"No Internet connection");
                                                WindowState = FormWindowState.Minimized;
            };
            panel.RowCount++;
            Label nameLabel = new Label { Text = episode.getNumber() + @": " + episode.getName(), AutoSize = true, TextAlign = ContentAlignment.MiddleLeft, Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right };
            PictureBox posterPb = getPictureBox((episode.getImage() != null && episode.getImage() != "" ? episode.getImage() : SeriesManager.getSettings().IMAGE_NOT_FOUND));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panel.Controls.Add(posterPb, 0, panel.RowCount - 1);
            panel.Controls.Add(nameLabel, 1, panel.RowCount - 1);
            panel.Controls.Add(downloadBtn, 2, panel.RowCount - 1);
            if (episode.getFirstAired().Date <= DateTime.Now.Date && episode.getFirstAired().Date != new DateTime())
                panel.Controls.Add(checkBtn, 3, panel.RowCount - 1);
        }

        
        [StatusAspect]
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == upcomingPage)
            {
                upcomingFolwPanel.Controls.Clear();

                List<Label> nextToSeeLabels = new List<Label>();
                List<Label> nextAiredLabels = new List<Label>();
                foreach (Serial serial in SeriesManager.getSavedTVSeries())
                {
                    var nextEpisode = SeriesManager.nextEpisode(serial);
                    var nextToSeeEpisode = SeriesManager.nextToSeeEpisode(serial);

                    Label lb = new Label();
                    lb.Tag = nextToSeeEpisode.Item2;
                    lb.Size = new Size(tvSeriesListFlowLayout.Size.Width, 40);
                    lb.Click += (s, ev) =>
                    {
                        Episode ep = (Episode)((Label) s).Tag;
                        Notification n = SeriesManager.getNotification(ep);
                        n.Click += (se, ea) =>
                        {
                            DrawSerialInfo(ep.getSerial());
                            SeasonFlowLabelClick(new Label { Tag = ep.getSeason() }, e);
                        };
                        n.Show();

                    };
                    lb.MouseEnter += OnMouseEnter;
                    lb.MouseLeave += OnMouseLeave;
                    lb.Text = nextToSeeEpisode.Item2.getSerial().getName() + Environment.NewLine + nextToSeeEpisode.Item2.getSeason().getNumber() + "x" + nextToSeeEpisode.Item2.getNumber() + ": " + nextToSeeEpisode.Item2.getName() + Environment.NewLine + nextToSeeEpisode.Item2.getFirstAired().ToString("dd.MM.yyyy HH:mm");
                    lb.Tag = nextToSeeEpisode.Item2;

                    if (nextToSeeEpisode.Item1 && nextToSeeEpisode.Item2 != nextEpisode)
                        nextToSeeLabels.Add(lb);
                    else if (nextToSeeEpisode.Item2.getFirstAired() != new DateTime() && !nextToSeeEpisode.Item2.isWatched())
                        nextAiredLabels.Add(lb);
                }
                if (nextToSeeLabels.Count > 0)
                {
                    upcomingFolwPanel.Controls.Add(nextToSeeLabel);
                    nextToSeeLabels.Sort((x, y) => ((Episode) y.Tag).getFirstAired().CompareTo(((Episode) x.Tag).getFirstAired()));
                    foreach (Label label in nextToSeeLabels)
                        upcomingFolwPanel.Controls.Add(label);
                }
                if (nextAiredLabels.Count > 0)
                {
                    upcomingFolwPanel.Controls.Add(nextAiredLabel);
                    nextAiredLabels.Sort((x, y) => string.Compare(((Episode) x.Tag).getSerial().getName(), ((Episode) y.Tag).getSerial().getName(), StringComparison.Ordinal));
                    foreach (Label label in nextAiredLabels)
                        upcomingFolwPanel.Controls.Add(label);
                }
            }
            else if (tabControl.SelectedTab == dbPage)
                RepaintDbPage();
            else if (tabControl.SelectedTab == searchPage)
            {
                bool isConnected = SeriesManager.isOnline();
                searchTextBox.Text = (isConnected ? (searchTextBox.Text == @"No Internet connection" ? "" : searchTextBox.Text) : "No Internet connection");
                searchTextBox.Enabled = isConnected;
                if (!isConnected)
                {
                    searchResultsTableLayout.Controls.Clear();
                    searchResultsTableLayout.RowCount = 1;
                }
            }
        }
        private void RepaintDbPage()
        {
            tvSeriesListFlowLayout.Controls.Clear();
            foreach (Tuple<string, int> serial in SeriesManager.getTVSeriesNames())
            {
                Label lb = new Label { Text = serial.Item1, Tag = serial.Item2 };
                lb.Size = new Size(tvSeriesListFlowLayout.Size.Width, 20);
                lb.Click += (s, ev) => DrawSerialInfo(SeriesManager.getSavedSerial(((Label) s).Tag.ToString()));
                lb.MouseEnter += OnMouseEnter;
                lb.MouseLeave += OnMouseLeave;
                tvSeriesListFlowLayout.Controls.Add(lb);
            }
        }
        [StatusAspect]
        private void addSerialClick(object sender, EventArgs e)
        {
            if (SeriesManager.isOnline())
                SeriesManager.saveSerial(SeriesManager.findById(((Control)sender).Tag.ToString()));
        }
        [StatusAspect]
        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (Control c in searchTableLayout.Controls)
                    if (c.GetType() != searchTextBox.GetType())
                        searchTableLayout.Controls.Remove(c);
                searchResultsTableLayout.Controls.Clear();
                searchResultsTableLayout.RowCount = 1;
                List<Serial> results = SeriesManager.findByName(searchTextBox.Text);
                if (results.Count == 0)
                {
                    searchTableLayout.Controls.Add(new Label { Text = @"No results found", AutoSize = true, Font = new Font("Calibri", 20, (FontStyle.Italic | FontStyle.Bold)) });
                    return;
                }
                searchTableLayout.Controls.Add(searchResultsTableLayout);
                searchResultsTableLayout.Controls.Add(new Label());
                searchResultsTableLayout.Controls.Add(new Label { Text = @"Title", AutoSize = true }, 1, 0);
                searchResultsTableLayout.Controls.Add(new Label { Text = @"First aired", AutoSize = true }, 2, 0);

                foreach (Serial serial in results)
                {
                    Button saveBtn = getButton(SeriesManager.getSettings().ADD_IMAGE);
                    saveBtn.Tag = serial.getId();
                    saveBtn.Click += addSerialClick;
                    Label[] labels = new Label[2];
                    for (int i = 0; i < labels.Length; i++)
                    {
                        labels[i] = new Label { AutoSize = true, TextAlign = ContentAlignment.MiddleLeft };
                        labels[i].Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
                    }
                    labels[0].Text = serial.getName();
                    labels[0].Tag = serial.getId();
                    labels[1].Text = serial.getFirstAired().ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    labels[0].Click += (s, ev) => DrawSerialInfo(SeriesManager.findById((s as Label).Tag.ToString()));
                    labels[0].MouseEnter += OnMouseEnter;
                    labels[0].MouseLeave += OnMouseLeave;

                    searchResultsTableLayout.RowCount++;
                    searchResultsTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
                    searchResultsTableLayout.Controls.Add(saveBtn, 0, searchResultsTableLayout.RowCount - 1);
                    searchResultsTableLayout.Controls.Add(labels[0], 1, searchResultsTableLayout.RowCount - 1);
                    searchResultsTableLayout.Controls.Add(labels[1], 2, searchResultsTableLayout.RowCount - 1);
                }
            }
        }
        private void flowPanel_Enter(object sender, EventArgs e)
        {
            (sender as FlowLayoutPanel).Focus();
        }
        [StatusAspect]
        private void deleteCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentSerial == null)
                return;
            SeriesManager.deleteSerial(_currentSerial);
            _currentSerial = null;
            clearSerialData();
        }
        [StatusAspect]
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _currentSerial = null;
            foreach (Serial serial in SeriesManager.getSavedTVSeries())
                SeriesManager.deleteSerial(serial);
            clearSerialData();
        }
        private void clearSerialData()
        {
            RepaintDbPage();
            tabControl.SelectedIndex = 0;
            serialTablePanel.Controls.Clear();
            rightDescriptionPanel.Controls.Clear();
            overviewLabel.Text = "";
            watchFlowPanel.Controls.Clear();
            seasonLabel.Text = "";
            seasonTableLayout.Controls.Clear();
            seasonTableLayout.RowCount = 0;
            episodesTableLayout.Controls.Clear();
            rightFlowPanel.Size = new Size(0, 0);
        }
        [StatusAspect]
        private void updateCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentSerial == null || !SeriesManager.isOnline())
                return;
            SeriesManager.updateSerial(_currentSerial);
            _currentSerial = SeriesManager.getSavedSerial(_currentSerial.getId().ToString());
            DrawSerialInfo(_currentSerial);
        }
        [StatusAspect]
        private void updateAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SeriesManager.isOnline())
                return;
            foreach (Serial serial in SeriesManager.getSavedTVSeries())
                SeriesManager.updateSerial(serial);
            SeriesManager.getSettings().LAST_UPDATED = DateTime.Now;
            clearSerialData();
        }
        private void MainFrame_Shown(object sender, EventArgs e)
        {
            if (DateTime.Now.Subtract(SeriesManager.getSettings().LAST_UPDATED) > SeriesManager.getSettings().UPDATE_INTERVAL && SeriesManager.isOnline())
                updateAllToolStripMenuItem_Click(this, new EventArgs());
        }
        private void MainFrame_Closing(object sender, EventArgs e)
        {
            SeriesManager.getSettings().save();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new SettingsForm(this)).Show();
            WindowState = FormWindowState.Minimized;
        }
    }
}