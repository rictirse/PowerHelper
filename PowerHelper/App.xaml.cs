using PowerHelper.Helpers;
using PowerHelper.ViewModel;
using System;
using System.Threading;
using System.Windows;

namespace PowerHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Mutex Mutex;
        public static Plan? g_Plan { get; set; }

        public App()
        {
            Startup += App_Startup;
            g_Plan = PowerCfgCli.GetCurrentPowerCfgStatus();

            if (g_Plan == null) throw new Exception("取得PowerCfg異常");

            g_Plan.MaxClockSpeed = WMIHelper.GetClockSpeed();
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            bool ret;
            Mutex = new Mutex(true, "PowerHelper", out ret);

            if (!ret) Environment.Exit(0);
        }
    }
}
