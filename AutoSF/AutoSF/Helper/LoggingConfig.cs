using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Linq;

namespace AutoSF.Helper {
    public class LoggingConfig {

        //the Code has to be part of the main Class / mainmethod
        /*
        using NLog;
        MainWindow() {
            LoggingConfig.Initialize();
        }
        private static Logger log = LogManager.GetCurrentClassLogger();
        log.Debug("This Text will be logged");  //LogExample
        */

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

            //Adds output to Console
            ConsoleTarget consoleTarget = new ConsoleTarget();
            logConfig.AddTarget("console", consoleTarget);
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss.fff} [${level}] ${logger} - ${message}";
            rule = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            logConfig.LoggingRules.Add(rule);


            LogManager.Configuration = logConfig;

            //LogManager.DisableLogging();

            if(Environment.GetCommandLineArgs().Contains("debug")) { //only logs when debug is added as parameter.
                LogManager.EnableLogging();
            }
        }
    }
}