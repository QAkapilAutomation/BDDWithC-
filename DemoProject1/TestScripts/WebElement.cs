using System;
using System.Collections.ObjectModel;
using System.Configuration;
using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace DemoProject1.TestScripts
{
    [TestClass]
    public class WebElement
    {
        [TestMethod]
        public void GetallWebElement()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            try
            {
                ReadOnlyCollection<IWebElement> col = ObjectRepository.Driver.FindElements(By.TagName("input"));
                Console.WriteLine("Size : {0}", col.Count);
               // var a = ObjectRepository.Driver.FindElement(By.Name("showmybugslink")).GetAttribute("checked");
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
