using LPCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace LPSpy
{
    static class Program
    {
        const string ApplicationName = "LPSpy";

        const string _ConfigPath = @"LPLogger.config.xml";

        /// <summary>
        /// $WinForm_CSharp_Program_Main$
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogFactory.LoadLogConfigFile(_ConfigPath);

            Run(() =>
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new SpyMainWindow());
                });
        }

        public static bool Run(Action action)
        {
            bool isNewInstance = true;
            Mutex mutex = null;
            try
            {
                mutex = new Mutex(true, ApplicationName, out isNewInstance);

                if (true || isNewInstance)
                {
                    if (SpySettings.Language == AppLanguageEnum.English)
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("zh-CN");
                    }
                    action();
                    return true;
                }
                else
                {
                    //TODO bring app to top
                    MessageBox.Show("Application already running");
                }
            }
            finally
            {
                if (isNewInstance && mutex != null)
                {
                    mutex.ReleaseMutex();
                }
            }
            return false;
        }
    }
}
