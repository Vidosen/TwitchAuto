using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchAuto
{
    public partial class SettingsForm : Form
    {
        Config config;
        public SettingsForm()
        {
            config = Config.GetConfig();
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(config.Lang);
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(config.Lang);
            InitializeComponent();
            LanguageBox.Text = config.Lang == "ru-RU" ? "Russian" : "English";
            RefreshNumeric.Value = config.RefreshTime;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (LanguageBox.Text != config.Lang.ToString())
            {
                if (LanguageBox.Text == "Russian")
                {
                    config.Lang = "ru-RU";
                    MessageBox.Show("Reload the appliction for the changes to take effect.");
                }
                if (LanguageBox.Text == "English")
                {
                    config.Lang = "en-US";
                    MessageBox.Show("Перезагрузите приложение, чтобы изменения вступили в силу.");
                }
            }
            config.RefreshTime = (int)RefreshNumeric.Value;
            Config.Save();
            Close();
        }
    }
}
