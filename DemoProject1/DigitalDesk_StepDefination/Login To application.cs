using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using DemoProject1.Setting;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.DigitalDesk_StepDefination
{
    [Binding]
    public sealed class Login_To_application
    {
        // Creating object for logger class 
        ILog Logger = Log4NetHelper.GetLogger(typeof(Login_To_application));
        //Creating object for excel reader
        private readonly static string xlPath = ConfigurationManager.AppSettings.Get("ExcelPath");
        //Fetching user name and password from excel
        String User_Name = ExcelReaderHelper.GetCellData(xlPath, "Login", 1, 0).ToString();
        String Password = ExcelReaderHelper.GetCellData(xlPath, "Login", 1, 1).ToString();

        String Invalid_UserName = ExcelReaderHelper.GetCellData(xlPath, "Login", 2, 0).ToString();
        String Invalid_Password = ExcelReaderHelper.GetCellData(xlPath, "Login", 2, 1).ToString();

        [Given(@"I am at login page")]
        public void GivenIAmAtLoginPage()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            Thread.Sleep(2000);
        }

        [When(@"User enter valid userid and password and click on logon button")]
        public void WhenUserEnterValidUseridAndPasswordAndClickOnLogonButton()
        {
            TextBoxHelper.TypeInTexBox(By.Name("email"), User_Name);
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.Name("password"), Password);
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.Name("submit"));
        }

        [Then(@"User should be at the home page")]
        public void ThenUserShouldBeAtTheHomePage()
        {
            GenericHelper.WaitForWebElement(By.XPath("//div[text()='Home Page']"), TimeSpan.FromSeconds(60));
            Boolean status =GenericHelper.IsElemetPresent(By.XPath("//div[text()='Home Page']"));
            if (status)
            {
                Logger.Info("User is at home page");
            }
            else
            {
                Logger.Info("User is not at home page");
            }

            Thread.Sleep(4000);
        }

        [When(@"the User inputs wrong credentials")]
        public void WhenTheUserInputsWrongCredentials()
        {
            TextBoxHelper.TypeInTexBox(By.Name("email"), Invalid_UserName);
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.Name("password"), Invalid_Password);
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.Name("submit"));
        }

        [Then(@"the system should not allow User to log-in with error message")]
        public void ThenTheSystemShouldNotAllowUserToLog_InWithErrorMessage()
        {
            GenericHelper.WaitForWebElement(By.XPath("//span[text()='Wrong email or password.']"), TimeSpan.FromSeconds(60));
            Thread.Sleep(2000);
            String message = ObjectRepository.Driver.FindElement(By.XPath("//span[text()='Wrong email or password.']")).Text;
            Logger.Info(message);
            Assert.AreEqual("WRONG EMAIL OR PASSWORD.", message);
        }


    }
}
