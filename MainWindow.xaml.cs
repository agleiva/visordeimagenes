using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace WpfApp1
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void ListBoxItem_MouseMove(object sender, MouseEventArgs e)
        {
            var file = (KeyValuePair<string,string>) (sender as FrameworkElement).DataContext;
            Image.Source = new BitmapImage(new Uri(file.Key, UriKind.Absolute));
        }

        private void CargarImagenes_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { Filter = "Todos|*.*|Imagen|*.bmp; *.png; *.jpg", Multiselect = true};
            if (dlg.ShowDialog() ?? false)
                DataContext =
                    dlg.FileNames
                       .ToDictionary(x => x, Path.GetFileName);
        }
    }
}
