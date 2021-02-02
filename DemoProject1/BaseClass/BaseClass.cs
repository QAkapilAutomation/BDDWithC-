using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DemoProject1.ComponentHelper;
using DemoProject1.Configuration;
using DemoProject1.CustomException;
using DemoProject1.Setting;
using Google.Protobuf.WellKnownTypes;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DemoProject1.BaseClass
{
    //[TestClass]
    [Binding]
    public class BaseClass
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(BaseClass));
        

        private static FirefoxProfile GetFirefoxptions()
        {
            FirefoxProfile profile = new FirefoxProfile();
            FirefoxProfileManager manager = new FirefoxProfileManager();
            profile = manager.GetProfile("default");
            return profile;
        }
        private static ChromeOptions GetChromeOptions()
        {

            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            option.AddUserProfilePreference("disable-popup-blocking", "true");
            option.AddArguments("--disable-notifications");
            option.PageLoadStrategy = PageLoadStrategy.None;
            return option;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            return options;
        }
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }

        //[BeforeFeature()]
        [BeforeScenario]
        //[AssemblyInitialize]
        public static void InitWebdriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();
            //Reporter.GetReportManager();
            //Reporter.AddTestCaseMetadataToHtmlReport(tc);
            String browserName = ConfigurationManager.AppSettings.Get("Browser");

            switch (browserName)
            {
                case "Firefox":
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;

                case "Chrome":
                    ObjectRepository.Driver = GetChromeDriver();
                    Logger.Info(" Using Chrome Driver  ");
                    break;

                case "IExplorer":
                    ObjectRepository.Driver = GetIEDriver();
                    break;



                default:
                    throw new NoSutiableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString());
            }
            ObjectRepository.Driver.Manage()
                .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageTimeOutTime());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            BrowserHelper.BrowserMaximize();
            

        }



       // [TestCleanup]
        //[AssemblyCleanup]
        [AfterScenario()]
        public static void TearDown()
        {
           
            if (ObjectRepository.Driver!=null)
            {
                
                ObjectRepository.Driver.Quit();
                //ObjectRepository.Driver.Close();
            }
            Logger.Info(" Stopping the Driver  ");
        }
    }

}

