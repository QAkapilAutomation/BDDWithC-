using System;
using System.Configuration;
using DemoProject1.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DemoProject1.TestScripts
{
    [TestClass]
    public class TextBoxTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            TextBoxHelper.TypeInTexBox(By.Name("q"), "Test");
            TextBoxHelper.ClearText(By.Name("q"));
        }
    }
}
