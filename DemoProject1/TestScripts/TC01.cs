using DemoProject1.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.TestScripts
{   [TestClass]
    public class TC01
    {   
        [TestMethod]
        public static void OpenPage()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
        }
    }
}
