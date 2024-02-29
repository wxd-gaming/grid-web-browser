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
using System.Windows.Shapes;

namespace GridBrowser
{
    /// <summary>
    /// ResetUrlAll.xaml 的交互逻辑
    /// </summary>
    public partial class ResetUrlAll : Window
    {

        public ResetUrlAll()
        {
            //窗口居中
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        public string url()
        {
            return this.tb_url.Text;
        }

    }
}
