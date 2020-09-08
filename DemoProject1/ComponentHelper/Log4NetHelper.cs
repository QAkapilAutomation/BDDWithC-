using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace DemoProject1.ComponentHelper
{
   public  class Log4NetHelper
    {
        #region Field

        private static ILog _logger;
        private static ILog _xmlLogger;
        private static ConsoleAppender _consoleAppender;
        private static FileAppender _fileAppender;
        private static RollingFileAppender _rollingFileAppender;
        private static string _layout = "%date{dd-MMM-yyyy-HH:mm:ss} [%class] [%level] [%method] - %message%newline";

        #endregion

        #region Property

        public static string Layout
        {
            set { _layout = value; }
        }

        #endregion

        #region Private

        private static PatternLayout GetPatternLayout()
        {
            var patterLayout = new PatternLayout()
            {
                ConversionPattern = _layout
            };
            patterLayout.ActivateOptions();
            return patterLayout;
        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
            };
            consoleAppender.ActivateOptions();
            return consoleAppender;
        }

        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = @"C:\Users\KAPIL\source\repos\DemoProject1\DemoProject1\Logs\FileLogger\SubSystem" + DateTime.UtcNow.ToString("yyyy.MM.dd.hh.mm.ss") +".log",
               
        };
            fileAppender.ActivateOptions();
            return fileAppender;
        }

        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                AppendToFile = true,
                File = "RollingFile.log",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                MaximumFileSize = "1MB",
                MaxSizeRollBackups = 1
            };
            rollingAppender.ActivateOptions();
            return rollingAppender;
        }

        #endregion

        #region Public

        public static ILog GetLogger(Type type)
        {
            if (_consoleAppender == null)
                _consoleAppender = GetConsoleAppender();

            if (_fileAppender == null)
                _fileAppender = GetFileAppender();

            if (_rollingFileAppender == null)
                _rollingFileAppender = GetRollingFileAppender();

            if (_logger != null)
                return _logger;

            BasicConfigurator.Configure(_consoleAppender, _fileAppender, _rollingFileAppender);
            _logger = LogManager.GetLogger(type);
            return _logger;

        }

        public static ILog GetXmlLogger(Type type)
        {
            if (_xmlLogger != null)
                return _xmlLogger;

            XmlConfigurator.Configure();
            _xmlLogger = LogManager.GetLogger(type);
            return _xmlLogger;
        }

        #endregion
    }
}

