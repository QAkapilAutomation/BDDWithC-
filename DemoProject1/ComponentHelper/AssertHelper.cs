using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
   public  class AssertHelper
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(AssertHelper));
        public static Boolean AreEqual(string actualresult ,string expectedresult)
        {
            if(actualresult.Equals(expectedresult))
            {
                Logger.Info("Actaual result is equal to expected result");
                return true;
                
            }
            else 
            {
                Logger.Info("Actaual result is not equal to expected result");
                return false; 
            }

        }
    }
}
