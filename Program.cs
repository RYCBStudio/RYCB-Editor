﻿using IDE.Utils;
using Microsoft.VisualBasic.Devices;
using SmileWei.EmbeddedEXE;
using Sunny.UI;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace IDE
{
    static class Program
    {
        internal static readonly string STARTUP_PATH = Application.StartupPath;
        internal static bool isInitialized = false;
        private static bool isLightEdit = false;
        private static string param = "";
        private static Form class_;
        private static readonly Stopwatch w = new();
        private static readonly Stopwatch startTimer = new();
        private static int CrashAttempts = 0;
        internal static Entry splash;
        internal static TimeSpan startTime;
        internal static IniFile reConf = new(STARTUP_PATH + "\\Config\\.reconf", System.Text.Encoding.UTF8);

        [STAThread]
        static void Main(string[] args)
        {
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            bool createdNew;
            var CurrentMutexForRE = new Mutex(true, "RYCB_Editor_Running", out createdNew);
            if (!createdNew)
            {
                MessageBox.Show("Another instance of this program is running, please close the instance and try again.");
                return;
            }
            else
            {
                CurrentMutexForRE.ReleaseMutex();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            w.Start();
            startTimer.Start();
            GlobalSettings.MainFontName = reConf.Read("Display", "DisplayFont", "Microsoft YaHei UI").FontExists("Microsoft YaHei UI");

            ParseArguments(args);

            splash = new(isLightEdit);
            splash.Show();
            GlobalSettings.CrashAttempts = reConf.ReadInt("CrashHanding", "CrashAttempts", 3);
            if (GlobalSettings.CrashAttempts == 0)
            {
                GlobalSettings.CrashAttempts = int.MaxValue;
            }
            var sys = new ComputerInfo().OSFullName;
            var sysInfo = sys.Contains("Microsoft Windows");

            if (!sysInfo)
            {
                return;
            }

            class_ = param == "" ? new Main() : new Main(param);

            switch (true)
            {
                case bool _ when sys.Contains("10"):
                case bool _ when sys.Contains("11"):
                case bool _ when sys.Contains("8"):
                case bool _ when sys.Contains("8.1"):
                    func_1a1();
                    break;
                default:
                    MessageBox.Show("您的计算机版本过低，请升级系统后打开此程序！");
                    break;
            }

            End();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            IDE.Main.LOGGER.WriteErrLog(ex, EnumMsgLevel.ERROR, EnumPort.CLIENT);
            Infrastructure.MiniDump.TryDump(STARTUP_PATH + $"\\Crash\\{DateTime.Now:yyyy-MM-dd_HH-mm-ss+fff}.dmp");
            ((Main)class_).msgBox.MainForm = class_;
            ((Main)class_).msgBox.CurrentMsgType = MsgBox.MsgType.Error;
            ((Main)class_).msgBox.CurrentException = ex;
            ((Main)class_).msgBox.Show();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;

            if (e.IsTerminating)
            {
                End(ex);
            }
        }

        private static void ParseArguments(string[] args)
        {
            switch (args.Length)
            {
                case 1:
                    isLightEdit = true;
                    param = args[0];
                    break;
                case 2:
                    switch (args[0])
                    {
                        case "-LE":
                        case "-le":
                        case "-lightedit":
                        case "-LightEdit":
                            isLightEdit = true;
                            param = args[1];
                            break;
                        case "-XSHD":
                        case "-xshd":
                        case "-xv":
                        case "-ve":
                            class_ = new XshdVisualEditor(args[1]);
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void func_1a1()
        {
            Initializer.Init();
            startTimer.Stop();
            startTime = startTimer.Elapsed;
            splash.Hide();
            Application.Run(class_);
            isInitialized = true;
        }

        private static void End(Exception ex)
        {
            if (CrashAttempts == GlobalSettings.CrashAttempts - 1 || !isInitialized)
            {
                IDE.Main.LOGGER.WriteLog("RYCB Editor 已崩溃。崩溃尝试次数：" + (CrashAttempts + 1).ToString());

                w.Stop();
                var time = w.Elapsed;
                var filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\time";
                File.WriteAllText(filePath, time.TotalSeconds.ToString());
                CrashHandler crashHandler = new(ex, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)); ;
                crashHandler.CollectCrashInfo();
                crashHandler.WriteDumpFile();
                ErrorAnalysiser EA = new(ex);
                EA.GetExceptions();
                Infrastructure.MiniDump.TryDump(STARTUP_PATH + $"\\Crash\\{DateTime.Now:yyyy-MM-dd_HH-mm-ss+fff}.dmp");
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                CrashAttempts++;
                IDE.Main.LOGGER.WriteLog($"捕获异常：{{Type={ex.GetType()}, Message={ex.Message}}}\t尝试次数：{CrashAttempts}(距离崩溃还剩{GlobalSettings.CrashAttempts - CrashAttempts}次异常)", EnumMsgLevel.FATAL, EnumPort.CLIENT, EnumModule.MAIN); ;
            }
        }

        private static void End()
        {
            w.Stop();
            var time = w.Elapsed;
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RYCB\\IDE\\protect\\time";
            File.WriteAllText(filePath, time.TotalSeconds.ToString());
        }

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
