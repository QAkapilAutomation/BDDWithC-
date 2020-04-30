using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
    public class TextBoxHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(TextBoxHelper));
        private static IWebElement element;
        public static void TypeInTexBox(By loacator, string text)
        {
            element = GenericHelper.GetElement(loacator);
            element.SendKeys(text);
            Logger.Info("Type in the textbox" +text);

        }
        public static void ClearText(By loacator)
        {
            element = GenericHelper.GetElement(loacator);
            element.Clear();
            Logger.Info("Clear in the textbox" );


        }
    }
}
