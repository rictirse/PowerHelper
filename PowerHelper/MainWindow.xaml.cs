using PowerHelper.Helpers;
using System.Windows;

namespace PowerHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            taskbar.Dispose();
        }

        private void taskbar_PreviewTrayPopupOpen(object sender, RoutedEventArgs e)
        {
            string s = "";
        }
    }
}
