using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
   public  class ButtonHelper
    {
        private static IWebElement element;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(ButtonHelper));
        public static void ClickOnButton(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
            Logger.Info(" Button Click @ " + locator);
        }

        public static bool IsButtonEnable(By locator)
        {
            element = GenericHelper.GetElement(locator);
            Logger.Info(" Checking Is Button Enabled ");
            return element.Enabled;
        }
        public static string GetButtonText(By locator)
        {
            element = GenericHelper.GetElement(locator);

            if (element.GetAttribute("value") == null)
                return string.Empty;
            return element.GetAttribute("value");
            
        }

    }
}
