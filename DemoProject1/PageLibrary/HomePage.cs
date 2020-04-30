using DemoProject1.ComponentHelper;
using OpenQA.Selenium;
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

        [FindsBy(How = How.XPath, Using = "(//button[text()='Manage Schedules'])[1]")]
        private readonly IWebElement manageSchedules;

        [FindsBy(How = How.XPath, Using = " //p[text()='Report Scheduler']")]
        private  readonly IWebElement reportScheduler;


        [FindsBy(How = How.XPath, Using = "//div[@id='title']")]
        private  readonly IWebElement Schedulelist;
        



        public HomePage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;

        }

        public void ClickOnManageSchedulesLink()
        {
            manageSchedules.Click();

        }

        public void ClickOnReportSchedulerLink()
        {
            GenericHelper.WaitForWebElementInPage(By.XPath("//p[text()='Report Scheduler']"),TimeSpan.FromSeconds(60));
            reportScheduler.Click();
        }

        public void VerifyScheduleListTitle()
        {
           String text= Schedulelist.GetAttribute("text");
            AssertHelper.AreEqual(text,"Schedule List");
        }
    }
}
