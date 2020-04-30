﻿using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
    public class CheckBoxHelper
    {
        private static IWebElement element;
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(CheckBoxHelper));

        public static void CheckedCheckBox(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
            Logger.Info(" Click on Check box : " + locator);
        }
        public static bool IsCheckBoxChecked(By locator)
        {
            element = GenericHelper.GetElement(locator);
            string flag = element.GetAttribute("checked");
            Logger.Info(" Is CheckBox Checked : " + locator);

            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");


        }
    }
}
