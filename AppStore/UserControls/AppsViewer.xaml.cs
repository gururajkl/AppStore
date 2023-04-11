using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AppStore.UserControls
{
    public partial class AppsViewer : UserControl
    {
        List<AnApp> presentedApps = new List<AnApp>();
        int widthOfOneApp;

        public AppsViewer()
        {
            InitializeComponent();
            AppsList.ItemsSource = presentedApps;
            for (int i = 0; i < 9; i++)
            {
                AnApp app = new AnApp();
                presentedApps.Add(app);
            }
        }

        private void ScrollLeft_Click(object sender, RoutedEventArgs e)
        {
             widthOfOneApp = (int)presentedApps.First().ActualWidth +
                2 * (int)presentedApps.First().Margin.Left;

            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset - 1 * widthOfOneApp);
        }

        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            widthOfOneApp = (int)presentedApps.First().ActualWidth +
                2 * (int)presentedApps.First().Margin.Left;

            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset + 1 * widthOfOneApp);   
        }
    }
}
