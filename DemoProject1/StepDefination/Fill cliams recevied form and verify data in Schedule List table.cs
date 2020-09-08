using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using DemoProject1.PageLibrary;
using DemoProject1.Setting;
using log4net;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.StepDefination
{
    [Binding]
    public sealed class Fill_cliams_recevied_form_and_verify_data_in_Schedule_List_table
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(Fill_cliams_recevied_form_and_verify_data_in_Schedule_List_table));
        String xlPath = ConfigurationManager.AppSettings.Get(@"ExcelPath");
        ClaimsReceived cRpage = new ClaimsReceived(ObjectRepository.Driver);
        
        [When(@"User Enter title, recipient")]
        public void WhenUserEnterTitleRecipient()
        {   
            Thread.Sleep(5000);
            cRpage.EnterDataIntitleTextBox();
            Logger.Info("Title text enter in the title text box");
            cRpage.EnterdataRecipientTextBox();
            Logger.Info("Recipient text enter in the Recipient text box");
        }

        [When(@"select ApplicationRCDVDate filter,Leave Start Date, Location Code, Division,Department and click on the Run Now button")]
        public void WhenSelectClaimTypeDivisionDepartmentClaimStatusFiltesrAndClickOnTheRunNowButton()
        {
            var ApplicationRCDVDate = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 2);
            var LeaveStartDate = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 3);
            LinkHelper.ClickLink(By.Id("mat-input-3"));

            TextBoxHelper.TypeInTexBox(By.Id("mat-input-3"), ApplicationRCDVDate.ToString());


            LinkHelper.ClickLink(By.Id("mat-input-4"));

            TextBoxHelper.TypeInTexBox(By.Id("mat-input-4"), LeaveStartDate.ToString());

            LinkHelper.ClickLink(By.XPath("//mat-select[contains(@id,'mat-select-2') or class='mat-select ng-tns-c14-51 ng-pristine ng-valid mat-select-empty ng-star-inserted ng-touched']"));

            LinkHelper.ClickLink(By.XPath("//span[text()='OP4315']"));

            cRpage.ClickOnRunNowButton();
            
            Thread.Sleep(5000);
        }

        [Then(@"User should be at Schedule List table")]
        public void ThenUserShouldBeAtScheduleListTable()
        {
            cRpage.VerifyDataInScheduleTable();
        }



    }
}
