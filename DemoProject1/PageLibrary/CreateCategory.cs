using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.PageLibrary
{
   public class CreateCategory
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@name='folderName']")]
        private readonly IWebElement folderName;

        [FindsBy(How = How.XPath, Using = " //span[text()='Create New Category']")]
        private readonly IWebElement createNewCategory;

        [FindsBy(How = How.XPath, Using = " //span[text()='Create']")]
        private readonly IWebElement createButton;

        public CreateCategory(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;

        }

        public void verifyThatCategoryPopIsOpen(String exceptedmsg)
        {
            string text = createNewCategory.Text;
            Assert.AreEqual(text, exceptedmsg);
        }

        public void typeInCategoryTextBox(String text)
        {
            TextBoxHelper.Sendkeys(folderName, text);
        }

        public void clickOnCreateButton()
        {
           
            createButton.Click();
        }

        public string verifyCreatedTheCategory(String categoryName)
        {
            string beforexpath = "//span[text()='";
            String Afterxpath = "']";
            String actualXpath = beforexpath + categoryName + Afterxpath;
            String serach = ObjectRepository.Driver.FindElement(By.XPath(actualXpath)).Text.ToString();
            return serach;




        }
    }
}
