using DemoProject1.ComponentHelper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.PageLibrary
{
    public class BookAFlight
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.XPath, Using = "//a[text()='Flights']")]
        private readonly IWebElement FlightLink;

        [FindsBy(How = How.XPath, Using = "//input[@value='oneway']")]
        private readonly IWebElement TripType;

        [FindsBy(How = How.Name, Using = "passCount")]
        private  IWebElement PassengerType;

        [FindsBy(How = How.XPath, Using = "//input[@value='Coach']")]
        private readonly IWebElement ServiceClassRadioButton;


        [FindsBy(How = How.Name, Using = "findFlights")]
        private readonly IWebElement FindFlightButton;



        #endregion

        public BookAFlight(IWebDriver _driver)
        {

            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
        }

        #region Action

        public void clickOnFlightLink()
        {
            FlightLink.Click();
        }
        public void SelectTripTypeRadioButton()
        {
            RadioButtonHelper.isRadioButtonSelected(By.XPath("//input[@value='oneway']"));
            RadioButtonHelper.ClickRadioButton(By.XPath("//input[@value='oneway']"));
        }
        public void SelectPassenger()
        {
            DropDownHelper.SelectByValue(By.Name("passCount"),"2");
        }

        public void SlelectServiceTypeRadioButton()
        {
            RadioButtonHelper.isRadioButtonSelected(By.XPath("//input[@value='Coach']"));
            RadioButtonHelper.ClickRadioButton(By.XPath("//input[@value='Coach']"));
        }

        public void ClickOnTheFindFlightButton()
        {
            FindFlightButton.Click();
        }
        #endregion

        public string Title
        {
            get { return driver.Title; }
        }

    }
}

