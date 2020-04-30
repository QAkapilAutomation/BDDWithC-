using System;
using System.Configuration;
using System.Threading;
using DemoProject1.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DemoProject1.TestScripts
{
    [TestClass]
    public class DropDown
    {
        [TestMethod]
        public void TestMethod1()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            Thread.Sleep(10000);
            DropDownHelper.SelectByValue(By.Name("country"), "AMERICAN SAMOA");
            LinkHelper.ClickLink(By.XPath("//a[text()='Hotels']"));
            
        }
    }
}
