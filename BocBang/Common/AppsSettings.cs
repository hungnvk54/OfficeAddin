using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using BocBang.DataMessage;

namespace BocBang
{
    class AppsSettings
    {
        private AppsSettings()
        {
            // Disable public create
            //ConfigurationManager
            ReadingAllConfigure();
            this.UserInfo = null;
            this.isLogin = false;
        }

        private static AppsSettings mInstance = null;
        public static AppsSettings GetInstance()
        {
            if (mInstance == null)
            {
                mInstance = new AppsSettings();
            }
            return mInstance;
        }

        public void SaveConfigure()
        {
            /*AddUpdateAppSettings("ws", this.WebsocketUrl);
            AddUpdateAppSettings("mic", this.DefaultMic);
            AddUpdateAppSettings("audiolength", this.DefaultAudioLength);
            AddUpdateAppSettings("api", this.ApiUrl);
            AddUpdateAppSettings("datadir", this.DataDir); */

            Settings.Default.api = this.ApiUrl;
            Settings.Default.datadir = this.DataDir;
            Settings.Default.Save();
        }

        private void ReadingAllConfigure()
        {
            this.ApiUrl = Settings.Default.api; // ReadSetting("api", "https://127.0.0.1/bocbang");
            this.DataDir = Settings.Default.datadir; // ReadSetting("datadir", "");
            if (string.IsNullOrEmpty(this.DataDir))
            {
                this.DataDir = Directory.GetCurrentDirectory();
            }
        }
        
        private string ReadSetting(string key, string defaultValue)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? defaultValue;
                Console.WriteLine(result);
                return result;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return defaultValue;
            }
        }

        void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Debug.WriteLine("Error writing app settings");
            }
        }
        public string ApiUrl
        {
            get;set;
        }

        public UserInfoMessage UserInfo
        {
            get;set;
        }

        public string DataDir
        {
            get; set;
        }

        public Boolean isLogin
        {
            get;set;
        }

        public SessionsEntity Session
        {
            get;set;
        }

        public string DocumentName
        {
            get;set;
        }

        public Boolean IsRepresentativeSplit
        {
            get;set;
        }

        public Boolean IsAddPageNumber
        {
            get;set;
        }
    }
}
