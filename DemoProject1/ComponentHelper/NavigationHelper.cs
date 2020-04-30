using DemoProject1.Setting;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
    public class NavigationHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(NavigationHelper));

        public static void NavigateToUrl(String url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
            Logger.Info(" Navigate To Page " + url);
        }
    }
}
