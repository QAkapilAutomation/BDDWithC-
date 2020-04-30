using System;
using System.Configuration;
using DemoProject1.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DemoProject1.TestScripts
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            ButtonHelper.GetButtonText(By.XPath("(//input[@aria-label='Google Search'])[2]"));
            ButtonHelper.IsButtonEnable(By.XPath("(//input[@aria-label='Google Search'])[2]"));
            ButtonHelper.ClickOnButton(By.XPath("(//input[@aria-label='Google Search'])[2]"));
        }
    }
}
