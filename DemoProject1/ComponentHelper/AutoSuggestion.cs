using DemoProject1.Setting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
    public class AutoSuggestion
    {
        private static IWebElement element;
        public static void SupplyIntialString(By locator, string text)
        {
            element = GenericHelper.GetElement(locator);
            element.SendKeys(text);
        }


    }
}
