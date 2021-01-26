using System;

#if NETSTANDARD
using UnityEngine;
#endif

namespace Mirror.Runtime.Logging
{
    public static class Debug
    {
        public static void LogException(Exception ex)
        {
#if NETSTANDARD
            Debug.LogException(ex);
#else
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.ToString());
#endif
        }

        public static void LogWarningFormat(string format, params object[] args)
        {
#if NETSTANDARD
            Debug.LogWarningFormat(format, args);
#else
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(format, args);
#endif
        }

        public static void AssertFormat(bool condition, string format, params object[] args)
        {
#if NETSTANDARD
            Debug.AssertFormat(condition, format, args);
#else
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(format, args);
#endif
        }
    }

#if NETSTANDARD
    public static class LogFactory
    {
        internal static readonly Dictionary<string, ILogger> loggers = new Dictionary<string, ILogger>();

        public static ILogger GetLogger<T>(LogType defaultLogLevel = LogType.Warning)
        {
            return GetLogger(typeof(T).Name, defaultLogLevel);
        }

        public static ILogger GetLogger(System.Type type, LogType defaultLogLevel = LogType.Warning)
        {
            return GetLogger(type.Name, defaultLogLevel);
        }

        public static ILogger GetLogger(string loggerName, LogType defaultLogLevel = LogType.Warning)
        {
            if (loggers.TryGetValue(loggerName, out ILogger logger))
            {
                return logger;
            }

            logger = new Logger(Debug.unityLogger)
            {
                // by default, log warnings and up
                filterLogType = defaultLogLevel
            };

            loggers[loggerName] = logger;
            return logger;
        }
    }


    public static class ILoggerExtensions
    {
        public static void LogError(this ILogger logger, object message)
        {
            logger.LogError(null, message);
        }

        public static void LogWarning(this ILogger logger, object message)
        {
            logger.LogWarning(null, message);
        }

        public static bool LogEnabled(this ILogger logger) => logger.IsLogTypeAllowed(LogType.Log);

        public static bool WarnEnabled(this ILogger logger) => logger.IsLogTypeAllowed(LogType.Warning);

        public static bool ErrorEnabled(this ILogger logger) => logger.IsLogTypeAllowed(LogType.Warning);
    }
#endif
}