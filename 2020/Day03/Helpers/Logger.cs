using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Helpers
{
    public enum LogLevel
    {
        Verbose = 0,
        Debug = 10,
        Info = 20,
        Warn = 30,
        Error = 40,
        Fatal = 50,
    }

    public static class Logger
    {
        public static void Log(LogLevel level, string message)
        {
            if (level.CompareTo(HardCodedConfig.LogLevel) < 0)
            {
                return;
            }
            var timeStamp = DateTime.Now;
            WriteToConsole(timeStamp, level, message);
        }

        public static void WriteToConsole(DateTime dateTime, LogLevel level, string message)
        {
            string dateTimeStr = dateTime.ToString("yyyy.MM.dd HH:mm:ss.fff");
            string line = String.Format("{0}\t{1}\t{2}", dateTimeStr, level.ToString(), message);
            Console.WriteLine(line);
        }

        public static void Debug(string message) { Log(LogLevel.Debug, message); }
        public static void Info(string message) { Log(LogLevel.Info, message); }
        public static void Warn(string message) { Log(LogLevel.Warn, message); }
        public static void Error(string message) { Log(LogLevel.Error, message); }
        public static void Fatal(string message) { Log(LogLevel.Fatal, message); }

        public static void Log(LogLevel level, string format, params object[] args) { Log(level, string.Format(format, args)); }
        public static void Debug(string format, params object[] args) { Log(LogLevel.Debug, format, args); }
        public static void Info(string format, params object[] args) { Log(LogLevel.Info, format, args); }
        public static void Warn(string format, params object[] args) { Log(LogLevel.Warn, format, args); }
        public static void Error(string format, params object[] args) { Log(LogLevel.Error, format, args); }
        public static void Fatal(string format, params object[] args) { Log(LogLevel.Fatal, format, args); }

        public static void Log(LogLevel level, object obj) { Log(level, obj?.ToString() ?? ""); }
        public static void Debug(object obj) { Log(LogLevel.Debug, obj); }
        public static void Info(object obj) { Log(LogLevel.Info, obj); }
        public static void Warn(object obj) { Log(LogLevel.Warn, obj); }
        public static void Error(object obj) { Log(LogLevel.Error, obj); }
        public static void Fatal(object obj) { Log(LogLevel.Fatal, obj); }
    }
}
