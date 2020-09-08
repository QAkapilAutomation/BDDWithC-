using AventStack.ExtentReports.Model;
using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.StepDefination
{
    [Binding]
    public sealed class Merge_Email_And_Templete
    {
        private static readonly ILog Logger = Log4NetHelper.GetLogger(typeof(Merge_Email_And_Templete));

        [Given(@"the template page is open")]
        public void GivenTheTemplatePageIsOpen()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            GenericHelper.WaitForWebElement(By.XPath("//button[text()=' Name ']"), TimeSpan.FromSeconds(60));

        }  
        [When(@"a user selects Email template option")]
        public void WhenAUserSelectsEmailTemplateOption()
        {

          //  JavaScriptExecutor.ScrollToAndClick(By.XPath("//span[text()='Email Template']"));

        }

        [Then(@"all list of the Email template appears")]
        public void ThenAllListOfTheEmailTemplateAppears()
        {
            GenericHelper.IsElemetPresent(By.XPath("//button[text()=' Name ']"));
            GenericHelper.IsElemetPresent(By.XPath("//button[text()=' Group ']"));
            GenericHelper.IsElemetPresent(By.XPath("//button[text()=' Updated On ']"));
            GenericHelper.IsElemetPresent(By.XPath("//th[text()=' Action ']"));
        }

        [Given(@"the Email template page is open")]
        public void GivenTheEmailTemplatePageIsOpen()
        {
            //JavaScriptExecutor.ScrollToAndClick(By.XPath("//span[text()='Email Template']"));
        }

        [Then(@"template listing along with Filter and Sorting option appear\.")]
        public void ThenTemplateListingAlongWithFilterAndSortingOptionAppear_()
        {
           Boolean status_Name = GenericHelper.IsElemetPresent(By.XPath("//button[text()=' Name ']"));
           Boolean status_Group = GenericHelper.IsElemetPresent(By.XPath("//button[text()=' Group ']"));
           Boolean status_Update = GenericHelper.IsElemetPresent(By.XPath("//button[text()=' Updated On ']"));
           Boolean status_Action = GenericHelper.IsElemetPresent(By.XPath("//th[text()=' Action ']"));
           Boolean status_SearchPlaceHolder = GenericHelper.IsElemetPresent(By.XPath("//input[@placeholder='Search in Template...']"));
           Boolean Status_SearchBy = GenericHelper.IsElemetPresent(By.XPath("//input[@placeholder='Search in Template...']"));
           Boolean Status_NewTemplate = GenericHelper.IsElemetPresent(By.XPath("//button[@class='split-btn']"));
            if (status_Name)
            {
                Logger.Info("Name filter is visible");
            }
            else if (status_Group)
            {
                Logger.Info("Group filter is visible");
            }
           else  if (status_Update)
            {
                Logger.Info("Update filter is visible");
            }
            else if (status_Action)
            {
                Logger.Info("Action filter is visible");
            }
           else  if (status_SearchPlaceHolder)
            {
                Logger.Info("PlaceHolder filter is visible");
            }
            else if (Status_SearchBy)
            {
                Logger.Info("SearchBy filter is visible");
            }
           else if (Status_NewTemplate)
            {
                Logger.Info("New Templete filter is visible");
            }
            else
            {
                Logger.Info("Email templete page is not open");
            }
        }

        [When(@"a user selects Merge and Email option")]
        public void WhenAUserSelectsMergeAndEmailOption()
        {
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//tbody/tr[1]/td[1]"));
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//button//span[text()=' Merge & Email ']")); 
        }
        [Then(@"the Email Composer page appears with Merged Data and Filled Properties")]
        public void ThenTheEmailComposerPageAppearsWithMergedDataAndFilledProperties()
        {
            Thread.Sleep(2000);
           Boolean Staus_From = GenericHelper.IsElemetPresent(By.XPath("//input[@name='from']"));
           Boolean Staus_To = GenericHelper.IsElemetPresent(By.XPath("//input[@name='toEmail']"));
            Boolean Staus_CC = GenericHelper.IsElemetPresent(By.XPath("//input[@placeholder='Cc']"));
            Boolean Staus_Subject = GenericHelper.IsElemetPresent(By.XPath("//input[@placeholder='Subject']"));

            if (Staus_From)
            {
                Logger.Info("Form textfiled is present on the page");

            }
           else if (Staus_To)
            {
                Logger.Info("To textfiled is present on the page");

            }
            else if (Staus_CC)
            {
                Logger.Info("CC textfiled is present on the page");

            }
            else if (Staus_Subject)
            {
                Logger.Info("Subject textfiled is present on the page");

            }
            else
            {
                Logger.Info("user is not on the Email Composer page");

            }


        }

        [Given(@"the Merge And Email Composer page is open")]
        public void GivenTheMergeAndEmailComposerPageIsOpen()
        {
            Thread.Sleep(2000);
            GenericHelper.WaitForWebElement(By.XPath("//tbody/tr[1]/td[1]"), TimeSpan.FromSeconds(60));
            LinkHelper.ClickLink(By.XPath("//tbody/tr[1]/td[1]"));
            Thread.Sleep(5000);
            LinkHelper.ClickLink(By.XPath("//button//span[text()=' Merge & Email ']"));
        }




        [When(@"user selects any of the given properties")]
        public void WhenUserSelectsAnyOfTheGivenProperties()
        {
           
                LinkHelper.ClickLink(By.XPath("//input[@name='from']"));
                Thread.Sleep(2000);
                //String text_Before=ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='mat-chip-list-wrapper'])[1]")).Text;
                //Console.WriteLine(text_Before);
                //Actions act = new Actions(ObjectRepository.Driver);
                //act.MoveToElement(ObjectRepository.Driver.FindElement(By.XPath("(//mat-chip/i)[1]"))).Perform();
                JavaScriptExecutor.ScrollToAndClick(By.XPath("(//mat-chip/i)[1]"));
                TextBoxHelper.TypeInTexBox(By.XPath("//input[@name='from']"), "a1@gmail.com");
                LinkHelper.ClickLink(By.XPath("//input[@name='toEmail']"));
                JavaScriptExecutor.ScrollToAndClick(By.XPath("(//mat-chip/i)[2]"));
                TextBoxHelper.TypeInTexBox(By.XPath("//input[@name='toEmail']"), "a1@gmail.com");
                LinkHelper.ClickLink(By.XPath("//input[@placeholder='Cc']"));
                JavaScriptExecutor.ScrollToAndClick(By.XPath("(//mat-chip/i)[3]"));
                TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Cc']"), "a1@gmail.com");
                TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Subject']"), "sub1");
                LinkHelper.ClickLink(By.XPath("//span[text()='Send']"));
                
                
        }
        [Then(@"user can change or Edit the pre-filled data\.")]
        public void ThenUserCanChangeOrEditThePre_FilledData_()
        {
            //Thread.Sleep(2000);
            //LinkHelper.ClickLink(By.XPath("//tbody/tr[1]/td[1]"));
            //GenericHelper.WaitForWebElement(By.XPath("//button//span[text()=' Merge & Email ']"), TimeSpan.FromSeconds(60));
            Thread.Sleep(10000);
            LinkHelper.ClickLink(By.XPath("//button//span[text()=' Merge & Email ']"));
            Thread.Sleep(5000);
            String text_Before=ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='mat-chip-list-wrapper'])[1]")).Text;
            Console.WriteLine(text_Before);



        }





    }
}
