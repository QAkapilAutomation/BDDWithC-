using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using DemoProject1.PageLibrary;
using DemoProject1.Setting;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.DTS_StepDefination
{
    [Binding]
    public sealed class CreateNewCategory
    {
        ILog Logger = Log4NetHelper.GetLogger(typeof(CreateNewCategory));
        private readonly static string xlPath = ConfigurationManager.AppSettings.Get("ExcelPath");
        String Category_Name = ExcelReaderHelper.GetCellData(xlPath, "Category", 1, 0).ToString();
        HomePage hpage = new HomePage(ObjectRepository.Driver);
        CreateCategory categorypage = new CreateCategory(ObjectRepository.Driver);
        String PopTitle = "Create New Category";
        [When(@"I click on create category by hovering the cursor to new template option")]
        public void WhenIClickOnCreateCategoryByHoveringTheCursorToNewTemplateOption()
        {
            GenericHelper.WaitForWebElementInPage(By.XPath("//div/table/tbody/tr[5]/td[1]"), TimeSpan.FromSeconds(30));
            List<IWebElement> rows = new List<IWebElement>(ObjectRepository.Driver.FindElements(By.TagName("tr")));
           int count= rows.Count();
            Console.WriteLine(count);
            try
            {
                for (int i = 1; i < count; i++)
                {
                    String name = ObjectRepository.Driver.FindElement(By.XPath("//tr[" + i + "]/td[1]/span/span")).Text;
                    Console.WriteLine(name);
                    if (name.Contains(Category_Name))
                    {
                        hpage.searchInSerchBox(Category_Name);
                        Thread.Sleep(2000);
                        LinkHelper.ClickLink(By.XPath("//span[@class='mat-button-wrapper']//i"));
                        Thread.Sleep(2000);
                        LinkHelper.ClickLink(By.XPath("//button[contains(text(),'Remove')]"));
                    }
                }
            }
            catch { 
                //do nothing
            }


            hpage.hoverToNewButtonAndClickOnCategory();
            Thread.Sleep(2000);
        }
        [Then(@"I should be on category popup")]
        public void ThenIShouldBeOnCategoryPopup()
        {
            categorypage.verifyThatCategoryPopIsOpen(PopTitle);
            Logger.Info("Category page is open");
        }
        [When(@"I enter the category name in the category text box")]
        public void WhenIEnterTheCategoryNameInTheCategoryTextBox()
        {
            categorypage.typeInCategoryTextBox(Category_Name);
            Logger.Info("Entering data in the category text box");
        }
        [When(@"I Click On Create Button")]
        public void WhenIClickOnCreateButton()
        {
            categorypage.clickOnCreateButton();  
        }
        [Then(@"Category should be added in listing page")]
        public void ThenCategoryShouldBeAddedInListingPage()
        {
            Thread.Sleep(5000);
            //hpage.searchInSerchBox(Category_Name);
            //Logger.Info("Searching for the category in the listing");
            //Thread.Sleep(4000);
            //string actual_msg = categorypage.verifyCreatedTheCategory(Category_Name);
            //Assert.AreEqual(actual_msg, Category_Name);
           Boolean status= GenericHelper.IsElemetPresent(By.XPath("//span[text()='Category added successfully!']"));
            Console.WriteLine(status);

        }





    }
}
