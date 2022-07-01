using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            CefSettings settings = new CefSettings();
            settings.CachePath = AppDomain.CurrentDomain.BaseDirectory + "cache";
            settings.CefCommandLineArgs.Add("disable-application-cache", "1");
            settings.CefCommandLineArgs.Add("disable-session-storage", "1");
            if (!Cef.IsInitialized) Cef.Initialize(settings);

            InitializeComponent();

            MenuItem_Click_2(null, null);

            this.SizeChanged += new System.Windows.SizeChangedEventHandler(Window_SizeChanged);
        }

        private void Window_SizeChanged(object sender, System.EventArgs e)
        {
            //this.userControl.Width = this.ActualWidth / 2 - 8;
            //this.userControl.Height = this.ActualHeight - 15;
            //this.userControl.Resize();

            //this.userContro2.Width = this.ActualWidth / 2 - 8;
            //this.userContro2.Height = this.ActualHeight - 15;
            //this.userContro2.Resize();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.gmain.Columns = 1;
            this.gmain.Rows = 1;
            InitBrowser(1);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            this.gmain.Columns = 2;
            this.gmain.Rows = 1;
            InitBrowser(2);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            this.gmain.Columns = 2;
            this.gmain.Rows = 2;
            InitBrowser(4);
        }

        public void InitBrowser(int count)
        {
            while (this.gmain.Children.Count > count)
            {
                this.gmain.Children.RemoveAt(this.gmain.Children.Count - 1);
            }
            while (this.gmain.Children.Count < count)
            {
                this.gmain.Children.Add(new MyBrowser(this.gmain.Children.Count + 1));
            }
        }

    }
}
