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

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            PowerCfgCli.SetCurrentAcPROCTHROTTLEMAX(App.g_Plan!.AcValue);
            PowerCfgCli.SetCurrentDcPROCTHROTTLEMAX(App.g_Plan!.DcValue);
        }
    }
}
