using DemoProject1.ComponentHelper;
using DemoProject1.PageLibrary;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoProject1.StepDefination
{
    [Binding]
    public sealed class FindAflight
    {
        BookAFlight bFlight = new BookAFlight(ObjectRepository.Driver);

        [When(@"User Click On the flight link")]
        public void WhenUserClickOnTheFlightLink()
        {
            bFlight.clickOnFlightLink();
        }

        [Then(@"User Should be at Book a flight page")]
        public void ThenUserShouldBeAtBookAFlightPage()
        {
            Assert.IsTrue(GenericHelper.IsElemetPresent(By.Name("passCount")));

        }
        [When(@"User click on the Oneway radio button, select passengers dropdown, click on the Service class radio button and click on the findflight button")]
        public void WhenUserClickOnTheOnewayRadioButtonSelectPassengersDropdownClickOnTheServiceClassRadioButtonAndClickOnTheFindflightButton()
        {
            bFlight.SelectTripTypeRadioButton();
            bFlight.SelectPassenger();
            bFlight.SlelectServiceTypeRadioButton();
            bFlight.ClickOnTheFindFlightButton();

        }
        [Then(@"User should be at find flights page")]
        public void ThenUserShouldBeAtFindFlightsPage()
        {

            Assert.AreEqual("Find a Flight: Mercury Tours:", bFlight.Title);
        }


    }
}
