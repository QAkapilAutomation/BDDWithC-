using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
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

namespace DemoProject1.DigitalDesk_StepDefination
{
    [Binding]
    public sealed class ClaimDetails
    {
        Actions action = new Actions(ObjectRepository.Driver);
        // Creating object for logger class 
        ILog Logger = Log4NetHelper.GetLogger(typeof(Login_To_application));
        //Creating object for excel reader
        private readonly static string xlPath = ConfigurationManager.AppSettings.Get("ExcelPath");
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

        [When(@"the User selects view for a claim")]
        public void WhenTheUserSelectsViewForAClaim()
        {
            //Clicking on the ellipsis button
            LinkHelper.ClickLink(By.XPath("//div[text()=' Claims ']"));
            String before_xpath = "//td[text()='";
            String afetrXpath = "']//following::td[9]//i[@class='fas fa-ellipsis-v']";
            String xpath = before_xpath + ClaimNumber + afetrXpath;
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath(xpath));
            Logger.Info("Clicked on the ellipsis button");
            Thread.Sleep(2000);
            // Clicking on the view button
            String viewafterxpath = "']//following::td[9]//span[text()='View']";
            String viewxpath = before_xpath + ClaimNumber + viewafterxpath;
            LinkHelper.ClickLink(By.XPath(viewxpath));
            Logger.Info("Clicked on the View button");
            

        }
        [Then(@"the system should show claim details related to that claim")]
        public void ThenTheSystemShouldShowClaimDetailsRelatedToThatClaim()
        {
            String actaualClaimNumber = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[8]")).Text.ToString();
            String actauallossDate = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[9]")).Text.ToString();
            String actaualperil = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[10]")).Text.ToString();
            String actaualclaimStatus = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[11]")).Text.ToString();
            String actaualreceivedDate = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[12]")).Text.ToString();
            String actaualcarrierName = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[13]")).Text.ToString();
            String actualNotes = ObjectRepository.Driver.FindElement(By.XPath("//div[2]/div[7]/span")).Text.ToString();
            String actualPolicyHolder = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[14]")).Text.ToString();
            String actualPolicyHolderEmail = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[15]")).Text.ToString();
            String actualPolicyHolderMobile = ObjectRepository.Driver.FindElement(By.XPath("(//div[@class='value'])[16]")).Text.ToString();




        }


    }
}
