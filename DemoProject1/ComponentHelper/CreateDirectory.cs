using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.ComponentHelper
{
   public  class CreateDirectory
    {
        public static string createDir(string filename)
        {
            String path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            filename = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss");
            //Logger.Info(" ScreenShot Taken : " + filename);
            string finalPath = path.Substring(0, path.LastIndexOf("bin")) + "Logs\\" + filename;
            string localpath = new Uri(finalPath).LocalPath;
            Directory.CreateDirectory(localpath);
            string lastPath = $"{ localpath}\\subsystem" + DateTime.Now.ToString("MMdd_HHmm") + ".text";
            return lastPath;
        }

    }
}
