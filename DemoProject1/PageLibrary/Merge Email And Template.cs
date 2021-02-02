using DemoProject1.ComponentHelper;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject1.PageLibrary
{
   public  class Merge_Email_And_Template
    {

        private IWebDriver driver;

        private static readonly ILog Logger = Log4NetHelper.GetLogger(typeof(Merge_Email_And_Template));

        // Declaring all the web element for the Merge_Email_And_Template page 

        [FindsBy(How = How.XPath, Using = "//button[text()=' Name ']")]
        private readonly IWebElement nameColumn;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Group ']")]
        private readonly IWebElement groupColumn;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Updated On ']")]
        private readonly IWebElement updateOnColumn;

        [FindsBy(How = How.XPath, Using = "//th[text()=' Action ']")]
        private readonly IWebElement actionColumn;

        [FindsBy(How = How.XPath, Using = "//span[text()='Email Template']")]
        private readonly IWebElement emailTemplate;

        [FindsBy(How = How.XPath, Using = "(//mat-select)")]
        private readonly IWebElement option;

        [FindsBy(How = How.XPath, Using = "//tr[1]/td[1]/span/span")]
        private readonly IWebElement firstColoumn;



        public Merge_Email_And_Template(IWebDriver _driver)
        {
           PageFactory.InitElements(_driver, this);
            this.driver = _driver;

        }

        public void selectEmailTemplateFromDropDown()
        {
            Thread.Sleep(2000);
            LinkHelper.click(option);
            Thread.Sleep(2000);
            LinkHelper.click(emailTemplate);
        }
        public Boolean verifyThatEmailTemplateAppear()
        {
           return GenericHelper.IsElemetPresent(By.XPath("//div/table/tbody/tr[5]/td[1]")) ;
        }

        public void verifyShortingOnName()
        {
            string beforeText=firstColoumn.Text;
            Logger.Info("value of beforeText="  +beforeText);
            Thread.Sleep(1000);
            nameColumn.Click();
            Thread.Sleep(1000);
            string afterText = firstColoumn.Text;
            Logger.Info("value of afterText="  +afterText);
            if (beforeText != afterText)
            {
                Logger.Info("Shorting is working ");
            }
            else {
                Logger.Info("Shorting is not working ");
            }
        }

        
    }
}
