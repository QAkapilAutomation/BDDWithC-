using DemoProject1.ComponentHelper;
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
    public class WordTemplate
    {
        private IWebDriver driver;

        // Declaring all the web element on the create word template page 

        [FindsBy(How = How.XPath, Using = "//input[@name='templateName']")]
        private readonly IWebElement templateName;

        [FindsBy(How = How.XPath, Using = " //input[@name='GroupName']")]
        private readonly IWebElement GroupName;


        [FindsBy(How = How.XPath, Using = "//textarea[@name='description']")]
        private readonly IWebElement description;


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Attach file')]")]
        public readonly IWebElement attachFile;

        [FindsBy(How = How.XPath, Using = "(//mat-option)[1]")]
        private readonly IWebElement firstOption;

        
        public WordTemplate(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
            this.driver = _driver;
        }

        public void typeinTemplateName(String name)
        {
            templateName.Clear();
            TextBoxHelper.Sendkeys(templateName, name);
        }
        public void typeinGroupName(String Group)
        {
            TextBoxHelper.Sendkeys(GroupName, Group);
            LinkHelper.click(firstOption);
        }
        public void typeindescription(String des)
        {
            description.Clear();
            TextBoxHelper.Sendkeys(description, des);
        }
        public void AttachFile()
        {
            LinkHelper.click(attachFile);
            Thread.Sleep(2000);
            Process.Start("D:\\FileUpload2CMD.exe", "D:\\Docs\\test.docx");
        }
    }
}
