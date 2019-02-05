using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAuto
{
    public class AccountData
    {
        public AccountData(string login, List<System.Net.Cookie> cookies = null)
        {
            Login = login;
            AccountCookies = cookies;
            Uri uri = new Uri("https://www.twitch.tv/");
        }

        [JsonProperty]
        public string Login { get; set; }
        [JsonProperty]
        public List<System.Net.Cookie> AccountCookies { get; set; }

    }
    public class DriverContainer
    {
        public DriverContainer()
        {
        }

        public DriverContainer(IWebDriver driver, AccountData account)
        {
            Driver = driver;
            Account = account;

        }

        public IWebDriver Driver { get; set; }
        public AccountData Account { get; set; }
        public int Id { get; set; }


    }
}
