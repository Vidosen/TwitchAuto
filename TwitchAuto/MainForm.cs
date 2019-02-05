using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchAuto
{
    public partial class MainForm : Form
    {
        Config config;
        List<DriverContainer> driversOnline;
        bool isRunning;
        IWebDriver loginDriver;
        int BroadcastSeconds = 0;
        readonly string StdLoginUrl = "https://www.twitch.tv/directory/";
        public MainForm()
        {
            config = Config.GetConfig();
            Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(config.Lang);
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(config.Lang);
            InitializeComponent();
            AccountsTable.DataSource = config.Accounts;
            isRunning = false;
            driversOnline = new List<DriverContainer>();
            LogoLabel.Text += Application.ProductVersion;
            TextBoxURL.Text = config.StreamUrl;
            try
            {
                TopDonates.Text = null;
                DonateContainer container = JsonConvert.DeserializeObject<DonateContainer>(GET(""));
                foreach (var donater in container.Donaters)
                {
                    TopDonates.Text += $"{donater.Sender} - {donater.Amount:0.00}\t";
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }

        System.Net.Cookie ToDotNetCookie(Cookie initialCookie)
        {
            return new System.Net.Cookie(initialCookie.Name, initialCookie.Value, initialCookie.Path, initialCookie.Domain);
        }
        /// <summary>
        /// Добавляет новый аккаунт (путём извлечения куков авторизации)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLine_Click(object sender, EventArgs e)
        {
            LoginTimer.Start();
            Thread thread = new Thread(() =>
            {
                Invoke(new Action(() => AddLine.Enabled = false));
                Proxy proxy = new Proxy(); //Добавить прокси в следующих апдейтах
                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;
                loginDriver = new ChromeDriver(service, new ChromeOptions { Proxy = proxy, PageLoadStrategy = PageLoadStrategy.Normal, UnhandledPromptBehavior = UnhandledPromptBehavior.AcceptAndNotify });
                try
                {
                    loginDriver.Manage().Window.Size = new Size(420, 606); //Уточнить размер
                    PrepareLoginForm();
                    ReadOnlyCollection<Cookie> collection = loginDriver.Manage().Cookies.AllCookies;
                    while (!collection.Any(c => c.Name == "auth-token"))
                    {
                        Thread.Sleep(1000);
                        collection = loginDriver.Manage().Cookies.AllCookies;
                    }
                    Invoke(new Action(() => LoginTimer.Stop()));
                    List<System.Net.Cookie> cookies = new List<System.Net.Cookie>
                {
                    ToDotNetCookie(collection.FirstOrDefault(c => c.Name == "twilight-user")),
                    ToDotNetCookie(collection.FirstOrDefault(c => c.Name == "auth-token")),
                    ToDotNetCookie(collection.FirstOrDefault(c => c.Name == "persistent"))
                };
                    string name = collection.FirstOrDefault(c => c.Name == "name").Value;
                    AccountData account = new AccountData(name, cookies);
                    config.Accounts.Add(account);
                    Config.Save();
                    Invoke(new Action(() =>
                    {
                        AccountsTable.DataSource = null;
                        AccountsTable.DataSource = config.Accounts;
                        LogMessage($"Аккаунт {name} успешно добавлен");
                    }));
                    loginDriver.Quit();
                    Invoke(new Action(() => AddLine.Enabled = true));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() => { LoginTimer.Stop(); LogMessage($"При добавлении аккаунта произошла ошибка: {ex.Message}"); }));
                    loginDriver.Quit();
                    Invoke(new Action(() => AddLine.Enabled = true));
                }
            });
            try
            {
                thread.Start();
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }

        }
        /// <summary>
        /// Удалить выбранные аккаунты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelSelected_Click(object sender, EventArgs e)
        {
            try
            {
                var rows = AccountsTable.SelectedRows;
                if (rows.Count > 0)
                {
                    foreach (DataGridViewRow item in rows)
                    {
                        int index = item.Index;
                        config.Accounts.RemoveAt(index);
                    }
                    AccountsTable.DataSource = null;
                    Config.Save();
                    AccountsTable.DataSource = config.Accounts;
                }
                else
                {
                    MessageBox.Show("Вы не выбрали ни один аккаунт!");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"При удалении произошла ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Сохраняет URL трансляции в Config.json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxURL_TextChanged(object sender, EventArgs e)
        {
            config.StreamUrl = TextBoxURL.Text;
            Config.Save();
        }

        /// <summary>
        /// Начать просмотр трансляции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, EventArgs e)
        {
            Stop.Visible = true;
            Stop.Enabled = true;
            Start.Enabled = false;
            isRunning = true;
            BroadcastSeconds = 0;
            BroadcastLabel.Visible = true;
            TimeLabel.Visible = true;
            Thread thread = new Thread(() =>
            {
                var rows = AccountsTable.SelectedRows;
                if (rows.Count > 0)
                {
                    int counter = 0;
                    foreach (DataGridViewRow row in rows)
                    {
                        int i = row.Index;
                        if (isRunning)
                        {
                            AccountData account = config.Accounts[i];
                            try
                            {
                                DriverContainer currContainer = OpenTwitch(account);
                                currContainer.Id = ++counter;
                                ResizeQuality(currContainer.Driver);
                                Thread.Sleep(1000);
                            }
                            catch (Exception ex)
                            {
                                Invoke(new Action(() => { LogMessage($"При попытке запустить аккаунт {account.Login} произошла ошибка: {ex.Message}"); WatchTimer.Stop(); }));
                            }
                            Invoke(new Action(() => WatchTimer.Start()));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Вы не выбрали ни один аккаунт!");
                }
            });
            try
            {
                thread.Start();
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
                throw;
            }
        }

        DriverContainer OpenTwitch(AccountData account)
        {
            ChromeOptions options = new ChromeOptions();
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(chromeDriverService, options);
            DriverContainer container = new DriverContainer(driver, account);
            driversOnline.Add(container);
            try
            {
                driver.Manage().Window.Size = new Size(config.BrowserWidth, config.BrowserHeight);
                driver.Navigate().GoToUrl(StdLoginUrl);
                foreach (var cookie in account.AccountCookies)
                {
                    driver.Manage().Cookies.AddCookie(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, DateTime.Now.AddYears(5)));
                }
                driver.Navigate().GoToUrl(config.StreamUrl);
                return container;
            }
            catch (Exception ex)
            {
                driver.Quit();
                driver = null;
                driversOnline.Remove(container);
                throw ex;
            }
        }

        /// <summary>
        /// Открыть форму настройки рамзеров и положения окон
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browsersWindowSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowSettingForm window = new WindowSettingForm();
            settingsMenu.Enabled = false;
            Enabled = false;
            window.FormClosing += (sender1, e1) => { settingsMenu.Enabled = true; Enabled = true; };
            window.Show();
        }

        /// <summary>
        /// Открыть форму общую форму настройки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genearalSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settingsMenu.Enabled = false;
            Enabled = false;
            settings.FormClosing += (sender1, e1) => { settingsMenu.Enabled = true; Enabled = true; };
            settings.Show();
        }

        private void LogMessage(string message)
        {
            Log.Text += message + Environment.NewLine;
        }

        private void LoginTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (loginDriver == null || loginDriver.Manage().Cookies.AllCookies.Any(c => c.Name == "auth-token"))
                {
                    return;
                }
                else if (loginDriver.Url == StdLoginUrl)
                {
                    if (loginDriver.PageSource.Contains("tw-border-radius-medium tw-flex tw-overflow-hidden"))
                    {
                        if (!loginDriver.PageSource.Contains("id=\"root\""))
                        {
                            return;
                        }
                    }
                }
                PrepareLoginForm();
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message);
            }
        }

        private void PrepareLoginForm()
        {
            string script = "document.querySelector('button[data-a-target=\"login-button\"]').click();" +
                "var el = document.getElementById('root');" +
                "el.parentNode.removeChild(el); " +
                "var el = document.querySelector('div.modal__close-button');" +
                "el.parentNode.removeChild(el); ";
            loginDriver.Navigate().GoToUrl(StdLoginUrl);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)loginDriver;
            LoginTimer.Enabled = true;
            executor.ExecuteScript(script);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (driversOnline.Count > 0)
            {
                for (int i = driversOnline.Count - 1; i >= 0; i--)
                {
                    driversOnline[i].Driver.Quit();
                    driversOnline.RemoveAt(i);
                }
            }
        }

        private void WatchTimer_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                BroadcastSeconds++;
                int broadcastMinutes = BroadcastSeconds / 60;
                TimeLabel.Text = string.Format("{0}:{1:00}", broadcastMinutes, BroadcastSeconds % 60);
                if (config.RefreshTime == 0)
                {
                    return;
                }
                if (BroadcastSeconds % (config.RefreshTime * 60) == 0 && broadcastMinutes > 0)
                {
                    foreach (var driver in driversOnline)
                    {
                        driver.Driver.Navigate().Refresh();
                    }
                }
            }
        }
        void ResizeQuality(IWebDriver driver)
        {
            string script = "document.getElementsByClassName('qa-settings-button')[0].click();" +
                            "document.getElementsByClassName('qa-quality-button')[0].click();" +
                            "document.getElementsByClassName('pl-menu__section pl-menu__section--with-sep')[0].lastChild.firstChild.click();" +
                            "document.querySelector(\"button[class='player-button player-button--volume qa-control-volume']\").click();";
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript(script);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            isRunning = false;

            MainForm_FormClosing(sender, new FormClosingEventArgs(CloseReason.None, true));

            WatchTimer.Stop();
            TimeLabel.Text = "0:00";

            BroadcastLabel.Visible = false;
            TimeLabel.Visible = false;

            Stop.Visible = false;
            Stop.Enabled = false;

            Start.Enabled = true;
        }

        private void contactSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://vk.com/twitchauto");
        }

        private void DonateLink_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://vk.com/twitchauto?w=app5727453_-168595402");
        }

        private string GET(string Url, string Data = null)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url + "?" + Data);
            System.Net.WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
    }

}
