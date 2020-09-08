using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
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

        public void verifySuccessMessage()
        {
            Thread.Sleep(2000);
            String actualMessage=SuccessMessage.Text;
            Console.WriteLine(actualMessage);
           //return AssertHelper.AreEqual(actualMessage, "Scripts");
           Assert.AreEqual("Script has been saved.", actualMessage);
            
        }

        public void mergeField()
        {

             //Actions builder = new Actions(driver.Browser.Instance);
            Actions action = new Actions(ObjectRepository.Driver);
            Thread.Sleep(2000);
            IWebElement drag = ObjectRepository.Driver.FindElement(By.XPath("//div[text()=' User.User_First_Name ']"));
            Thread.Sleep(2000);
            IWebElement drop= ObjectRepository.Driver.FindElement(By.XPath("//div[@data-placeholder='Compose you script ...']//p"));

            //IAction dragAndDrop = action.ClickAndHold(drag)
            //    .MoveByOffset(-1, -1)
            //    .MoveToElement(drop)
            //    .Release(drop)
            //    .Build();
            //Thread.Sleep(2000);
            //dragAndDrop.Perform();
            action.ClickAndHold(drag)
            .MoveByOffset(-1, -1) 
            .MoveToElement(drop, drop.Location.X + drop.Size.Width / 2, drop.Location.Y + drop.Size.Height / 2)
            .Release(drop)
            .Build()
            .Perform();
            Thread.Sleep(2000);



        }


    }
}
