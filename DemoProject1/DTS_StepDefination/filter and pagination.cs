using OpenQA.Selenium;
using DemoProject1.ComponentHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using DemoProject1.Setting;
using DemoProject1.ExcelReader;
using System.Configuration;

namespace DemoProject1.filter_and_pagination
{
    [Binding]
    public sealed class filter_and_pagination
    {
        private readonly static string xlPath = ConfigurationManager.AppSettings.Get("ExcelPath");
        String NameEmailTemplate = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 0).ToString();
        [When(@"user type a template by name")]
        public void WhenUserTypeATemplateByName()
        {
            GenericHelper.WaitForWebElement(By.XPath("//input[@placeholder='Search in Template...']"), TimeSpan.FromSeconds(60));
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Search in Template...']"), NameEmailTemplate);
            Thread.Sleep(10000);
            LinkHelper.ClickLink(By.XPath("//mat-select[@id='mat-select-1']"));
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//span[@class='mat-option-text'][contains(text(),'Name')]"));
        }
        [Then(@"list of by name template should be displayed")]
        public void ThenListOfByNameTemplateShouldBeDisplayed()
        {
           String ActualData  =ObjectRepository.Driver.FindElement(By.XPath("//td[contains(text(),NameEmailTemplate)]")).Text.ToString();
            Console.WriteLine(ActualData);
            AssertHelper.AreEqual(NameEmailTemplate, ActualData);
        }

        [When(@"user type a template by group")]
        public void WhenUserTypeATemplateByGroup()
        {
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Search in Template...']"), "Primustest");
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//mat-select[@id='mat-select-1']"));
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//span[text()='Group']"));
        }
        [Then(@"list of by group template should be displayed")]
        public void ThenListOfByGroupTemplateShouldBeDisplayed()
        {
            String ActualData = ObjectRepository.Driver.FindElement(By.XPath("//td[contains(text(),'Primustest')]")).Text.ToString();
            Console.WriteLine(ActualData);
            AssertHelper.AreEqual("Primustest", ActualData);
        }




    }
}
