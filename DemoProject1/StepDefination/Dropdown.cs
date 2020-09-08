using DemoProject1.ComponentHelper;
using DemoProject1.PageLibrary;
using DemoProject1.Setting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace DemoProject1.StepDefination
{
    [Binding]
    public sealed class Dropdown
    {
        ClaimsReceived Cr = new ClaimsReceived(ObjectRepository.Driver);
        [Given(@"i am at home page")]
        public void GivenIAmAtHomePage()
        {
            NavigationHelper.NavigateToUrl(ConfigurationManager.AppSettings.Get("Weburl"));
            Thread.Sleep(10000);
            Cr.ClickOnShortTermDisabilityStandardReports();


        }

    }
}
