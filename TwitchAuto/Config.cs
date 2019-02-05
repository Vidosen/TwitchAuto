using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchAuto
{
    internal class Config
    {
        [JsonProperty]
        public string Lang { get; set; }
        [JsonProperty]
        public int RefreshTime { get; set; } = 2;
        [JsonProperty]
        public string StreamUrl { get; set; } = "https://www.twitch.tv/esl_csgo";
        public List<AccountData> Accounts { get; set; }

        [JsonProperty]
        public int BrowserHeight { get; set; } = 405;
        [JsonProperty]
        public int BrowserWidth { get; set; } = 720;
        [JsonProperty]
        public int BrowserLeft { get; set; } = 20;
        [JsonProperty]
        public int BrowserTop { get; set; } = 0;


        private static Config _config { get; set; }

        public static string GetExecuteDir()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)+'\\';
        }
        public static Config GetConfig(bool forceLoad = false)
        {
            if (_config != null && !forceLoad)
            {
                return _config;
            }

            string file = GetExecuteDir() + "config.json";

            if (!File.Exists(file))
            {
                _config = _generateNewConfig();
                Save();
                return _config;
            }
                string configContents = File.ReadAllText(file);
                _config = JsonConvert.DeserializeObject<Config>(configContents);
                return _config;

        }
        private static Config _generateNewConfig()
        {
            Config newConfig = new Config
            {
                Accounts = new List<AccountData>(),
            };
            if (Thread.CurrentThread.CurrentUICulture.Name == "ru-RU")
            {
                newConfig.Lang = "ru-RU";
            }
            else
            {
                newConfig.Lang = "en-US";
            }
            return newConfig;
        }
        public static void Save()
        {
            if (_config == null)
            {
                throw new Exception("The config haven't been created.");
            }
            string fileContent = JsonConvert.SerializeObject(_config);
            File.WriteAllText(GetExecuteDir() + "config.json", fileContent);
        }
    }
}
