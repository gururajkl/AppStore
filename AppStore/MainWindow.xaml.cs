using AppStore.Pages;
using System.Windows;

namespace AppStore
{
    public partial class MainWindow : Window
    {
        private Main MainWindowContentPage;

        public MainWindow()
        {
            InitializeComponent();
            MainWindowContentPage = new Main();
        }

        private void MainWindowFrame_Loaded(object sender, RoutedEventArgs e)
        {
            AppDetails appDetails = new AppDetails();
            MainWindowFrame.Content = appDetails;
        }
    }
}