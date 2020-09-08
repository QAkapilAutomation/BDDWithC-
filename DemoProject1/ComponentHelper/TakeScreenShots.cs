using AventStack.ExtentReports;
using DemoProject1.Setting;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
    public class TakeScreenShots
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof(GenericHelper));

        public static string CaptureScreenshoots(string filename)
        {
            ITakesScreenshot ts = (ITakesScreenshot)ObjectRepository.Driver;
            Screenshot scr = ts.GetScreenshot();
            String path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss");
            Logger.Info(" ScreenShot Taken : " + filename);
            string finalPath = path.Substring(0, path.LastIndexOf("bin")) + "ScreenShots\\" + filename;
            string localpath = new Uri(finalPath).LocalPath;
            Directory.CreateDirectory(localpath);
            string imagePath= $"{ localpath}\\img_"+ DateTime.Now.ToString("MMdd_HHmm") +".jpeg";
            scr.SaveAsFile(imagePath, ScreenshotImageFormat.Jpeg);
            return localpath;
        }
        //public static void CaptureScreenshoots(string filename = "Screen")
        //{
        //    Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
        //    if (filename.Equals("Screen"))
        //    {

        //        filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
        //        screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        //        return;
        //    }
        //    screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);

        //}

        public  MediaEntityModelProvider CaptureScreenshotsAndReturnModel(string Name)
        {

            var scr = ((ITakesScreenshot)ObjectRepository.Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(scr, Name).Build();


        }



    }

}

