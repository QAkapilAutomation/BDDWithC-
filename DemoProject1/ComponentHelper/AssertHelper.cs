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
        public static bool AreEqual(string actualresult ,string expectedresult)
        {
            try
            {
                Assert.AreEqual(actualresult, expectedresult);
                return true;
            }
            catch (Exception)
            {
                return false; 
            }

        }
    }
}
