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
    public sealed class DemoTest
    {
        Registration rg = new Registration(ObjectRepository.Driver);


        [Given(@"User Is at Homepage")]
        public void GivenUserIsAtHomepage()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
        }


        [When(@"User Provide the ""(.*)"", ""(.*)"",""(.*)"" And Click On the Submit Button")]
        public void WhenUserProvideTheAndClickOnTheSubmitButton(string FirstName, string LastName, string PhoneNumber)
        {
            rg.EnterValueInFirstNameEditBox(FirstName);
            rg.EnterValueInLastNameEditBox(LastName);
            rg.EnterValueInPhoneNumberEditBox(PhoneNumber);
            rg.ClickOnTheSubmitButton();
        }


        [Then(@"User should be At Registration Page")]
        public void ThenUserShouldBeAtRegistrationPage()
        {
            Assert.AreEqual("Register: Mercury Tours", rg.Title);
        }

    }
}
