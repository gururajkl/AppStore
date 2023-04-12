using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AppStore.Pages
{
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
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
