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
    }
}
