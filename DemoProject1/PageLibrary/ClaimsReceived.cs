using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject1.PageLibrary
{
    public class ClaimsReceived
    {

        //public string title = "testkapil" + DateTime.Now.ToString("MMdd_HHmm");
        //public string RecipientId = "testkapil" + DateTime.Now.ToString("MMdd_HHmm") + "@gmail.com";
        String xlPath = ConfigurationManager.AppSettings.Get(@"ExcelPath");
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[text()=' Short Term Disability Standard Reports']")]
        private readonly IWebElement ShortTermDisabilityStandardReports;

        [FindsBy(How = How.XPath, Using = "(//a[text()='Claims Received'][@class='mat-line'])[1]")]
        private readonly IWebElement ClaimsReceivedLink;


        [FindsBy(How = How.XPath, Using = "//div[@class='mat-form-field-infix']//child::input[@id='mat-input-1']")]
        private readonly IWebElement TitleTextBox;

        [FindsBy(How = How.XPath, Using = "//div[@class='mat-form-field-infix']//child::input[@id='mat-input-2']")]
        private readonly IWebElement RecipientTextBox;


        [FindsBy(How = How.XPath, Using = "//div//mat-error[@id='mat-error-0']")]
        private readonly IWebElement TitleErorMessage;


        [FindsBy(How = How.XPath, Using = "//div//mat-error[@id='mat-error-1']")]
        private readonly IWebElement RecipientErorMessage;


        [FindsBy(How = How.XPath, Using = "//mat-select[@id='mat-select-2']")]
        private readonly IWebElement ClaimTypeFilter;

        [FindsBy(How = How.XPath, Using = "//span[text()='Long Term']")]
        private readonly IWebElement LongTerm;

        [FindsBy(How = How.XPath, Using = "//mat-select[@id='mat-select-15']")]
        private readonly IWebElement DivisionFilter;

        [FindsBy(How = How.XPath, Using = "//span[text()='Multiwall Parking']")]
        private readonly IWebElement MultiwallParking;

        [FindsBy(How = How.XPath, Using = "//span[text()='//mat-select[@id='mat-select-16']")]
        private readonly IWebElement DepartmentFilter;


        [FindsBy(How = How.XPath, Using = "//span[text()='OYE564']")]
        private readonly IWebElement DepartmentFilter_OYE564;

        [FindsBy(How = How.XPath, Using = "//span[text()='OYE564']")]
        private readonly IWebElement DepartmentFilterOYE564;

        [FindsBy(How = How.XPath, Using = "//mat-select[@id='mat-select-17']")]
        private readonly IWebElement ClaimStatusFilter;

        [FindsBy(How = How.XPath, Using = "//span[text()='Pending']")]
        private readonly IWebElement Pending;

        [FindsBy(How = How.XPath, Using = "//span[text()='Run Now']")]
        private readonly IWebElement RunNowButton;

        [FindsBy(How = How.XPath, Using = "//input[starts-with(@id,'mat-input')]")]
        private readonly IWebElement filter_Search;

        [FindsBy(How = How.XPath, Using = "(//td[contains(text(),'Kapil')])[1]")]
        private readonly IWebElement TitleXpath;

        [FindsBy(How = How.Id, Using = "mat - input - 3")]
        private readonly IWebElement ApplicationRCVDDate;

        [FindsBy(How = How.Id, Using = "mat - input - 4")]
        private readonly IWebElement LeaveStartDate;


        [FindsBy(How = How.Id, Using = "mat-option-4")]
        private  readonly IWebElement LocationCode;


        public ClaimsReceived(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;

        }

        public  void ClickOnShortTermDisabilityStandardReports()
        {
            LinkHelper.click(LocationCode);

        }

        public void ClickOnClaimsReceivedLink()
        {
            ClaimsReceivedLink.Click();
        }

        public void EnterDataIntitleTextBox()
        {
            var title = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 0);
            TitleTextBox.SendKeys(title.ToString());

        }

        public void EnterdataRecipientTextBox()
        {
            var RecipientId = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 1);
            RecipientTextBox.SendKeys(RecipientId.ToString());
        }

        public void ClickOnTheTitleTextBox()
        {
            TitleTextBox.Click();
        }

        public void ClickOnRecipientTextBox()
        {
            RecipientTextBox.Click();
        }

        public void verifyTitleAndRecipientTextBoxValidationmessage()
        {
            Console.WriteLine(TitleErorMessage.Text);
            Console.WriteLine(RecipientErorMessage.Text);
            Assert.AreEqual(TitleErorMessage.Text, "This is a required field.");
            Assert.AreEqual(RecipientErorMessage.Text, "This is a required field.");

        }

        public void SelectClaimsFilter()
        {
            ClaimTypeFilter.Click();
            // LongTerm.Click();
        }
        public void SelectDivisionFilter()
        {
            DivisionFilter.Click();
            MultiwallParking.Click();

        }
        public void SelectDepartmentFilter()
        {
            DepartmentFilter.Click();
            DepartmentFilter_OYE564.Click();
        }
        public void ClaimStatusFilterFilter()
        {
            ClaimStatusFilter.Click();
            Pending.Click();

        }
        public void ClickOnRunNowButton()
        {
            RunNowButton.Click();
        }

        public void EnterDataInRCDVDatetextBox()
        {
            ApplicationRCVDDate.SendKeys("4/13/2020");
        }
        public void VerifyDataInScheduleTable()
        {
            string title = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 0).ToString();
            filter_Search.Click();
            filter_Search.SendKeys(ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 0).ToString());
           // Assert.AreEqual(TitleXpath.Text, ExcelReaderHelper.GetCellData(xlPath, "Sheet1", 1, 0));

            List<IWebElement> rows = new List<IWebElement>(driver.FindElements(By.TagName("tr")));
            Console.WriteLine(rows.Count);
            for(int i = 1; i < rows.Count(); i++)
            {
                String name = driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[1]")).Text;
                if(name.Contains(title))
                {
                    //JavaScriptExecutor.ScrollToAndClick(By.XPath("(//mat-icon[text()='delete'])[1]"));
                    //Thread.Sleep(2000);
                    //JavaScriptExecutor.ScrollToAndClick(By.XPath("//button[@color='primary' or @class='mat-raised-button mat-button-base mat-primary']//span[text()='Yes']"));
    
                    Assert.AreEqual(name, title);
                }
            }
               
            }



        }
    }



