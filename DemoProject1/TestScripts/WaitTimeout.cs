using System;
using System.Configuration;
using System.Threading;
using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace DemoProject1.TestScripts
{
    [TestClass]
    public class WaitTimeout
    {
        [TestMethod]
        public void TestMethod1()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            Thread.Sleep(5000);
            TextBoxHelper.TypeInTexBox(By.Name("firstName"),"kapil");
            TextBoxHelper.TypeInTexBox(By.Name("lastName"), "Singh");
            TextBoxHelper.TypeInTexBox(By.Name("phone"), "8527515427");
            TakeScreenShots.TakeScreenShot1("name");

            //WebDriverWait wait  = new WebDriverWait(ObjectRepository.Driver, 100);
            //WebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("submit")));

            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout()));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            ObjectRepository.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);

        }
    }
}
