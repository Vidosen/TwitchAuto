namespace TwitchAuto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.linkCheckUpdates = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.LanguageBox = new System.Windows.Forms.ComboBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RefreshNumeric = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // linkCheckUpdates
            // 
            resources.ApplyResources(this.linkCheckUpdates, "linkCheckUpdates");
            this.linkCheckUpdates.Name = "linkCheckUpdates";
            this.linkCheckUpdates.TabStop = true;
            this.linkCheckUpdates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCheckUpdates_LinkClicked);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // LanguageBox
            // 
            this.LanguageBox.DisplayMember = "English";
            this.LanguageBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageBox.Items.AddRange(new object[] {
            resources.GetString("LanguageBox.Items"),
            resources.GetString("LanguageBox.Items1")});
            resources.ApplyResources(this.LanguageBox, "LanguageBox");
            this.LanguageBox.Name = "LanguageBox";
            this.LanguageBox.ValueMember = "English";
            // 
            // Submit
            // 
            resources.ApplyResources(this.Submit, "Submit");
            this.Submit.Name = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // RefreshNumeric
            // 
            resources.ApplyResources(this.RefreshNumeric, "RefreshNumeric");
            this.RefreshNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.RefreshNumeric.Name = "RefreshNumeric";
            this.RefreshNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.Submit;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.RefreshNumeric);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.LanguageBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkCheckUpdates);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.RefreshNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkCheckUpdates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox LanguageBox;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RefreshNumeric;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}