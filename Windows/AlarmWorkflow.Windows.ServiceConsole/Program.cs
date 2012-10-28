﻿using System;
using System.Threading;
using AlarmWorkflow.Shared;
using AlarmWorkflow.Shared.Diagnostics;
using AlarmWorkflow.Shared.Settings;
using AlarmWorkflow.Windows.Service.WcfServices;

namespace AlarmWorkflow.Windows.ServiceConsole
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Print welcome information :-)
            Console.WriteLine("********************************************************");
            Console.WriteLine("*                                                      *");
            Console.WriteLine("*   AlarmWorkflow Service Console                      *");
            Console.WriteLine("*                             FOR DEBUGGING ONLY!      *");
            Console.WriteLine("*                                                      *");
            Console.WriteLine("*        !!! Press ESCAPE to quit safely !!!           *");
            Console.WriteLine("*                                                      *");
            Console.WriteLine("********************************************************");
            Console.WriteLine();
            Console.WriteLine("Starting service...");

            // Catch all unhandled exceptions and display them.
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // TODO: This is duplex code! Rather create and instance of "AlarmWorkflow.Windows.Service.AlarmWorkflowService" (start and stop it)!

            // Register logger and listeners
            Logger.Instance.Initialize();
            Logger.Instance.RegisterListener(new RelayLoggingListener(LoggingListener));
            Logger.Instance.RegisterListener(new DiagnosticsLoggingListener());
            // Then initialize the settings.
            SettingsManager.Instance.Initialize();

            // Create the engine manually
            using (AlarmWorkflowEngine ac = new AlarmWorkflowEngine())
            {
                // Host the WCF-services, too
                WcfServicesHostManager shm = new WcfServicesHostManager(ac);

                try
                {
                    ac.Start();
                    shm.Initialize();
                }
                catch (Exception ex)
                {
                    WriteExceptionInformation(ex);
                }

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                    }

                    Thread.Sleep(1);
                }

                ac.Stop();
                shm.Shutdown();
            }

            SettingsManager.Instance.SaveSettings();

            Console.WriteLine("Shutting down complete. Press any key to exit.");
            Console.ReadKey();
        }

        private static void WriteExceptionInformation(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred while running the service. Error details:");
            Console.WriteLine("Type = {0}", exception.GetType().FullName);
            Console.WriteLine("Message = {0}", exception.Message);
            Console.WriteLine("StackTrace = {0}", exception.StackTrace);
            Console.WriteLine();

            Console.ResetColor();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            WriteExceptionInformation((Exception)e.ExceptionObject);
        }

        #region Event handlers

        private static void LoggingListener(LogEntry entry)
        {
            ConsoleColor back = ConsoleColor.Black;
            ConsoleColor fore = ConsoleColor.White;

            switch (entry.MessageType)
            {
                case LogType.None:
                case LogType.Info:
                    break;
                case LogType.Console:
                    fore = ConsoleColor.Blue;
                    break;
                case LogType.Debug:
                    fore = ConsoleColor.Cyan;
                    break;
                case LogType.Error:
                    fore = ConsoleColor.DarkYellow;
                    break;
                case LogType.Exception:
                    fore = ConsoleColor.Red;
                    break;
                case LogType.Trace:
                    fore = ConsoleColor.Gray;
                    break;
                case LogType.Warning:
                    fore = ConsoleColor.Yellow;
                    break;
                default:
                    break;
            }

            Console.BackgroundColor = back;
            Console.ForegroundColor = fore;
            Console.WriteLine("{0}", entry.Message);
        }

        #endregion
    }
}
