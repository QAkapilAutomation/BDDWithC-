using DemoProject1.Setting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using log4net;

namespace DemoProject1.ComponentHelper
{
    public class GenericHelper1
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(GenericHelper));
        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                Logger.Info(" Waiting for Element : " + locator);
                return false;
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }
        private static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(1));
            //ObjectRepository.Driver.Manage().Timeouts().ImplicitWait(TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            Logger.Info(" Wait Object Created ");
            return wait;
        }
        public static bool IsElemetPresent(By locator)
        {
            try
            {
                Logger.Info(" Checking for the element " + locator);
                 return ObjectRepository.Driver.FindElements(locator).Count == 1;
                
            }
            catch (Exception)
            {
                return false;
            }

        }


        public static IWebElement GetElement(By locator)
        {
            if (IsElemetPresent(locator))
               
            return ObjectRepository.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }


        public static bool WaitForWebElement(By locator, TimeSpan timeout)
        {
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            Logger.Info(" Setting the Explicit wait Configured value ");
            return flag;
        }

        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timeout)
        {
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementInPageFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait=(TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout()));
            Logger.Info(" Setting the Explicit wait Configured value ");
            return flag;
        }



    }
}

