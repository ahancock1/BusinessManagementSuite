using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

// http://www.codeproject.com/Tips/513202/Simplest-Implementation-of-log-net
namespace Restaurant.Common
{
    public class Log4NetConfigurationException : Exception
    {
        public Log4NetConfigurationException(string message) : base(message) { }
    }

    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Error(object msg)
        {
            if (log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (log.IsErrorEnabled)
            {
                log.Error(msg);
            }
        }

        public static void Error(object msg, Exception ex)
        {
            if (log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (log.IsErrorEnabled)
            {
                log.Error(msg, ex);
            }
        }

        public static void Error(Exception ex)
        {
            if (log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (log.IsErrorEnabled)
            {
                log.Error(ex.Message, ex);
            }
        }

        public static void Info(object msg)
        {
            if (log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (log.IsInfoEnabled)
            {
                log.Info(msg);
            }
        }

        public static void Debug(string msg)
        {
            if (log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (log.IsDebugEnabled)
            {
                log.Debug(msg);
            }

        }
    }
}
