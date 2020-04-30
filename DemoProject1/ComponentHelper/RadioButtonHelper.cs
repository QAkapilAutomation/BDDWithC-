using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
    public class RadioButtonHelper
    {
        private static IWebElement element;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(RadioButtonHelper));

        public static void ClickRadioButton(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
            Logger.Info("Click on the radio button" + element);
        }
        public static bool isRadioButtonSelected(By locator)
        {
            element = GenericHelper.GetElement(locator);
            string flag = element.GetAttribute("checked");
            Logger.Info("Checked the radio button" + flag);
            if (flag == null)
                return false;
            else
                return flag.Equals("true") || false.Equals("checked");
        }

    }
}
