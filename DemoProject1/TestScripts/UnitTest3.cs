using System;
using System.Configuration;
using DemoProject1.ComponentHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject1.TestScripts
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestClass]
        public class UnitTest
        {

            [TestMethod]
            public void TestMethod3()
            {
                NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
                TakeScreenShots.TakeScreenShot1("name");
                //TakeScreenShots.TakeScreenShot1();

            }



        }

    }
}
