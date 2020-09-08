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
    public sealed class VerifyUserOnTheScheduleListPage
    {
        HomePage hpage = new HomePage(ObjectRepository.Driver);
        [Given(@"User is at the homepage")]
        public void GivenUserIsAtTheHomepage()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
        }

        [When(@"User click on the manage Schedules link")]


        [Then(@"user should be at reporter schedule page")]
        public void ThenUserShouldBeAtReporterSchedulePage()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.XPath("//p[text()='Report Scheduler']")));
        }
    }
}
