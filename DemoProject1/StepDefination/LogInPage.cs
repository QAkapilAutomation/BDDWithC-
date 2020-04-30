using DemoProject1.ComponentHelper;
using DemoProject1.PageLibrary;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoProject1.StepDefination
{
    [Binding]
    public sealed class LogInPage
    {
        LogIn lpage = new LogIn(ObjectRepository.Driver);

        [When(@"User click on the signon link")]
        public void WhenUserClickOnTheSignonLink()
        {
            lpage.ClickOnTheSignInLink();
            
        }

        [Then(@"User should be at login page")]
        public void ThenUserShouldBeAtLoginPage()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.Name("userName")));

        }

        [When(@"User Provide UserName,Password and click on submit button")]
        public void WhenUserProvideUserNamePasswordAndClickOnSubmitButton(Table table)
        {
            foreach (var row in table.Rows)
            {
                lpage.EnterUserNameValue(row["UserName"]);
                lpage.EnterPasswordValue(row["Password"]);
                lpage.ClickOnSubmitButton();

            }

        }
        [Then(@"User Should be at loged in to webpage")]
        public void ThenUserShouldBeAtLogedInToWebpage()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.XPath("//b[text()=' Thank you for Loggin. ']")));
            
        }
        







    }
}
