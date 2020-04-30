using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoProject1.StepDefination
{
    [Binding]
    public sealed class Fill_cliams_recevied_with_Make_Recurring_option
    {
        String xlPath = ConfigurationManager.AppSettings.Get(@"ExcelPath");

        [When(@"User click on Make Recurring check box")]
        public void WhenUserClickOnMakeRecurringCheckBox()
        {
            CheckBoxHelper.CheckedCheckBox(By.XPath("//mat-label[@id='subtitle' and text()=' Make Recurring  ']"));
        }

        [Then(@"User Should be able to see start date filter")]
        public void ThenUserShouldBeAbleToSeeStartDateFilter()
        {
            

        }

        [When(@"User enter start date, end date, time and days")]
        public void WhenUserEnterStartDateEndDateTimeAndDays()
        {
            var Startdate = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 4);
            var Enddate = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 5);
            LinkHelper.ClickLink(By.XPath("//input[contains(@id,'mat-input-82')]"));
            TextBoxHelper.TypeInTexBox(By.XPath("//input[contains(@id,'mat-input-82')]"), Startdate.ToString());
            LinkHelper.ClickLink(By.XPath("//input[contains(@id,'mat-input-83')]"));
            TextBoxHelper.TypeInTexBox(By.XPath("//input[contains(@id,'mat-input-83')]"), Enddate.ToString());
            LinkHelper.ClickLink(By.Id("mat-select-9"));
            LinkHelper.ClickLink(By.XPath(""));

        }

        [When(@"User click on the create schedule")]
        public void WhenUserClickOnTheCreateSchedule()
        {
            ButtonHelper.ClickOnButton(By.XPath("//button//span[text()='Create Schedule']"));
        }



    }
}
