using System;
using System.Windows.Forms;
using TVSeriesCompanion.Controllers;
using TVSeriesCompanion.Models;

namespace TVSeriesCompanion.Views
{
    public partial class SettingsForm : Form
    {
        Settings settings;
        Form sender;
        public SettingsForm(Form sender)
        {
            InitializeComponent();
            this.sender = sender;
            imageDialog.Filter = @"Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            imageDialog.Title = @"Select default image";
            dftDialog.Description = @"Select directory for torrents";
            settings = SeriesManager.getSettings();
            dftTextBox.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + settings.TORRENT_DIR;
            nfTextBox.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + settings.IMAGE_NOT_FOUND;
            dtTextBox.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + settings.DOWNLOAD_TORRENT_IMAGE;
            ciTextBox.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + settings.CHECK_IMAGE;
            uiTextBox.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + settings.UNCHECK_IMAGE;
            aTextBox.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + settings.ADD_IMAGE;
            dTextBox.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\" + settings.DOWNLOAD_IMAGE;
            var d = DateTime.Now;
            if (settings.UPDATE_INTERVAL == TimeSpan.FromHours(1))
                uiComboBox.SelectedIndex = 0;
            else if (settings.UPDATE_INTERVAL == TimeSpan.FromHours(2))
                uiComboBox.SelectedIndex = 1;
            else if (settings.UPDATE_INTERVAL == TimeSpan.FromHours(6))
                uiComboBox.SelectedIndex = 2;
            else if (settings.UPDATE_INTERVAL == TimeSpan.FromHours(12))
                uiComboBox.SelectedIndex = 3;
            else if (settings.UPDATE_INTERVAL == TimeSpan.FromDays(1))
                uiComboBox.SelectedIndex = 4;
            else if (settings.UPDATE_INTERVAL == TimeSpan.FromDays(7))
                uiComboBox.SelectedIndex = 5;
            else if (settings.UPDATE_INTERVAL == TimeSpan.FromDays(14))
                uiComboBox.SelectedIndex = 6;
            else if (settings.UPDATE_INTERVAL == (d.AddMonths(1) - d))
                uiComboBox.SelectedIndex = 7;
            rtadComboBox.SelectedIndex = settings.RUN_TORRENT_AFTER_DOWNLOAD?0:1;
        }

        private void defaultBtn_Click(object sender, EventArgs e)
        {
            SeriesManager.getSettings().SetDefaultSettings();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dftTextBox_Click(object sender, EventArgs e)
        {
            if (dftDialog.ShowDialog() == DialogResult.OK)
                dftTextBox.Text = dftDialog.SelectedPath;
            settings.TORRENT_DIR = dftTextBox.Text;
        }

        private void rtadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool.TryParse(((ComboBox) sender).SelectedItem.ToString(), out settings.RUN_TORRENT_AFTER_DOWNLOAD);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            SeriesManager.setSettings(settings);
            SeriesManager.getSettings().save();
            this.Close();
        }

        private void uiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d = DateTime.Now;
            switch(((ComboBox) sender).SelectedItem.ToString())
            {
                case "1 hour":  settings.UPDATE_INTERVAL = TimeSpan.FromHours(1); break;
                case "2 hours": settings.UPDATE_INTERVAL = TimeSpan.FromHours(2); break;
                case "6 hours": settings.UPDATE_INTERVAL = TimeSpan.FromHours(6); break;
                case "12 hours":settings.UPDATE_INTERVAL = TimeSpan.FromHours(12); break;
                case "1 day":   settings.UPDATE_INTERVAL = TimeSpan.FromDays(1); break;
                case "1 week":  settings.UPDATE_INTERVAL = TimeSpan.FromDays(7); break;
                case "2 weeks": settings.UPDATE_INTERVAL = TimeSpan.FromDays(14); break;
                case "1 month": settings.UPDATE_INTERVAL = d.AddMonths(1) - d; break;
            }
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.sender.WindowState = FormWindowState.Normal;
        }
        private void selectImage(TextBox tb)
        {
            imageDialog.InitialDirectory = tb.Text;
            if (imageDialog.ShowDialog() == DialogResult.OK)
                tb.Text = imageDialog.FileName;
        }

        private void nfTextBox_Click(object sender, EventArgs e)
        {
            selectImage(nfTextBox);
            settings.IMAGE_NOT_FOUND = nfTextBox.Text;
        }

        private void dtTextBox_Click(object sender, EventArgs e)
        {
            selectImage(dtTextBox);
            settings.DOWNLOAD_TORRENT_IMAGE = dtTextBox.Text;
        }
        
        private void ciTextBox_Click(object sender, EventArgs e)
        {
            selectImage(ciTextBox);
            settings.CHECK_IMAGE = ciTextBox.Text;
        }

        private void uiTextBox_Click(object sender, EventArgs e)
        {
            selectImage(uiTextBox);
            settings.UNCHECK_IMAGE = uiTextBox.Text;
        }

        private void aTextBox_Click(object sender, EventArgs e)
        {
            selectImage(aTextBox);
            settings.ADD_IMAGE = aTextBox.Text;
        }

        private void dTextBox_Click(object sender, EventArgs e)
        {
            selectImage(dTextBox);
            settings.DOWNLOAD_IMAGE = dTextBox.Text;
        }

    }
}