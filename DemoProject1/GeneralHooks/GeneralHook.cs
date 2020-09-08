using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using DemoProject1.ComponentHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoProject1.GeneralHooks
{
    [Binding]
    public sealed class GeneralHook
    {
        private static ScenarioContext _scenarioContext;
        private static FeatureContext featureContext;
        private static ExtentReports extentReports;
        private static ExtentHtmlReporter extentHtmlReporter;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        public static ExtentTest test;
        private static string ApplicationDebuggingFolder => @"C:\Users\KAPIL\source\repos\DemoProject1\DemoProject1\Reports\reports";
        public static string LatestResultsReportFolder { get; set; }
        private static ExtentReports ReportManager { get; set; }
        private static string HtmlReportFullPath { get; set; }
        


        [BeforeTestRun]
       public static void BeforeTestRun()
        {
            var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
            LatestResultsReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultsReportFolder);
            HtmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
            extentHtmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            extentReports = new ExtentReports();
            extentReports.AddSystemInfo("HostName", "Kapil Window");
            extentReports.AddSystemInfo("UserName", "Kapil");
            extentReports.AddSystemInfo("Environment", "QA");
            extentReports.AddSystemInfo("OS", "Window10");
            extentReports.AttachReporter(extentHtmlReporter);
           test = extentReports.CreateTest("logs" +
               "");


        }

        [BeforeFeature()]
        public static void BeforeFeatureStart(FeatureContext featureContext)
        {
            if(null != featureContext)
            {
               
                feature = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
            }
        }


        [BeforeScenario()]
        public static void BeforeScenariostart(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            
            {
                
                _scenarioContext = scenarioContext;
                scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            }
        }
        [AfterStep]
        public void AfterEachStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            TakeScreenShots ts = new TakeScreenShots();

            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    if (_scenarioContext.TestError != null)
                    {
                        
                        var mediaEntity = ts.CaptureScreenshotsAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim());
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace,mediaEntity);
                    }
                    else
                    {
                        scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                   // CreateNode<Given>();
                break;
                case ScenarioBlock.When:
                    if (_scenarioContext.TestError != null)
                    {
                       
                        var mediaEntity = ts.CaptureScreenshotsAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim());
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace,mediaEntity);
                        
                    }
                    else
                    {
                        scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }

                    // CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    if (_scenarioContext.TestError != null)
                    {
                        
                        var mediaEntity = ts.CaptureScreenshotsAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim());
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace,mediaEntity);
                    }
                    else
                    {
                        scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }

                    //CreateNode<Then>();
                break;
                default:
                    if (_scenarioContext.TestError != null)
                    {
                        
                        var mediaEntity = ts.CaptureScreenshotsAndReturnModel(_scenarioContext.ScenarioInfo.Title.Trim());
                        scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace,mediaEntity);
                    }
                    else
                    {
                        scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Pass("");
                    }
                   // CreateNode<And>();

                break;
            }

        }

       
        [AfterTestRun]
        public static void AfterTestRun()
        {
            extentReports.Flush();
        }

        [BeforeFeature("Tag1")]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("BeforeFeature Hook");
        }

        [AfterFeature("Tag1")]
        public static void AfterFeature()
        {
            Console.WriteLine("AfterFeature Hook");
        }

        [BeforeScenario("Tag1")]
        public static void BeforeScenario()
        {
            Console.WriteLine("BeforeScenario Hook");
        }

        [BeforeScenario("Tag2")]
        public static void BeforeScenarioContextInjection(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
           //featureContext = featureContext;
           // scenarioContext = scenarioContext;
        }


        [AfterScenario]
        public static void AfterScenario()
        {
            Console.WriteLine("AfterScenario Hook");
            if (ScenarioContext.Current.TestError != null)
            {
                string name = ScenarioContext.Current.ScenarioInfo.Title + ".jpeg";
                TakeScreenShots.CaptureScreenshoots(name);
                Console.WriteLine(ScenarioContext.Current.TestError.Message);
                Console.WriteLine(ScenarioContext.Current.TestError.StackTrace);
            }
        }

    }
}
