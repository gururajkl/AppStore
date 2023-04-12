using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppStore.UserControls
{
    public partial class AppsViewer : UserControl
    {
        List<AnApp> presentedApps = new List<AnApp>();
        int widthOfOneApp;
        
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public AppsViewer()
        {
            InitializeComponent();
            AppsList.ItemsSource = presentedApps;
            for (int i = 0; i < 9; i++)
            {
                AnApp app = new AnApp();
                app.AppClicked += CurrentAppClicked;
                presentedApps.Add(app);
            }
        }

        public void CurrentAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
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

        private void AppsScrollView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            var eventArgs = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            eventArgs.RoutedEvent = UIElement.MouseWheelEvent;
            eventArgs.Source = sender;
            var parent = ((Control)sender).Parent as UIElement;
            parent.RaiseEvent(eventArgs);
        }
    }
}
