using AppStore.UserControls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AppStore.Pages
{
    public partial class Main : Page
    {
        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public Main()
        {
            InitializeComponent();

            DealsAppsViewer.AppClicked += AnAppClicked;

            MostPopularProductivityAppsViewer.AppClicked += AnAppClicked;
            ProductivityL1.AppClicked += AnAppClicked;

            EntertainmentAppsViewer.AppClicked += AnAppClicked;

            GameAppsViewer.AppClicked += AnAppClicked;

            FeaturesAppsViewer.AppClicked += AnAppClicked;
            MostPopularAppsViewer.AppClicked += AnAppClicked;
            TopFreeAppsViewer.AppClicked += AnAppClicked;
            TopFreeGamesAppsViewer.AppClicked += AnAppClicked;
        }

        public void AnAppClicked(AnApp sender, RoutedEventArgs e)
        {
            AppClicked(sender, e);
        }

        #region Animation in CodeBehind
        private void MainScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            UIElement element = sender as UIElement;
            element.Opacity = 0;
            DoubleAnimation animation = new DoubleAnimation()
            {
                To = 1,
                From = 0,
                Duration = new Duration(new TimeSpan(0, 0, 20))
            };
            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }
        #endregion
    }
}