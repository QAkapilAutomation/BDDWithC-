using DemoProject1.Setting;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
  
    public class WindowHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(WindowHelper));
        public static string GetTitle()
        {
            return ObjectRepository.Driver.Title;
            
        }
    }
}
