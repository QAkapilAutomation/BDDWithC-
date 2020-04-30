using AventStack.ExtentReports;
using DemoProject1.ComponentHelper;
using DemoProject1.ExcelReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Threading;

namespace DemoProject1.TestScripts
{
    [TestClass]
   public  class ExcelTest
    {
        
        //[TestInitialize]
        //public static void StartReport()
        //{
        //    string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        //    string actualPath = path.Substring(0, path.LastIndexOf("bin"));
        //    string projectPath = new Uri(actualPath).LocalPath;
        //    string reportName= DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + "Reports\\ DemoReport.html";
        //    string reportPath = projectPath + reportName;
            
            

        //    extent = new ExtentReports();
        //    var htmlReporter = new ExtentHtmlReporter(reportPath);
        //    extent.AttachReporter(htmlReporter);
            

        //}
        [TestMethod, TestCategory("smoke")]
        public void testExcel()
        {
            
            String xlPath = ConfigurationManager.AppSettings.Get(@"ExcelPath");
            int rows = ExcelReaderHelper.GetTotalRows(xlPath, "Sheet1");
            for (int i=1;i< rows; i++)
            {
                var FirstName = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", i, 0);
                var LastName = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", i, 1);
                var Number = ExcelReaderHelper.GetCellData(xlPath, "Sheet1", i, 2);
                NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
                Thread.Sleep(5000);
                TextBoxHelper.TypeInTexBox(By.Name("firstName"), FirstName.ToString());
                TextBoxHelper.TypeInTexBox(By.Name("lastName"), LastName.ToString());
                TextBoxHelper.TypeInTexBox(By.Name("phone"), Number.ToString());
                ButtonHelper.ClickOnButton(By.Name("submit"));
                WindowHelper.GetTitle();
                //Reporter.LogPassingTestStepToBugLogger("Test passes");
                bool status = AssertHelper.AreEqual(WindowHelper.GetTitle(), "Register:");
                if (status)
                {
                    //Reporter.LogPassingTestStepToBugLogger("Test passes");
                    //Reporter.ReportTestOutcome(@"C:\Users\KAPIL\Documents\Reports");
                }
                else
                {
                   //test.Log(Status.Fail, "title not verifed");
                }
                Thread.Sleep(5000);
                LinkHelper.ClickLink(By.XPath("//a[text()='REGISTER']"));

            }
            


        }
        
    }
}
