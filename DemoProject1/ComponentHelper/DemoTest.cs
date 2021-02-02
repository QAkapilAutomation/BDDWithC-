using DemoProject1.Setting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
   public  class DemoTest
    {

        public static void JavascriptDragAndDrop(IWebElement source, IWebElement target)
        {
            string script = System.IO.File.ReadAllText("C:\\Users\\KAPIL\\Desktop\\Scroll.js");
            script += "simulateHTML5DragAndDrop(arguments[0], arguments[1])";
            IJavaScriptExecutor executor = (IJavaScriptExecutor)ObjectRepository.Driver;
            executor.ExecuteScript(script, source, target);
        }
    }
}
