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

        string bakPath;
        string urlBak = "";
        int num = 0;

        private ChromiumWebBrowser chromiumWebBrowser;

        public MyBrowser(int num)
        {
            this.num = num;

            bakPath = AppDomain.CurrentDomain.BaseDirectory + "url_bak_" + num + ".bak";

            if (System.IO.File.Exists(bakPath))
            {
                urlBak = System.IO.File.ReadAllText(bakPath);
            }
            InitializeComponent();
            chromiumWebBrowser = new ChromiumWebBrowser();
            this.chromiumWebBrowser.Margin = new Thickness(2, 30, 2, 2);
            this.gmain.Children.Add(chromiumWebBrowser);
            if (!string.IsNullOrEmpty(urlBak))
            {
                SetUrl(urlBak);
            }
        }

        public void SetUrl(string url)
        {
            this.tb_url.Text = url;
            btn_go_Click(null, null);
        }

        private void btn_go_Click(object sender, RoutedEventArgs e)
        {
            this.chromiumWebBrowser.Load(this.tb_url.Text);
            urlBak = this.tb_url.Text;
            SaveUrl();
        }
        private void btn_rf_Click(object sender, RoutedEventArgs e)
        {
            btn_go_Click(null, null);
            this.chromiumWebBrowser.Reload(true);
        }

        private void tb_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_go_Click(null, null);
            }
        }

        public void SaveUrl()
        {
            System.IO.File.WriteAllText(bakPath, urlBak, Encoding.UTF8);
        }

        private void btn_f12_Click(object sender, RoutedEventArgs e)
        {
            this.chromiumWebBrowser.ShowDevTools();
        }

    }
}
