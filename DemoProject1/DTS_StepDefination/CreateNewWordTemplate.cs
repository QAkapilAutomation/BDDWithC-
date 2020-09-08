using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium.Interactions;
using DemoProject1.Setting;
using System.Configuration;
using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using System.Threading;
using OpenQA.Selenium;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using DemoProject1.PageLibrary;

namespace DemoProject1.DTS_StepDefination
{
    [Binding]
    public sealed class CreateNewWordTemplate
    { 
        // Creating object of word template class
        WordTemplate wTemplate = new WordTemplate(ObjectRepository.Driver);

        HomePage hPage= new HomePage(ObjectRepository.Driver);

        private readonly Actions act = new Actions(ObjectRepository.Driver);

        private static readonly string xlPath = ConfigurationManager.AppSettings.Get("ExcelPath");

        log4net.ILog Logger = Log4NetHelper.GetLogger(typeof(CreateNewWordTemplate));

        //Fetching the data from Excel===============================================

        String NameWordTemplate = ExcelReaderHelper.GetCellData(xlPath, "WordTemplate", 1, 0).ToString()+ DateTime.Now.ToString("MMdd_HHmm");
        string group = ExcelReaderHelper.GetCellData(xlPath, "WordTemplate", 1, 1).ToString();
        string description = ExcelReaderHelper.GetCellData(xlPath, "WordTemplate", 1, 2).ToString();

        //-------------------Create word template--------------------

        [When(@"I click on create Word by hovering the cursor to new template option")]
        public void WhenIClickOnCreateWordByHoveringTheCursorToNewTemplateOption()
        {
            hPage.hoverToNewButtonAndClickOnWord();
        }
        [Then(@"I should be on Word template page")]
        public void ThenIShouldBeOnWordTemplatePage()
        {
            //ScenarioContext.Current.Pending();
        }


        [When(@"I enter the required information in word Template field")]
        public void WhenIEnterTheRequiredInformationInWordTemplateField()
        {
            Thread.Sleep(2000);
            wTemplate.typeinTemplateName(NameWordTemplate);
           // wTemplate.typeinGroupName(group);
            wTemplate.typeindescription(description);
           

        }
        [When(@"I attach  File using Attach option")]
        public void WhenIAttachFileUsingAttachOption()
        {
            wTemplate.AttachFile();
        }


        //-------------------Delete word template--------------------
        [When(@"I search the same word template by name on home page")]
        
        
        
        
        
        public void WhenISearchTheSameWordTemplateByNameOnHomePage()
        {
            Thread.Sleep(3000);

            LinkHelper.ClickLink(By.XPath("//span[contains(text(),'Email Template')]"));
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("//span[contains(text(),'Word Template')]"));
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("(//mat-select)[2]"));
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("//span[@class='mat-option-text'][contains(text(),'Name')]"));
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Search in Template...']"), NameWordTemplate);
        }
        [Then(@"The word template should be present")]
        public void ThenTheWordTemplateShouldBePresent()
        {
            Thread.Sleep(3000);
            IWebElement VisibleNameElement = GenericHelper.WaitForWebElementInPage(By.XPath("//html[1]//body[1]//app-root[1]//app-template-list[1]//div[2]//div[1]//table[1]//tbody[1]//tr[1]//td[1]"), TimeSpan.FromSeconds(10));
            string VisibleName = VisibleNameElement.Text;

            if (VisibleName == NameWordTemplate)
            {
                Logger.Info("Saved Word template is present on searching at home page");
            }
            else
            {
                Assert.Fail("Unable to find saved Word template on homepage list");
            }
        }
        [When(@"I delete the word template by clicking on delete button")]
        public void WhenIDeleteTheWordTemplateByClickingOnDeleteButton()
        {
            string xpathName = "//td[contains(text(),'" + NameWordTemplate + "')]";
            ReadOnlyCollection<IWebElement> NamesVisible = ObjectRepository.Driver.FindElements(By.XPath(xpathName));
            if (NamesVisible != null)
            {
                for (int temp = 1; temp <= NamesVisible.Count; temp++)
                {
                    string xpathDelete = "//tr[1]//td[5]//i[3]";
                    LinkHelper.ClickLink(By.XPath(xpathDelete));
                    Thread.Sleep(1000);
                    LinkHelper.ClickLink(By.XPath("//span[contains(text(),' Yes ')]"));
                    Thread.Sleep(2000);
                    LinkHelper.ClickLink(By.XPath("//span[contains(text(),'Okay')]"));
                }
            }
            else
            {
                Assert.Fail("The searched template is not visible for delete");
            }
        }
        [Then(@"The word template should be deleted from the database")]
        public void ThenTheWordTemplateShouldBeDeletedFromTheDatabase()
        {
            Thread.Sleep(1000);
            TextBoxHelper.ClearText(By.XPath("//input[@placeholder='Search in Template...']"));

            TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Search in Template...']"), NameWordTemplate);
            Thread.Sleep(1000);
            if (ObjectRepository.Driver.FindElement(By.XPath("//div[contains(text(),'No Template Found!')]")).Displayed)
            {
                Logger.Info("Verified that the templates has been deleted successfully");
            }
            else
            {
                Logger.Info("Template is still visible in list after deleting");
            }
        }




    }
}
