using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
   public  class DropDownHelper
    {
        private static SelectElement select;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(DropDownHelper));

        public static void SelectByIndex(By locator, int index)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByIndex(index);
            Logger.Info("Select By Index" +index);
        }

        public static void SelectByValue(By locator, string value)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByValue(value);
            Logger.Info("Select By value" + value);
        }
           
        public static IList<string> GetAllItemFromDropDown(By locator)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            Logger.Info("Get all item from dropdown" + select);
            return select.Options.Select((x) => x.Text).ToList();


        }

    }
}
