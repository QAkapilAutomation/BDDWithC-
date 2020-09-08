using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.Test
{
    [Binding]
    public sealed class Test1
    {
        [Given(@"I am at the Admin page with url ""(.*)""")]
        public void GivenIAmAtTheAdminPageWithUrl(string url)
        {
            NavigationHelper.NavigateToUrl(url);
        }

        [Given(@"the Admin is at eligibility data screen")]
        public void GivenTheAdminIsAtEligibilityDataScreen()
        {
            Thread.Sleep(5000);
            LinkHelper.ClickLink(By.XPath("//span[@class='route-title animate__animated animate__slideInDown ng-tns-c155-1'][contains(text(),'Eligibility')]"));
            Thread.Sleep(5000);
            LinkHelper.ClickLink(By.XPath("//span[@class='sub-route route-title animate__animated animate__slideInDown ng-tns-c155-1'][contains(text(),'Add')]"));
            Thread.Sleep(5000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)ObjectRepository.Driver;
            //jse.ExecuteScript("scroll(0, 250)");
            Thread.Sleep(5000);
            //LinkHelper.ClickLink(By.XPath("//h5[contains(text(),'Employment Details')]"));
            JavaScriptExecutor.ScrollToAndClick(By.XPath("//h5[contains(text(),'Employment Details')]"));

            // Actions action = new Actions(ObjectRepository.Driver);
            IWebElement element = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='mat-select-3']"));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            //action.MoveToElement(element).Click().Build().Perform();
            jse.ExecuteScript("arguments[0].click(); ", element);
            Thread.Sleep(5000);



            TakeScreenShots.CaptureScreenshoots("Test");
            //LinkHelper.ClickLink(By.XPath("//span[text()=' 101 - T-Mobile ']"));
            JavaScriptExecutor.ScrollToAndClick(By.XPath("//span[text()=' 101 - T-Mobile ']"));
            Thread.Sleep(5000);
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='employeeDepartmentName']"), "sdgfjsjdsgh");
            IWebElement element2 = ObjectRepository.Driver.FindElement(By.XPath("//mat-slide-toggle[@formcontrolname='isUnionEmployee']//input"));
            Boolean status=  CheckBoxHelper.IsCheckBoxChecked(By.XPath("//mat-slide-toggle[@formcontrolname='isUnionEmployee']//input"));
            if (status==false)
            {
                jse.ExecuteScript("arguments[0].click(); ", element2);
            }
            //JavaScriptExecutor.ScrollToAndClick(By.XPath("//*[@id='mat-expansion-panel-header-2']"));
            IWebElement element1 = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='mat-expansion-panel-header-2']"));
            jse.ExecuteScript("window.scrollBy(0,-250)", "");
            jse.ExecuteScript("arguments[0].click(); ", element1);

            TextBoxHelper.TypeInTexBox(By.XPath("//input[@formcontrolname='employeePreviousEmployerName']"), "hgdsajas");


            Thread.Sleep(10000);
        }

        [When(@"the Admin saves all the required information related to the eligibility of client’s employee, by adding them in different fields")]
        public void WhenTheAdminSavesAllTheRequiredInformationRelatedToTheEligibilityOfClientSEmployeeByAddingThemInDifferentFields()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the system should create new eligibility data with confirmation message as “New Eligibility Data Added”")]
        public void ThenTheSystemShouldCreateNewEligibilityDataWithConfirmationMessageAsNewEligibilityDataAdded()
        {
            //ScenarioContext.Current.Pending();
        }





    }
}
