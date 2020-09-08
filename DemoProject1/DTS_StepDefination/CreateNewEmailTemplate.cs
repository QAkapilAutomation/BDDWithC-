using AventStack.ExtentReports.Model;
using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using DemoProject1.PageLibrary;
using DemoProject1.Setting;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.DTS_StepDefination
{
    [Binding]
    public sealed class CreateNewEmailTemplate 
    {
        private readonly Actions act = new Actions(ObjectRepository.Driver);

        private readonly static string xlPath = ConfigurationManager.AppSettings.Get("ExcelPath");

        string name = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 0).ToString();

        ILog Logger = Log4NetHelper.GetLogger(typeof(CreateNewEmailTemplate));

        WordTemplate wTemplate = new WordTemplate(ObjectRepository.Driver);

        HomePage hPage = new HomePage(ObjectRepository.Driver);

        EmailTemplate eTemplate = new EmailTemplate(ObjectRepository.Driver);

        String NameEmailTemplate = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 0).ToString();

        String Name = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 0).ToString()+ DateTime.Now.ToString("MMdd_HHmm");

        string group = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 1).ToString();

        string description = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 3).ToString();

        string from = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 4).ToString();

        string to = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 5).ToString();

        string cC = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 6).ToString();

        string subject = ExcelReaderHelper.GetCellData(xlPath, "EmailTemplate", 1, 7).ToString();


        [Given(@"I am at the Home Page with url")]
        public void GivenIAmAtTheHomePageWithUrl()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
        }


        [When(@"I click on create Email  by hovering the cursor to new template option")]
        public void WhenIClickOnCreateEmailByHoveringTheCursorToNewTemplateOption()
        {
            hPage.hoverToNewButtonAndClickOnEmailTemplate();
        }

        [When(@"I enter the required information")]
        public void WhenIEnterTheRequiredInformationInAllTheEmailTemplateField()
        {
            Thread.Sleep(2000);
            wTemplate.typeinTemplateName(Name);
           // wTemplate.typeinGroupName(group);
            wTemplate.typeindescription(description);
            Thread.Sleep(1000);
            eTemplate.typeinFormTextBox(from);
            eTemplate.typeinToTextBox(to);
            eTemplate.typeinCCTextBox(cC);
            eTemplate.typeinSubjectTextBox(subject);
           
        }

        [When(@"I verify that Attachment Container checkbox is unchecked")]
        public void WhenIVerifyThatAttachmentContainerCheckboxIsUnchecked()
        {
            Thread.Sleep(2000);
            bool IsChecked = eTemplate.VerifyThatAttachmentContainerCheckboxIsUnchecked();
            if (IsChecked)
            {
                LinkHelper.ClickLink(By.XPath("//div[@class='mat-checkbox-inner-container mat-checkbox-inner-container-no-side-margin']"));
                
            }
        }

        [When(@"I Click On SAVE Button")]
        public void WhenIClickOnSAVEButton()
        {
            eTemplate.clickOnSaveButton();
           
        }


        //[When(@"I verify that Attachment Container checkbox is checked")]
        //public void WhenIVerifyThatAttachmentContainerCheckboxIsChecked()
        //{
        //    ScenarioContext.Current.Pending();
        //}


        [When(@"I attach Multiple File using Add Attachement option")]
        public void WhenIAttachMultipleFileUsingAddAttachementOption()
        {
            eTemplate.addAttachmentForEmailTemplate();
          
        }
        [Then(@"i should see the success messgage")]
        public void ThenIShouldSeeTheSuccessMessgage()
        {
            //string actaualmsg = ObjectRepository.Driver.FindElement(By.XPath("//span[text()='Template has been saved.']")).Text;
            //AssertHelper.AreEqual(actaualmsg, "Template has been saved.");
            eTemplate.verifySuccessMessage();

        }

        [When(@"a user drag desired fields from the merge field list and drop in template body")]
        public void WhenAUserDragDesiredFieldsFromTheMergeFieldListAndDropInTemplateBody()
        {
            Actions builder = new Actions(ObjectRepository.Driver);
            Thread.Sleep(1000);
            IWebElement src = ObjectRepository.Driver.FindElement(By.XPath("//div[contains(text(),'User_First_Name')]"));
            Thread.Sleep(1000);
           // IWebElement tar = ObjectRepository.Driver.FindElement(By.XPath("//div[@class='ql-editor ql-blank']//p"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.XPath("//div[@data-placeholder='Compose you email template...']"));



            //act.DragAndDrop(src, tar)
            //    .Build()
            //    .Perform();
            //Thread.Sleep(4000);




            //builder.ClickAndHold(src).MoveToElement(tar).Perform();
            //Thread.Sleep(2000);// add 2 sec wait
            //builder.Release(tar).Build().Perform();

           // Actions builder = new Actions(Driver.Browser.Instance);
            IAction dragAndDrop = builder.ClickAndHold(src)
                .MoveByOffset(-1, -1)
                .MoveToElement(tar)
                .Release(tar)
                .Build();
            dragAndDrop.Perform();



        }

        //----------------------Delete Email Template------------------------

        [When(@"I search the same email template by name on email template page")]
        public void WhenISearchTheSameEmailTemplateByNameOnEmailTemplatePage()
        {
            Thread.Sleep(2000);
            LinkHelper.ClickLink(By.XPath("(//mat-select)[2]"));
            LinkHelper.ClickLink(By.XPath("//span[contains(text(),'Name')]"));
            TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Search in Template...']"), Name);

        }

        [Then(@"The email template should be present")]
        public void ThenTheEmailTemplateShouldBePresent()
        {
            Thread.Sleep(2000);
            IWebElement VisibleNameElement = GenericHelper.WaitForWebElementInPage(By.XPath("//html[1]//body[1]//app-root[1]//app-template-list[1]//div[2]//div[1]//table[1]//tbody[1]//tr[1]//td[1]"), TimeSpan.FromSeconds(10));
            string VisibleName = VisibleNameElement.Text;

            if (VisibleName == name)
            {
                Logger.Info("Saved Word template is present on searching at home page");
            }
            else
            {
               // Log.fail("Unable to find saved Word template on homepage list");
            }
        }

        [When(@"I delete the email template by clicking on delete button")]
        public void WhenIDeleteTheEmailTemplateByClickingOnDeleteButton()
        {
            string xpathName = "//td[contains(text(),'" + NameEmailTemplate + "')]";
            ReadOnlyCollection<IWebElement> NamesVisible = ObjectRepository.Driver.FindElements(By.XPath(xpathName));
            if (NamesVisible != null)
            {
                for (int temp = 1; temp <= NamesVisible.Count; temp++)
                {
                    string xpathDelete = "//tr[7]/td[4]/button/span/i]";
                    LinkHelper.ClickLink(By.XPath(xpathDelete));
                    Thread.Sleep(2000);
                    string xpathDelete1 = "//button[contains(text(),'Remove')]";
                    LinkHelper.ClickLink(By.XPath(xpathDelete1));
                    Thread.Sleep(1000);
                    LinkHelper.ClickLink(By.XPath("//span[contains(text(),' Yes ')]"));
                    Thread.Sleep(2000);
                    LinkHelper.ClickLink(By.XPath("//span[contains(text(),'Okay')]"));
                }
            }
            else
            {
                Logger.Info("The searched template is not visible for delete");
            }
        }

        [Then(@"The email template should be deleted from the database")]
        public void ThenTheEmailTemplateShouldBeDeletedFromTheDatabase()
        {
            Thread.Sleep(1000);
            TextBoxHelper.ClearText(By.XPath("//input[@placeholder='Search in Template...']"));

            TextBoxHelper.TypeInTexBox(By.XPath("//input[@placeholder='Search in Template...']"), NameEmailTemplate);
            Thread.Sleep(1000);
            if (ObjectRepository.Driver.FindElement(By.XPath("//div[contains(text(),'No Template Found!')]")).Displayed)
            {
                Logger.Info("Verified that the templates has been deleted successfully");
            }
            else
            {
                Logger.Info("Template is still visible in list after deleting");
            }

        }

        //--------MergeAndComposeEmail---------
        //---Template listing should get displayed----
        [When(@"user selects Email Template option")]
        public void WhenUserSelectsEmailTemplateOption()
        {
            Thread.Sleep(5000);
            LinkHelper.ClickLink(By.XPath("//span[contains(text(),'Email Template')]"));
            //JavaScriptExecutor.ScrollToAndClick(By.XPath("//span[text()='Email Template']"));
        }
        [When(@"the desired list is selected")]
        public void WhenTheDesiredListIsSelected()
        {
            //TBD 
        }

        [Then(@"template should be selected from Template List")]
        public void ThenTemplateShouldBeSelectedFromTemplateList()
        {
            Boolean staus = GenericHelper.IsElemetPresent(By.XPath("//tbody/tr[1]/td[1]"));
            if (staus)
            {
                Logger.Info("Template is selected");

            }
            else
            {
                Logger.Info("Template is not selected");
            }
        }

        [Given(@"the Email Composer page is open")]
        public void GivenTheEmailComposerPageIsOpen()
        {
            //Thread.Sleep(4000);
            //LinkHelper.ClickLink(By.XPath("//span[contains(text(),'Email Template')]"));
            Thread.Sleep(4000);
            LinkHelper.ClickLink(By.XPath("//tr[1]//td[5]//i[2]"));
        }

        [When(@"a user selects Add Attachment option")]
        public void WhenAUserSelectsAddAttachmentOption()
        {
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("//span[contains(text(),'Add attachment')]"));
            Thread.Sleep(1000);

            //LinkHelper.ClickLink(By.XPath("//label[@class='ng-tns-c202-379']"));//label[contains(text(),'Attach file')]
            LinkHelper.ClickLink(By.XPath("//label[contains(text(),'Attach file')]"));
            Thread.Sleep(2000);


        }
        [Then(@"the file is attached\.")]
        public void ThenTheFileIsAttached_()
        {
            Process.Start("D:\\FileUpload2CMD.exe", "D:\\Docs\\email.html");
            Logger.Info("upload file");
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("//span[contains(text(),'continue')]"));
            Logger.Info("click on continue button");
            Thread.Sleep(3000);
            LinkHelper.ClickLink(By.XPath("//span[@class='ng-star-inserted']"));
            Logger.Info("click on update button");
        }

    }
}
