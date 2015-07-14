using System;
using System.Reflection;
using log4net;

namespace Restaurant.Common
{
    public class Log4NetConfigurationException : Exception
    {
        public Log4NetConfigurationException(string message) : base(message) { }
    }

    public static class Logger
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Error(string msg)
        {
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (Log.IsErrorEnabled)
            {
                Log.Error(String.Format("Error: {0},", msg));
            }
        }

        public static void Error(string msg, Exception e)
        {
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (Log.IsErrorEnabled)
            {
                Log.Error(String.Format("Error: {0},", msg), e);
            }
        }

        public static void Info(string msg)
        {
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (Log.IsInfoEnabled)
            {
                Log.Info(String.Format("Info: {0},", msg));
            }
        }

        public static void Info(string msg, Exception e)
        {
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (Log.IsInfoEnabled)
            {
                Log.Info(String.Format("Info: {0},", msg), e);
            }
        }

        public static void Debug(string msg, Exception e)
        {
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (Log.IsDebugEnabled)
            {
                Log.Debug(String.Format("Debug: {0},", msg), e);
            }

        }

        public static void Fatal(string msg, Exception e)
        {
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (Log.IsFatalEnabled)
            {
                Log.Fatal(String.Format("Fatal: {0},", msg), e);
            }

        }
    }
}
