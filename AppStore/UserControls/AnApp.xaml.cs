using MiscUtil;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace AppStore.UserControls
{
    public partial class AnApp : UserControl
    {
        public string appName;
        public ImageSource appImageSource;

        public delegate void OnAppClicked(AnApp sender, RoutedEventArgs e);
        public event OnAppClicked AppClicked;

        public AnApp()
        {
            InitializeComponent();

            List<string> filepaths = Directory.GetFiles(Environment.CurrentDirectory +
                @"\..\..\Images", "*.png").ToList();

            FileInfo randomFile = new FileInfo(filepaths[StaticRandom.Next(filepaths.Count)]);

            ProductImage.Source = new BitmapImage(new Uri(randomFile.FullName,
                UriKind.RelativeOrAbsolute));

            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            AppName.Text = textInfo.ToTitleCase(
                randomFile.Name.Split('-').Last().Split('.').First());

            appName = AppName.Text;
            appImageSource = ProductImage.Source;
        }

        private void ProductImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AppClicked(this, e);
        }
    }
}
