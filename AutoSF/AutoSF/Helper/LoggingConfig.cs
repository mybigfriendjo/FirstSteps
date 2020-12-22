using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Linq;

namespace AutoSF.Helper {
    public class LoggingConfig {

        //the Code have to be part of the main Class / mainmethod
        /*
        using NLog;
        MainWindow() {
            LoggingConfig.Initialize();
        }
        private Logger logger = LogManager.GetCurrentClassLogger();
        logger.Debug("This Text will be logged");  //LogExample
        */
        private Logger logger = LogManager.GetCurrentClassLogger();

    public static void Initialize() {
            LoggingConfiguration logConfig = new LoggingConfiguration();

            FileTarget fileTarget = new FileTarget();
            logConfig.AddTarget("file", fileTarget);
            fileTarget.FileName = "AutoSF.log";
            fileTarget.ArchiveOldFileOnStartup = true;
            fileTarget.ArchiveFileName = "AutoSF.{#}.log";
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.Rolling;
            fileTarget.MaxArchiveFiles = 7;
            fileTarget.ConcurrentWrites = true;
            fileTarget.KeepFileOpen = false;
            fileTarget.Layout = @"${date:format=HH\:mm\:ss.fff} [${level}] ${logger} - ${message}";
            LoggingRule rule = new LoggingRule("*", LogLevel.Debug, fileTarget);
            logConfig.LoggingRules.Add(rule);

            LogManager.Configuration = logConfig;

            //LogManager.DisableLogging();

            if(Environment.GetCommandLineArgs().Contains("debug")) { //only logs when debug is added as parameter.
                LogManager.EnableLogging();
            }
        }
    }
}