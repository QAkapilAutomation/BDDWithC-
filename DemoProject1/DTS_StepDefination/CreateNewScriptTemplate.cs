using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using DemoProject1.GeneralHooks;
using DemoProject1.PageLibrary;
using DemoProject1.Setting;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.DTS_StepDefination
{
    [Binding]
    public sealed class CreateNewScriptTemplate
    {
        // Creating action class object for mouse and keyboard event
        private readonly Actions act = new Actions(ObjectRepository.Driver);
        // Creating Logger object 
        ILog Logger = Log4NetHelper.GetLogger(typeof(CreateNewScriptTemplate));
        //Creating objects for page library 
        WordTemplate wTemplate = new WordTemplate(ObjectRepository.Driver);
        HomePage hPage = new HomePage(ObjectRepository.Driver);
        Script script = new Script(ObjectRepository.Driver);
        // Creating excel object to fetch data from excel
        private readonly static string xlPath = ConfigurationManager.AppSettings.Get("ExcelPath");

        String Name = ExcelReaderHelper.GetCellData(xlPath, "ScriptTemplate", 1, 0).ToString() + DateTime.Now.ToString("MMdd_HHmm");

        string group = ExcelReaderHelper.GetCellData(xlPath, "ScriptTemplate", 1, 1).ToString();

        string description = ExcelReaderHelper.GetCellData(xlPath, "ScriptTemplate", 1, 2).ToString();


        [When(@"I click on create Script by hovering the cursor to new template option")]
        public void WhenIClickOnCreateScriptByHoveringTheCursorToNewTemplateOption()
        {
            hPage.hoverToNewButtonAndClickScript();
        }

        [Then(@"I should be on Script template page")]
        public void ThenIShouldBeOnScriptTemplatePage()
        {
            Boolean status = script.verifyIamOnScriptTemplatePage();
            if (status == true)
            {
                Logger.Info("I am on the script templete page");
                
                GeneralHook.test.Log(Status.Pass, "I am on the script templete page");
            }
            else
            {
                Logger.Info("I am not on the script templete page");
                
            }
        }
        [When(@"I enter the required information in Script Template field")]
        public void WhenIEnterTheRequiredInformationInScriptTemplateField()
        {
            Thread.Sleep(2000);
            wTemplate.typeinTemplateName(Name);
           // wTemplate.typeinGroupName(group);
            wTemplate.typeindescription(description);
            Thread.Sleep(3000);
            script.mergeField();


        }

        [Then(@"i should see the script has been saved")]
        public void ThenIShouldSeeTheScriptHasBeenSaved()
        {
            script.verifySuccessMessage();
            
        }



    }
}
