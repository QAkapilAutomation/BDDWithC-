using DemoProject1.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject1.PageLibrary
{
   public  class EmailTemplate:WordTemplate
    {
        private IWebDriver driver;

        // Declaring all the web element for the Email template page 

        [FindsBy(How = How.XPath, Using = "//input[@ng-reflect-placeholder='From']")]
        private readonly IWebElement From;

        [FindsBy(How = How.XPath, Using = "//input[@ng-reflect-placeholder='To']")]
        private readonly IWebElement To;

        [FindsBy(How = How.XPath, Using = "//input[@ng-reflect-placeholder='Cc']")]
        private readonly IWebElement CC;

        [FindsBy(How = How.XPath, Using = "//input[@ng-reflect-placeholder='Subject']")]
        private readonly IWebElement subject;

        [FindsBy(How = How.XPath, Using = "//span[text()='Save']")]
        private readonly IWebElement saveButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Add attachment']")]
        private readonly IWebElement addAttachment;

        [FindsBy(How = How.XPath, Using = " //span[contains(text(),'continue')]")]
        private readonly IWebElement continueButton;

        [FindsBy(How = How.XPath, Using = " //span[text()='Template has been saved.']")]
        private readonly IWebElement SuccessMessage;



        public EmailTemplate(IWebDriver _driver): base(_driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;

        }

        public void typeinFormTextBox(String name)
        {
            TextBoxHelper.Sendkeys(From, name);
        }

        public void typeinToTextBox(String name)
        {
            TextBoxHelper.Sendkeys(To, name);
        }

        public void typeinCCTextBox(String name)
        {
            TextBoxHelper.Sendkeys(CC, name);
        }

        public void typeinSubjectTextBox(String name)
        {
            TextBoxHelper.Sendkeys(subject, name);
        }

        public Boolean VerifyThatAttachmentContainerCheckboxIsUnchecked()
        {
            Boolean status = CheckBoxHelper.IsCheckBoxChecked(By.XPath("//input[@name='attachContainer']"));
            return status;
        }

        //CheckBoxHelper.IsCheckBoxChecked(By.XPath("//input[@name='attachContainer']"));

        public void clickOnSaveButton()
        {
            GenericHelper.WaitForWebElement(By.XPath("//span[text()='Save']"),TimeSpan.FromSeconds(60));
            LinkHelper.click(saveButton);
        }

        public void addAttachmentForEmailTemplate()
        {

            LinkHelper.click(addAttachment);
            Thread.Sleep(2000);
            LinkHelper.click(attachFile);
            Thread.Sleep(2000);
            Process.Start("D:\\FileUpload2CMD.exe", "D:\\Docs\\test.docx");
            Thread.Sleep(2000);
            LinkHelper.click(continueButton);
        }

        public void verifySuccessMessage()
        {
            Thread.Sleep(4000);
            String actualMessage = SuccessMessage.Text;
            Console.WriteLine(actualMessage);
            //return AssertHelper.AreEqual(actualMessage, "Scripts");
            Assert.AreEqual("Template has been saved.", actualMessage);
        }

    }
}
