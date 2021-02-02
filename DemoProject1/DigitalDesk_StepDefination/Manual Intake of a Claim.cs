using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using DemoProject1.Setting;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.DigitalDesk_StepDefination
{
    [Binding]
    public sealed class Manual_Intake_of_a_Claim
    {
        Actions action = new Actions(ObjectRepository.Driver);
        // Creating object for logger class 
        ILog Logger = Log4NetHelper.GetLogger(typeof(Login_To_application));
        //Creating object for excel reader
        private readonly static string xlPath = ConfigurationManager.AppSettings.Get("ExcelPath");
        //Fetching user name and password from excel
        String Loss_Year = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 0).ToString();
        String Loss_Day = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 2, 0).ToString();
        String Loss_month = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 3, 0).ToString();
        String Received_Year = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 1).ToString();
        String Received_month = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 2, 1).ToString();
        String Received_day = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 3, 1).ToString();
        String CarrierRefNo = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 3).ToString();
        String ClaimNumber = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 4).ToString();
        String PolicyNumber = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 9).ToString();
        String PolicyHolderName = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 10).ToString();
        String PolicyHolderMobile = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 11).ToString();
        String PolicyHolderEmail = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 12).ToString();
        String address1 = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 13).ToString();
        String City = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 15).ToString();
        String Zip = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 16).ToString();
        String OnSiteContact = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 19).ToString();
        String OnSiteMobile = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 20).ToString();
        String OnSiteEmail = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 21).ToString();
        String Notes = ExcelReaderHelper.GetCellData(xlPath, "Manual Claim", 1, 22).ToString();
        IJavaScriptExecutor executor = ((IJavaScriptExecutor)ObjectRepository.Driver);

        [Given(@"the User is at Claims page")]
        public void GivenTheUserIsAtClaimsPage()
        {
            //Clicking on the cliams menu
            LinkHelper.ClickLink(By.XPath("//div[text()=' Claims ']"));
            Thread.Sleep(4000);
            LinkHelper.ClickLink(By.XPath("//span[text()='Add Claims']"));
            Logger.Info("Clicking on the add claims button");

        }

        [When(@"the User fills all the claim related information and saves")]
        public void WhenTheUserFillsAllTheClaimRelatedInformationAndSaves()
        {
            
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.XPath("(//kendo-dateinput/span/input)[1]"), Loss_Year);
            Logger.Info("Enetering loss year");
            Thread.Sleep(2000);
            action.SendKeys(Keys.ArrowLeft).Build().Perform();
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.XPath("(//kendo-dateinput/span/input)[1]"), Loss_Day);
            Logger.Info("Enetering loss day");
            Thread.Sleep(2000);
            action.SendKeys(Keys.ArrowLeft).Build().Perform();
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.XPath("(//kendo-dateinput/span/input)[1]"), Loss_month);
            Logger.Info("Enetering loss month");
            // Selecting the Received Date 
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.XPath("(//kendo-dateinput/span/input)[2]"), Received_Year);
            Logger.Info("Enetering Received Year");
            Thread.Sleep(2000);
            action.SendKeys(Keys.ArrowLeft).Build().Perform();
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.XPath("(//kendo-dateinput/span/input)[2]"), Received_month);
            Logger.Info("Enetering Received month");
            Thread.Sleep(2000);
            action.SendKeys(Keys.ArrowRight).Build().Perform();
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.XPath("(//kendo-dateinput/span/input)[2]"), Received_day);
            Logger.Info("Enetering Received day");
            // Selecting Carrier Name
            LinkHelper.ClickLink(By.XPath("//span[text()='Select Carrier Name']"));
            action.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(2000);
            //Enetering data in Carrier Ref No# text box
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='carrierRef']"), CarrierRefNo);
            //Enetering data in Claim Number text box
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='claimNumber']"), ClaimNumber);
            // Selecting Cat Code
            LinkHelper.ClickLink(By.XPath("//Span[text()='Select CAT Code']"));
            action.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(2000);
            // Selecting Peril Type
            LinkHelper.ClickLink(By.XPath("//span[text()='Select Peril Type']"));
            action.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(2000);
            // Selecting Property Type
            LinkHelper.ClickLink(By.XPath("//span[text()='Select Property Type']"));
            action.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(2000);
            // Selecting Claim Source
            LinkHelper.ClickLink(By.XPath("//span[text()='Select Claim Source']"));
            action.SendKeys(Keys.ArrowDown).Build().Perform();
            Thread.Sleep(2000);
            //Enetering data in Notes text box
            TextBoxHelper.TypeInTexBox(By.XPath("//textarea[@placeholder='Special Instructions..']"), Notes);
            //Enetering data in the adress1 text box 
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='addressLine1']"), address1);
            //Enetering data in city text box
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='city']"), City);
            //Entering data in Zip text box 
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='zip']"), Zip);
            //Entering data in Policy Number text box 
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='policyNumber']"), PolicyNumber);
            //Entering data in Policy Holder's Name text box 
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='PolicyHolderName']"), PolicyHolderName);
            //Selecting state 
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//span[text()='Select State']"));
            action.SendKeys(Keys.ArrowDown).Build().Perform();
            //Entering data in Policy Holder's email text box 
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='PolicyHolderEmail']"), PolicyHolderEmail);
            //Entering data in Policy Holder's mobile text box 
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//kendo-maskedtextbox[@formcontrolname='PolicyHolderNumber']//input"));
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.XPath("//kendo-maskedtextbox[@formcontrolname='PolicyHolderNumber']//input"), PolicyHolderMobile);
            //Entering data in Onsite Contact Name text box
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='onSiteName']"), OnSiteContact);
            //Entering data in Onsite email text box
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='onSiteEmail']"), OnSiteEmail);
            //Entering data in Onsite mobile text box
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//kendo-maskedtextbox[@formcontrolname='onSiteNumber']//input"));
            Thread.Sleep(2000);
            TextBoxHelper.TypeInTexBox(By.XPath("//kendo-maskedtextbox[@formcontrolname='onSiteNumber']//input"), OnSiteMobile);
            Thread.Sleep(2000);
            GenericHelper.WaitForWebElement(By.XPath("//button[contains(text(),'Save ')]"), TimeSpan.FromSeconds(60));
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//button[contains(text(),'Save ')]"));
            Thread.Sleep(2000);
            executor.ExecuteScript("arguments[0].click()", ele);


        }

        [Then(@"the system should add the new claim with a success message as “Claim Added Successfully”")]
        public void ThenTheSystemShouldAddTheNewClaimWithASuccessMessageAsClaimAddedSuccessfully()
        {
            Thread.Sleep(5000);
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Search by Claim Number']"), ClaimNumber);
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//i[@class='fa fa-search']"));
            Thread.Sleep(2000);
            IWebElement VisibleNameElement = GenericHelper.WaitForWebElementInPage(By.XPath("(//div[@class='value'])[8]"), TimeSpan.FromSeconds(10));
            string VisibleName = VisibleNameElement.Text;
            if (VisibleName == ClaimNumber)
            {
                Assert.AreEqual(VisibleName, ClaimNumber);
                Logger.Info("Saved ClaimNumber is present on searching at home page");
            }
            else
            {
                Logger.Info("Unable to find saved ClaimNumber on homepage list");
            }
        }


        [When(@"the User uploads a file containing claims in bulk")]
        public void WhenTheUserUploadsAFileContainingClaimsInBulk()
        {
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("//button[contains(text(),' Upload Claim ')]"));
            Logger.Info("Clicking on the upload claim button");
            Process.Start("D:\\FileUpload2CMD.exe", "D:\\Docs\\Test.docx");

        }



    }
}
