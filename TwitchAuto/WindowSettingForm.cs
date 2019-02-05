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

    public partial class WindowSettingForm : Form
    {
        Config config;
        public WindowSettingForm()
        {
            config = Config.GetConfig();
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(config.Lang);
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(config.Lang);
            InitializeComponent();
            HeightNum.Value = config.BrowserHeight;
            WidthNum.Value = config.BrowserWidth;
            LeftNum.Value = config.BrowserLeft;
            TopNum.Value = config.BrowserTop;
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            config.BrowserHeight = (int)HeightNum.Value;
            config.BrowserWidth = (int)WidthNum.Value;
            config.BrowserLeft = (int)LeftNum.Value;
            config.BrowserTop = (int)TopNum.Value;
            Config.Save();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
