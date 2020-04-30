using DemoProject1.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.Interfaces
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        string GetUsername();
        string GetPassword();
        int GetPageTimeOutTime();
        int GetElementLoadTimeout();


    }
}
