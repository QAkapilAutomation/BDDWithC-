using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.PageLibrary
{
    public class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//button[@class='split-btn']")]
        private readonly IWebElement newButton;

        [FindsBy(How = How.XPath, Using = " //a[contains(text(),'Word Template')]")]
        private  readonly IWebElement wordTemplateButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Script')]")]
        private readonly IWebElement scriptButton;

        [FindsBy(How = How.XPath, Using = " //a[contains(text(),'Email Template')]")]
        private readonly IWebElement emailTemplate;

        [FindsBy(How = How.XPath, Using = "  //a[contains(text(),'Category')]")]
        private readonly IWebElement Category;


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search...']")]
        private readonly IWebElement searchTextBox;

        [FindsBy(How = How.XPath, Using = "//mat-select[@role='listbox']")]
        private readonly IWebElement listBox;

        [FindsBy(How = How.XPath, Using = "//mat-option[@role='option']//span[text()='Script']")]
        private readonly IWebElement listBox_Script;


        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[4]/button/span/i")]
        private readonly IWebElement action_Button;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Edit')]")]
        private readonly IWebElement editButton;

        [FindsBy(How = How.XPath, Using = "//tr/td[1]/span/span")]
        private readonly IWebElement categoryName;



        //tbody/tr[1]/td[4]/button/span/i
        //button[contains(text(),'Edit')]




        //a[contains(text(),'Category')]


        public HomePage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;

        }

        public void hoverToNewButtonAndClickOnWord()
        {
            Actions act = new Actions(ObjectRepository.Driver);
            act.MoveToElement(newButton).Build().Perform();
            LinkHelper.click(wordTemplateButton);

        }
        public void hoverToNewButtonAndClickScript()
        {
            Actions act = new Actions(ObjectRepository.Driver);
            act.MoveToElement(newButton).Build().Perform();
            LinkHelper.click(scriptButton);

        }

        public void hoverToNewButtonAndClickOnEmailTemplate()
        {
            Actions act = new Actions(ObjectRepository.Driver);
            act.MoveToElement(newButton).Build().Perform();
            LinkHelper.click(emailTemplate);

        }

        public void hoverToNewButtonAndClickOnCategory()
        {
            Actions act = new Actions(ObjectRepository.Driver);
            act.MoveToElement(newButton).Build().Perform();
            LinkHelper.click(Category);
        }

        public void searchInSerchBox(string text)
        {
            searchTextBox.Clear();
            TextBoxHelper.Sendkeys(searchTextBox, text);
        }

        public void clickOnListBox()
        {
            listBox.Click();
        }
        public void clickOnScript_List()
        {
            listBox_Script.Click();
        }

        public void clickOnActionButton()
        {
            LinkHelper.click(action_Button);
        }

        public void clickOnEditButton()
        {
            LinkHelper.click(editButton);
        }
        
        public void clickOnCategory()
        {
            categoryName.Click();
        }


    }
}
