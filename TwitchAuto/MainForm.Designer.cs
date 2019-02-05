namespace TwitchAuto
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LogoLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.AddLine = new System.Windows.Forms.Button();
            this.DelSelected = new System.Windows.Forms.Button();
            this.MainStrip = new System.Windows.Forms.MenuStrip();
            this.settingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.genearalSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browsersWindowSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.TextBoxURL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DonateLink = new System.Windows.Forms.LinkLabel();
            this.TopDonates = new System.Windows.Forms.Label();
            this.LoginTimer = new System.Windows.Forms.Timer(this.components);
            this.WatchTimer = new System.Windows.Forms.Timer(this.components);
            this.AccountsTable = new System.Windows.Forms.DataGridView();
            this.Stop = new System.Windows.Forms.Button();
            this.BroadcastLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.loginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MainStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoLabel
            // 
            resources.ApplyResources(this.LogoLabel, "LogoLabel");
            this.LogoLabel.Name = "LogoLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Start
            // 
            resources.ApplyResources(this.Start, "Start");
            this.Start.Name = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // AddLine
            // 
            resources.ApplyResources(this.AddLine, "AddLine");
            this.AddLine.Name = "AddLine";
            this.AddLine.UseVisualStyleBackColor = true;
            this.AddLine.Click += new System.EventHandler(this.AddLine_Click);
            // 
            // DelSelected
            // 
            resources.ApplyResources(this.DelSelected, "DelSelected");
            this.DelSelected.Name = "DelSelected";
            this.DelSelected.UseVisualStyleBackColor = true;
            this.DelSelected.Click += new System.EventHandler(this.DelSelected_Click);
            // 
            // MainStrip
            // 
            this.MainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenu,
            this.contactSupportToolStripMenuItem});
            resources.ApplyResources(this.MainStrip, "MainStrip");
            this.MainStrip.Name = "MainStrip";
            // 
            // settingsMenu
            // 
            this.settingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genearalSettingToolStripMenuItem,
            this.browsersWindowSettingsToolStripMenuItem});
            this.settingsMenu.Name = "settingsMenu";
            resources.ApplyResources(this.settingsMenu, "settingsMenu");
            // 
            // genearalSettingToolStripMenuItem
            // 
            this.genearalSettingToolStripMenuItem.Name = "genearalSettingToolStripMenuItem";
            resources.ApplyResources(this.genearalSettingToolStripMenuItem, "genearalSettingToolStripMenuItem");
            this.genearalSettingToolStripMenuItem.Click += new System.EventHandler(this.genearalSettingToolStripMenuItem_Click);
            // 
            // browsersWindowSettingsToolStripMenuItem
            // 
            this.browsersWindowSettingsToolStripMenuItem.Name = "browsersWindowSettingsToolStripMenuItem";
            resources.ApplyResources(this.browsersWindowSettingsToolStripMenuItem, "browsersWindowSettingsToolStripMenuItem");
            this.browsersWindowSettingsToolStripMenuItem.Click += new System.EventHandler(this.browsersWindowSettingsToolStripMenuItem_Click);
            // 
            // contactSupportToolStripMenuItem
            // 
            this.contactSupportToolStripMenuItem.Name = "contactSupportToolStripMenuItem";
            resources.ApplyResources(this.contactSupportToolStripMenuItem, "contactSupportToolStripMenuItem");
            this.contactSupportToolStripMenuItem.Click += new System.EventHandler(this.contactSupportToolStripMenuItem_Click);
            // 
            // Log
            // 
            this.Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.Log, "Log");
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            // 
            // TextBoxURL
            // 
            resources.ApplyResources(this.TextBoxURL, "TextBoxURL");
            this.TextBoxURL.Name = "TextBoxURL";
            this.TextBoxURL.TextChanged += new System.EventHandler(this.TextBoxURL_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DonateLink);
            this.groupBox1.Controls.Add(this.TopDonates);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // DonateLink
            // 
            resources.ApplyResources(this.DonateLink, "DonateLink");
            this.DonateLink.Name = "DonateLink";
            this.DonateLink.TabStop = true;
            this.DonateLink.Click += new System.EventHandler(this.DonateLink_Click);
            // 
            // TopDonates
            // 
            resources.ApplyResources(this.TopDonates, "TopDonates");
            this.TopDonates.Name = "TopDonates";
            // 
            // LoginTimer
            // 
            this.LoginTimer.Interval = 800;
            this.LoginTimer.Tick += new System.EventHandler(this.LoginTimer_Tick);
            // 
            // WatchTimer
            // 
            this.WatchTimer.Interval = 1000;
            this.WatchTimer.Tick += new System.EventHandler(this.WatchTimer_Tick);
            // 
            // AccountsTable
            // 
            this.AccountsTable.AutoGenerateColumns = false;
            this.AccountsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.loginDataGridViewTextBoxColumn});
            this.AccountsTable.DataSource = this.accountDataBindingSource;
            resources.ApplyResources(this.AccountsTable, "AccountsTable");
            this.AccountsTable.Name = "AccountsTable";
            this.AccountsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // Stop
            // 
            resources.ApplyResources(this.Stop, "Stop");
            this.Stop.Name = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // BroadcastLabel
            // 
            resources.ApplyResources(this.BroadcastLabel, "BroadcastLabel");
            this.BroadcastLabel.Name = "BroadcastLabel";
            // 
            // TimeLabel
            // 
            resources.ApplyResources(this.TimeLabel, "TimeLabel");
            this.TimeLabel.Name = "TimeLabel";
            // 
            // loginDataGridViewTextBoxColumn
            // 
            this.loginDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.loginDataGridViewTextBoxColumn.DataPropertyName = "Login";
            resources.ApplyResources(this.loginDataGridViewTextBoxColumn, "loginDataGridViewTextBoxColumn");
            this.loginDataGridViewTextBoxColumn.Name = "loginDataGridViewTextBoxColumn";
            this.loginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accountDataBindingSource
            // 
            this.accountDataBindingSource.DataSource = typeof(TwitchAuto.AccountData);
            // 
            // MainForm
            // 
            this.AcceptButton = this.Start;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.BroadcastLabel);
            this.Controls.Add(this.AccountsTable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TextBoxURL);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.DelSelected);
            this.Controls.Add(this.AddLine);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogoLabel);
            this.Controls.Add(this.MainStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MainStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainStrip.ResumeLayout(false);
            this.MainStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LogoLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddLine;
        private System.Windows.Forms.Button DelSelected;
        private System.Windows.Forms.MenuStrip MainStrip;
        private System.Windows.Forms.ToolStripMenuItem contactSupportToolStripMenuItem;
        protected internal System.Windows.Forms.Button Start;
        private System.Windows.Forms.ToolStripMenuItem genearalSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browsersWindowSettingsToolStripMenuItem;
        protected internal System.Windows.Forms.RichTextBox Log;
        protected internal System.Windows.Forms.TextBox TextBoxURL;
        public System.Windows.Forms.ToolStripMenuItem settingsMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TopDonates;
        private System.Windows.Forms.LinkLabel DonateLink;
        private System.Windows.Forms.Timer LoginTimer;
        private System.Windows.Forms.Timer WatchTimer;
        private System.Windows.Forms.BindingSource accountDataBindingSource;
        private System.Windows.Forms.DataGridView AccountsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginDataGridViewTextBoxColumn;
        protected internal System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label BroadcastLabel;
        private System.Windows.Forms.Label TimeLabel;
    }
}

