using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DemoProject1.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.TestScripts
{
    [TestClass]
   public  class extentReport
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        //[TestInitialize]
        //public static void StartReport(TestInitializeAttribute tia)
        //{
        //    extent = new ExtentReports();
        //    var htmlReporter = new ExtentHtmlReporter(@"C:\Users\KAPIL\source\repos\DemoProject1\DemoProject1\Reports\Demo.html");
        //    extent.AttachReporter(htmlReporter);

        //}
        //[TestCleanup]
        //public static void EndReport(TestCleanupAttribute tca)
        //{
        //    extent.Flush();
        //}
        [TestMethod]
        public void Test()
        {
            
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            //string format = DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") ;
            string reportPath = projectPath + "Reports\\DemoReport.HTML";
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            //var htmlReporter = new ExtentHtmlReporter(@"C:\Users\KAPIL\source\repos\DemoProject1\DemoProject1\Reports\Demo.html");
            extent.AttachReporter(htmlReporter);

            ExtentTest test = null;
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            test = extent.CreateTest("testExcel").Info("test started");
            test.Log(Status.Pass, "test case pass");
            extent.Flush();

        }

    }
}
