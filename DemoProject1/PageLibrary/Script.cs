using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace DemoProject1.PageLibrary
{
    public class Script :WordTemplate
    {
        private IWebDriver driver;

        // Declaring all the web element for the script template page 

        [FindsBy(How = How.XPath, Using = "//span[text()='Script has been saved.']")]
        private readonly IWebElement SuccessMessage;

        [FindsBy(How = How.XPath, Using = "//span[text()='Update']")]
        private readonly IWebElement updateButton;



        //span[text()='Update']


        public Script(IWebDriver _driver) : base(_driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
             
        }

        public Boolean verifyIamOnScriptTemplatePage()
        {
            Boolean status = GenericHelper.IsElemetPresent(By.XPath("//input[@name='templateName']"));
            return status;
        }

        public Boolean verifySuccessMessage()
        {
            //    Thread.Sleep(2000);
            //    String actualMessage=SuccessMessage.Text;
            //    Console.WriteLine(actualMessage);
            //   //return AssertHelper.AreEqual(actualMessage, "Scripts");
            //   Assert.AreEqual("Script has been saved.", actualMessage);
            return GenericHelper.IsElemetPresent(By.XPath("//span[text()='Script has been saved.']"));
            
        }

        public void mergeField()
        {
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//div[text()=' User.User_First_Name ']"));
            Thread.Sleep(2000);
            ele.Click();
            Thread.Sleep(2000);
            SikuliHelper.ClickOnImage(@"D:\sk\image1.PNG");
            for(int i=1; i <= 5; i++)
            {
                ele.Click();
            }
        
        }


    }
}
