using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Linq;

namespace Alarm.Helper
    {
        public class LoggingConfig
        {
            public static void Initialize()
            {
                LoggingConfiguration logConfig = new LoggingConfiguration();

                FileTarget fileTarget = new FileTarget();
                logConfig.AddTarget("file", fileTarget);
                fileTarget.FileName = "Alarm.log";
                fileTarget.ArchiveOldFileOnStartup = true;
                fileTarget.ArchiveFileName = "Alarm.{#}.log";
                fileTarget.ArchiveNumbering = ArchiveNumberingMode.Rolling;
                fileTarget.MaxArchiveFiles = 7;
                fileTarget.ConcurrentWrites = true;
                fileTarget.KeepFileOpen = false;
                fileTarget.Layout = @"${date:format=HH\:mm\:ss.fff} [${level}] ${logger} - ${message}";
                LoggingRule rule = new LoggingRule("*", LogLevel.Debug, fileTarget);
                logConfig.LoggingRules.Add(rule);

                LogManager.Configuration = logConfig;

                //LogManager.DisableLogging();

                if (Environment.GetCommandLineArgs().Contains("debug"))
                { //only logs when debug is added as parameter.
                    LogManager.EnableLogging();
                }
            }
        }
    }

}