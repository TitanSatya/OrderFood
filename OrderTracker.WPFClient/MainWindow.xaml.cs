using OrderTracker.WPFClient.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace OrderTracker.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; } = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

