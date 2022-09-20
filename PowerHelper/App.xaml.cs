using PowerHelper.Helpers;
using PowerHelper.ViewModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

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
            Startup += async (s, e) => await App_Startup(s, e);
            g_Plan = new Plan();

            g_Plan.MaxClockSpeed = WMIHelper.GetClockSpeed();
        }

        private async Task App_Startup(object sender, StartupEventArgs e)
        {
            Mutex = new Mutex(true, "PowerHelper", out var ret);
            if (!ret) Environment.Exit(0);

            var value = await PowerCfgCli.GetCurrentPowerCfgPlan();

            g_Plan!.AcValue = value.acValue;
            g_Plan!.DcValue = value.dcValue;
        }
    }
}
