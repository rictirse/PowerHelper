using PowerHelper.Helpers;
using System.Windows.Controls;

namespace PowerHelper
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PowerSlider : UserControl
    {
        public PowerSlider()
        {
            InitializeComponent();
            this.DataContext = App.g_Plan;
        }

        private async void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var result = await PowerCfgCli.GetCurrentPowerCfgPlan();

            if (App.g_Plan!.AcValue != result.acValue)
            { 
                await PowerCfgCli.SetCurrentAcPROCTHROTTLEMAX(App.g_Plan!.AcValue);
            }

            if (App.g_Plan!.DcValue != result.dcValue)
            { 
                await PowerCfgCli.SetCurrentDcPROCTHROTTLEMAX(App.g_Plan!.DcValue);
            }
        }
    }
}
