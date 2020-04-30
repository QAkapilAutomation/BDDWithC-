using System;
using System.Configuration;
using DemoProject1.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DemoProject1.TestScripts
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            String Title =WindowHelper.GetTitle();
            DropDownHelper.SelectByValue(By.Name("country"), "AMERICAN SAMOA");
            LinkHelper.ClickLink(By.XPath("//a[text()='Hotls']"));
            //TakeScreenShots.TakeScreenShot1();
            Console.WriteLine(Title);
        }
    }
}
