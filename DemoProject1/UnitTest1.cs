using System;
using System.Configuration;
using DemoProject1.Configuration;
using DemoProject1.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //String browser =ConfigurationManager.AppSettings.Get("Browser");
            //Console.WriteLine(browser);
            //IConfig config = new AppConfigReader();
            ////Console.WriteLine(config.GetBrowser());
            //Console.WriteLine(config.GetUsername());
            //Console.WriteLine(config.GetPassword());

            Console.WriteLine("Test");
        }
    }
}
