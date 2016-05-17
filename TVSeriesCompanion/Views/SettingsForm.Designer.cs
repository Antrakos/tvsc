namespace TVSeriesCompanion.Views
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.defaultBtn = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dLabel = new System.Windows.Forms.Label();
            this.tdLabel = new System.Windows.Forms.Label();
            this.rtadLabel = new System.Windows.Forms.Label();
            this.uiLabel = new System.Windows.Forms.Label();
            this.infLabel = new System.Windows.Forms.Label();
            this.isLabel = new System.Windows.Forms.Label();
            this.dtiLabel = new System.Windows.Forms.Label();
            this.ciLabel = new System.Windows.Forms.Label();
            this.uniLabel = new System.Windows.Forms.Label();
            this.aLabel = new System.Windows.Forms.Label();
            this.dftTextBox = new System.Windows.Forms.TextBox();
            this.rtadComboBox = new System.Windows.Forms.ComboBox();
            this.uiComboBox = new System.Windows.Forms.ComboBox();
            this.nfTextBox = new System.Windows.Forms.TextBox();
            this.dtTextBox = new System.Windows.Forms.TextBox();
            this.ciTextBox = new System.Windows.Forms.TextBox();
            this.uiTextBox = new System.Windows.Forms.TextBox();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.dTextBox = new System.Windows.Forms.TextBox();
            this.dftDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.imageDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultBtn
            // 
            this.defaultBtn.AutoSize = true;
            this.defaultBtn.Location = new System.Drawing.Point(182, 276);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(101, 23);
            this.defaultBtn.TabIndex = 0;
            this.defaultBtn.Text = "Restore default";
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.Click += new System.EventHandler(this.defaultBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.AutoSize = true;
            this.submitBtn.Location = new System.Drawing.Point(289, 276);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 1;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(370, 276);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dLabel, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.tdLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtadLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.infLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.isLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtiLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ciLabel, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.uniLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.aLabel, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.dftTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rtadComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.uiComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nfTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.dtTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ciTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.uiTextBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.aTextBox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.dTextBox, 1, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 245);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dLabel
            // 
            this.dLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dLabel.AutoSize = true;
            this.dLabel.Location = new System.Drawing.Point(3, 220);
            this.dLabel.Name = "dLabel";
            this.dLabel.Size = new System.Drawing.Size(144, 25);
            this.dLabel.TabIndex = 9;
            this.dLabel.Text = "Download";
            // 
            // tdLabel
            // 
            this.tdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tdLabel.AutoSize = true;
            this.tdLabel.Location = new System.Drawing.Point(3, 0);
            this.tdLabel.Name = "tdLabel";
            this.tdLabel.Size = new System.Drawing.Size(144, 25);
            this.tdLabel.TabIndex = 0;
            this.tdLabel.Text = "Dirrectory for torrents";
            // 
            // rtadLabel
            // 
            this.rtadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtadLabel.AutoSize = true;
            this.rtadLabel.Location = new System.Drawing.Point(3, 25);
            this.rtadLabel.Name = "rtadLabel";
            this.rtadLabel.Size = new System.Drawing.Size(144, 25);
            this.rtadLabel.TabIndex = 1;
            this.rtadLabel.Text = "Run torrent after download";
            // 
            // uiLabel
            // 
            this.uiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiLabel.AutoSize = true;
            this.uiLabel.Location = new System.Drawing.Point(3, 50);
            this.uiLabel.Name = "uiLabel";
            this.uiLabel.Size = new System.Drawing.Size(144, 25);
            this.uiLabel.TabIndex = 2;
            this.uiLabel.Text = "Update interval";
            // 
            // infLabel
            // 
            this.infLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infLabel.AutoSize = true;
            this.infLabel.Location = new System.Drawing.Point(3, 95);
            this.infLabel.Name = "infLabel";
            this.infLabel.Size = new System.Drawing.Size(144, 25);
            this.infLabel.TabIndex = 3;
            this.infLabel.Text = "Not found";
            // 
            // isLabel
            // 
            this.isLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.isLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.isLabel, 2);
            this.isLabel.Location = new System.Drawing.Point(3, 75);
            this.isLabel.Name = "isLabel";
            this.isLabel.Size = new System.Drawing.Size(433, 20);
            this.isLabel.TabIndex = 4;
            this.isLabel.Text = "Images settings. Use it for customization the app";
            // 
            // dtiLabel
            // 
            this.dtiLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtiLabel.AutoSize = true;
            this.dtiLabel.Location = new System.Drawing.Point(3, 120);
            this.dtiLabel.Name = "dtiLabel";
            this.dtiLabel.Size = new System.Drawing.Size(144, 25);
            this.dtiLabel.TabIndex = 5;
            this.dtiLabel.Text = "Download torrent";
            // 
            // ciLabel
            // 
            this.ciLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ciLabel.AutoSize = true;
            this.ciLabel.Location = new System.Drawing.Point(3, 145);
            this.ciLabel.Name = "ciLabel";
            this.ciLabel.Size = new System.Drawing.Size(144, 25);
            this.ciLabel.TabIndex = 6;
            this.ciLabel.Text = "Check";
            // 
            // uniLabel
            // 
            this.uniLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uniLabel.AutoSize = true;
            this.uniLabel.Location = new System.Drawing.Point(3, 170);
            this.uniLabel.Name = "uniLabel";
            this.uniLabel.Size = new System.Drawing.Size(144, 25);
            this.uniLabel.TabIndex = 7;
            this.uniLabel.Text = "Uncheck";
            // 
            // aLabel
            // 
            this.aLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aLabel.AutoSize = true;
            this.aLabel.Location = new System.Drawing.Point(3, 195);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(144, 25);
            this.aLabel.TabIndex = 8;
            this.aLabel.Text = "Add";
            // 
            // dftTextBox
            // 
            this.dftTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dftTextBox.Location = new System.Drawing.Point(153, 3);
            this.dftTextBox.Name = "dftTextBox";
            this.dftTextBox.ReadOnly = true;
            this.dftTextBox.Size = new System.Drawing.Size(283, 20);
            this.dftTextBox.TabIndex = 10;
            this.dftTextBox.Click += new System.EventHandler(this.dftTextBox_Click);
            // 
            // rtadComboBox
            // 
            this.rtadComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtadComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rtadComboBox.Items.AddRange(new object[] {
            "true",
            "false"});
            this.rtadComboBox.Location = new System.Drawing.Point(153, 28);
            this.rtadComboBox.Name = "rtadComboBox";
            this.rtadComboBox.Size = new System.Drawing.Size(283, 21);
            this.rtadComboBox.TabIndex = 11;
            this.rtadComboBox.SelectedIndexChanged += new System.EventHandler(this.rtadComboBox_SelectedIndexChanged);
            // 
            // uiComboBox
            // 
            this.uiComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uiComboBox.Items.AddRange(new object[] {
            "1 hour",
            "2 hours",
            "6 hours",
            "12 hours",
            "1 day",
            "1 week",
            "2 weeks",
            "1 month"});
            this.uiComboBox.Location = new System.Drawing.Point(153, 53);
            this.uiComboBox.Name = "uiComboBox";
            this.uiComboBox.Size = new System.Drawing.Size(283, 21);
            this.uiComboBox.TabIndex = 12;
            this.uiComboBox.SelectedIndexChanged += new System.EventHandler(this.uiComboBox_SelectedIndexChanged);
            // 
            // nfTextBox
            // 
            this.nfTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nfTextBox.Location = new System.Drawing.Point(153, 98);
            this.nfTextBox.Name = "nfTextBox";
            this.nfTextBox.ReadOnly = true;
            this.nfTextBox.Size = new System.Drawing.Size(283, 20);
            this.nfTextBox.TabIndex = 13;
            this.nfTextBox.Click += new System.EventHandler(this.nfTextBox_Click);
            // 
            // dtTextBox
            // 
            this.dtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTextBox.Location = new System.Drawing.Point(153, 123);
            this.dtTextBox.Name = "dtTextBox";
            this.dtTextBox.ReadOnly = true;
            this.dtTextBox.Size = new System.Drawing.Size(283, 20);
            this.dtTextBox.TabIndex = 14;
            this.dtTextBox.Click += new System.EventHandler(this.dtTextBox_Click);
            // 
            // ciTextBox
            // 
            this.ciTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ciTextBox.Location = new System.Drawing.Point(153, 148);
            this.ciTextBox.Name = "ciTextBox";
            this.ciTextBox.ReadOnly = true;
            this.ciTextBox.Size = new System.Drawing.Size(283, 20);
            this.ciTextBox.TabIndex = 15;
            this.ciTextBox.Click += new System.EventHandler(this.ciTextBox_Click);
            // 
            // uiTextBox
            // 
            this.uiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiTextBox.Location = new System.Drawing.Point(153, 173);
            this.uiTextBox.Name = "uiTextBox";
            this.uiTextBox.ReadOnly = true;
            this.uiTextBox.Size = new System.Drawing.Size(283, 20);
            this.uiTextBox.TabIndex = 16;
            this.uiTextBox.Click += new System.EventHandler(this.uiTextBox_Click);
            // 
            // aTextBox
            // 
            this.aTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aTextBox.Location = new System.Drawing.Point(153, 198);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.ReadOnly = true;
            this.aTextBox.Size = new System.Drawing.Size(283, 20);
            this.aTextBox.TabIndex = 17;
            this.aTextBox.Click += new System.EventHandler(this.aTextBox_Click);
            // 
            // dTextBox
            // 
            this.dTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dTextBox.Location = new System.Drawing.Point(153, 223);
            this.dTextBox.Name = "dTextBox";
            this.dTextBox.ReadOnly = true;
            this.dTextBox.Size = new System.Drawing.Size(283, 20);
            this.dTextBox.TabIndex = 18;
            this.dTextBox.Click += new System.EventHandler(this.dTextBox_Click);
            // 
            // imageDialog
            // 
            this.imageDialog.FileName = "";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.defaultBtn);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button defaultBtn;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tdLabel;
        private System.Windows.Forms.Label rtadLabel;
        private System.Windows.Forms.Label uiLabel;
        private System.Windows.Forms.Label infLabel;
        private System.Windows.Forms.Label isLabel;
        private System.Windows.Forms.Label dtiLabel;
        private System.Windows.Forms.Label ciLabel;
        private System.Windows.Forms.Label uniLabel;
        private System.Windows.Forms.Label dLabel;
        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.TextBox dftTextBox;
        private System.Windows.Forms.FolderBrowserDialog dftDialog;
        private System.Windows.Forms.ComboBox rtadComboBox;
        private System.Windows.Forms.ComboBox uiComboBox;
        private System.Windows.Forms.TextBox nfTextBox;
        private System.Windows.Forms.TextBox dtTextBox;
        private System.Windows.Forms.TextBox ciTextBox;
        private System.Windows.Forms.TextBox uiTextBox;
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.TextBox dTextBox;
        private System.Windows.Forms.OpenFileDialog imageDialog;
    }
}