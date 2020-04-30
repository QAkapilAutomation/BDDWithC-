using DemoProject1.ComponentHelper;
using DemoProject1.Setting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject1.TestScripts
{
    [TestClass]
   public  class MouseEvent
    {
        [TestMethod]
        public void TestContextClick()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("draggable"));


            act.ContextClick(ele)
                .Build()
                .Perform();

            Thread.Sleep(5000);
        }

        [TestMethod]
        public void DranNDrop()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/dragdrop/events");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement src = ObjectRepository.Driver.FindElement(By.Id("draggable"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.Id("droptarget"));

            act.DragAndDrop(src, tar)
                .Build()
                .Perform();

            Thread.Sleep(4000);
        }


        [TestMethod]
        public void TestClicknHold()
        {
            NavigationHelper.NavigateToUrl("http://demos.telerik.com/kendo-ui/sortable/index");
            Actions act = new Actions(ObjectRepository.Driver);
            IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[12]"));
            IWebElement tar = ObjectRepository.Driver.FindElement(By.XPath("//ul[@id='sortable-basic']/li[2]/span"));
            act.ClickAndHold(ele)
                .MoveToElement(tar, 0, 30)
                .Release()
                .Build()
                .Perform();

            Thread.Sleep(10000);
        }
    }
}

