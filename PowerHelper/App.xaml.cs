using PowerHelper.Helpers;
using PowerHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows;

namespace PowerHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Plan? g_Plan { get; set; }

        public App()
        {
            g_Plan = PowerCfgCli.GetCurrentPowerCfgStatus();

            if (g_Plan == null) throw new Exception("取得PowerCfg異常");

            g_Plan.MaxClockSpeed = WMIHelper.GetClockSpeed();
        }
    }
}
