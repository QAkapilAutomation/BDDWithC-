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
            TextBoxHelper.Sendkeys(searchTextBox, text);
        }

    }
}
