using DemoProject1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject1.Configuration
{
    public class XmlReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            throw new NotImplementedException();
        }

        public int GetElementLoadTimeout()
        {
            throw new NotImplementedException();
        }

        public int GetPageTimeOutTime()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            throw new NotImplementedException();
        }

        public string GetUsername()
        {
            throw new NotImplementedException();
        }

        BrowserType? IConfig.GetBrowser()
        {
            throw new NotImplementedException();
        }
    }
}
