using DemoProject1.ComponentHelper;
using DemoProject1.PageLibrary;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoProject1.StepDefination
{
    [Binding]
    public sealed class Verify_title_and_Recipientid_validation_message_on_the_claims_received_page
    {
        ClaimsReceived cRpage = new ClaimsReceived(ObjectRepository.Driver);

        [When(@"User click on the Short Term Disability Standard Reports")]
        public void WhenUserClickOnTheShortTermDisabilityStandardReports()
        {
            cRpage.ClickOnShortTermDisabilityStandardReports();
        }

        [Then(@"Short Term Disability Standard Reports list should be open")]
        public void ThenShortTermDisabilityStandardReportsListWillBeOpen()
        {
           
        }

        [When(@"User click on the claims received report")]
        public void WhenUserClickOnTheClaimsReceivedReport()
        {
            cRpage.ClickOnClaimsReceivedLink();
        }

        [Then(@"User should be at Create Schedule:Claims Received report page")]
        public void ThenUserShouldBeAtCreateScheduleClaimsReceivedReport()
        {
            //Assert.IsTrue(GenericHelper.IsElemetPresent(By.XPath("mat-input-1")));
        }

        [When(@"user click on the title and Recipient textbox")]
        public void WhenUserClickOnTheTitleAndRecipientTextbox()
        {
            cRpage.ClickOnTheTitleTextBox();
            cRpage.ClickOnRecipientTextBox();
            LinkHelper.ClickLink(By.XPath("//mat-select[@id='mat-select-2']"));
        }

        [Then(@"Verify the title and Recipient textbox validation message")]
        public void ThenVerifyTheTitleAndRecipientTextboxValidationMessage()
        {
           cRpage.verifyTitleAndRecipientTextBoxValidationmessage(); 
        }



    }
}
