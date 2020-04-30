using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace DemoProject1.PageLibrary
{
   public  class LogIn
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[@href='login.php']")]
        private readonly IWebElement SingnInLink;

        [FindsBy(How = How.Name, Using = "userName")]
        private readonly IWebElement userName;


        [FindsBy(How = How.Name, Using = "password")]
        private readonly IWebElement password;

        [FindsBy(How = How.Name, Using = "submit")]
        private readonly IWebElement submitbutton;

        //b[text()=" Thank you for Loggin. "]

        [FindsBy(How = How.XPath, Using = "//b[text()=' Thank you for Loggin. ']")]
        private readonly IWebElement ThankYouLoginMessage;

        [FindsBy(How = How.XPath, Using = "//a[text()='SIGN-OFF']")]
        private readonly IWebElement SignOffButton;

        //a[text()='SIGN-OFF']

        public LogIn(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
            
        }

        public void ClickOnTheSignInLink()
        {
            SingnInLink.Click();

        }
        public void EnterUserNameValue(string value)
        {
            userName.SendKeys(value);
        }

        public void EnterPasswordValue(String value)
        {
            password.SendKeys(value);
        }
        public void ClickOnSubmitButton()
        {
            submitbutton.Click();
        }

        public void ClickOnTheSignOffButton()
        {

            SignOffButton.Click();
        }

    }
}
