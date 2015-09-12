using System;
using System.Reflection;
using log4net;

namespace Com.Framework.Common.Logging
{
    public class Log4NetConfigurationException : Exception
    {
        public Log4NetConfigurationException(string message) : base(message) { }
    }

    public static class Logger
    {
        private const ConsoleColor DebugColour = ConsoleColor.DarkGray;
        private const ConsoleColor InfoColour = ConsoleColor.White;
        private const ConsoleColor ErrorColour = ConsoleColor.Yellow;
        private const ConsoleColor FatalColour = ConsoleColor.Red;
        private const ConsoleColor DefaultColour = ConsoleColor.White;

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Error(string msg, Exception e = null)
        {
            Print(msg, ErrorColour, e);
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (!Log.IsErrorEnabled) return;
            if (e != null)
            {
                Log.Error(String.Format("Error: {0},", msg), e);
            }
            else
            {
                Log.Error(String.Format("Error: {0},", msg));
            }
        }

        public static void Info(string msg, Exception e = null)
        {
            Print(msg, InfoColour, e);
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (!Log.IsInfoEnabled) return;
            if (e != null)
            {
                Log.Info(String.Format("Info: {0},", msg), e);
            }
            else
            {
                Log.Info(String.Format("Info: {0},", msg));
            }
        }

        public static void Debug(string msg, Exception e = null)
        {
            Print(msg, DebugColour, e);
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (!Log.IsDebugEnabled) return;
            if (e != null)
            {
                Log.Debug(String.Format("Debug: {0},", msg), e);
            }
            else
            {
                Log.Debug(String.Format("Debug: {0},", msg));
            }
        }

        public static void Fatal(string msg, Exception e = null)
        {
            Print(msg, FatalColour, e);
            if (Log == null)
            {
                throw new Log4NetConfigurationException("Logger.InvalidConfiguration");
            }
            if (!Log.IsFatalEnabled) return;

            if (e != null)
            {
                Log.Fatal(String.Format("Fatal: {0},", msg), e);
            }
            else
            {
                Log.Fatal(String.Format("Fatal: {0},", msg));
            }
        }

        public static void Print(string msg, ConsoleColor colour, Exception e = null)
        {
            Console.ForegroundColor = colour;
            if (e != null)
            {
                Console.WriteLine("{0}, {1}", msg, e.Message);
            }
            else
            {
                Console.WriteLine("{0}", msg);
            }
            Console.ForegroundColor = DefaultColour;
        }
    }
}
