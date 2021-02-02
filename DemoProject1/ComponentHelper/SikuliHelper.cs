using Sikuli4Net.sikuli_REST;
using Sikuli4Net.sikuli_UTIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
    public class SikuliHelper
    {
        public static void ClickOnImage(String path)
        {
            APILauncher launcher = new APILauncher(true);
            launcher.Start();
            Screen sc = new Screen();
            Thread.Sleep(2000);
            //Pattern pattern = new Pattern(@"D:\sk\image1.PNG");
            Pattern pattern = new Pattern(path);
            sc.Click(pattern);
            Thread.Sleep(2000);
            launcher.Stop();
        }
    }
}
