using CefSharp;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class MyBrowser : UserControl
    {

        private ChromiumWebBrowser chromiumWebBrowser;

        public MyBrowser()
        {
            InitializeComponent();
            chromiumWebBrowser = new ChromiumWebBrowser();
            this.chromiumWebBrowser.Margin = new Thickness(2, 30, 2, 2);
            this.gmain.Children.Add(chromiumWebBrowser);
        }

        public void SetUrl(string url)
        {
            this.tb_url.Text = url;
            btn_rf_Click(null, null);
        }

        private void btn_rf_Click(object sender, RoutedEventArgs e)
        {
            this.chromiumWebBrowser.Load(this.tb_url.Text);
        }

        private void tb_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.chromiumWebBrowser.Load(this.tb_url.Text);
            }
        }

        public void SaveUrl()
        {

        }

        private void btn_f12_Click(object sender, RoutedEventArgs e)
        {
            this.chromiumWebBrowser.ShowDevTools();
        }
    }
}
