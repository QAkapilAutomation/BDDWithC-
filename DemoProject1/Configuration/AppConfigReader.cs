using DemoProject1.Interfaces;
using DemoProject1.Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType? GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetElementLoadTimeout()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.ElementLoadTimeout);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetPageTimeOutTime()
        {
            string timeout = ConfigurationManager.AppSettings.Get(AppConfigKeys.PageLoadTimeOut);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);

        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        
    }
}
