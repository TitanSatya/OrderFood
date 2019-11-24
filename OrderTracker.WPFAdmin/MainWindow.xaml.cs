using OrderTracker.WPFAdmin.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace OrderTracker.WPFAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        private void Window_DragOver(object sender, DragEventArgs e)
        {
            DragMove();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (System.Exception)
            {

                
            }
            
        }
    }
}
