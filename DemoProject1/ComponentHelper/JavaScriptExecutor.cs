﻿using DemoProject1.BaseClass;
using DemoProject1.Setting;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
    public class JavaScriptExecutor
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(JavaScriptExecutor));
        public static object ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            Logger.Info($" Execute Script @ {script}");
            return executor.ExecuteScript(script);

        }

        public static object ExecuteScript(string script, params object[] args)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script, args);
        }

        public static void ScrollToAndClick(IWebElement element)
        {
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static void ScrollToAndClick(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(4000);
            element.Click();
        }
        public static void ScrollToAndClickX(By locator)
        {
            IWebElement element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.X + ")");
            Thread.Sleep(3000);
            element.Click();
        }
        public static void JsClick(By locator)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)ObjectRepository.Driver;
            executor.ExecuteScript("arguments[0].click();", locator);
        }

        public static void SelectByJs( IWebElement element, String dateVal)
        {
            IJavaScriptExecutor js = ((IJavaScriptExecutor)ObjectRepository.Driver);
            js.ExecuteScript("arguments[0].setAttribute('value','" + dateVal + "');", element);

        }

    }
}
