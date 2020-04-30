using DemoProject1.ComponentHelper;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DemoProject1.Setting;
using SeleniumExtras.PageObjects;

namespace DemoProject1.PageLibrary
{
    public class Registration
    {
        private IWebDriver driver;

        #region WebElement
        [FindsBy(How = How.Name, Using = "firstName")]
        private readonly IWebElement FirstNaame;

        [FindsBy(How = How.Name, Using = "lastName")]
        private readonly IWebElement LastName;

        [FindsBy(How = How.Name, Using = "phone")]
        private readonly IWebElement PhoneNumber;

        [FindsBy(How = How.Name, Using = "submit")]
        private readonly IWebElement SubmitButton;
        #endregion

        public Registration(IWebDriver _driver)
        {

            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
        }

        #region Action

        public void EnterValueInFirstNameEditBox(String value)
        {
            FirstNaame.SendKeys(value);
        }
        public void EnterValueInLastNameEditBox(String value)
        {
            LastName.SendKeys(value);
        }
        public void EnterValueInPhoneNumberEditBox(String value)
        {
            PhoneNumber.SendKeys(value);
        }

        public void ClickOnTheSubmitButton()
        {
            SubmitButton.Click();
        }
        #endregion

        public string Title
        {
            get { return driver.Title; }
        }

    }
}
