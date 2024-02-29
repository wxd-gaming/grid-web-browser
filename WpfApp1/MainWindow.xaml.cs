using CefSharp;
using CefSharp.Wpf;
using GridBrowser;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        String browserCache;

        public MainWindow()
        {

            CefSettings settings = new CefSettings();
            settings.CachePath = AppDomain.CurrentDomain.BaseDirectory + "cache";
            settings.CefCommandLineArgs.Add("disable-application-cache", "1");
            settings.CefCommandLineArgs.Add("disable-session-storage", "1");
            if (!Cef.IsInitialized) Cef.Initialize(settings);

            browserCache = AppDomain.CurrentDomain.BaseDirectory + "browser_cache.bak";

            InitializeComponent();
            InitBrowser();

        }

        public void InitBrowser()
        {
            int[] init = new int[] { 1, 2, 2 };
            Debug.WriteLine(System.Text.Json.JsonSerializer.Serialize(init));
            if (System.IO.File.Exists(browserCache))
            {
                String bak = System.IO.File.ReadAllText(browserCache);
                init = JsonSerializer.Deserialize<int[]>(bak);
            }

            InitBrowser(init);
        }

        public void InitBrowser(int[] init)
        {
            this.gmain.Rows = init[0];
            this.gmain.Columns = init[1];
            InitBrowser(init[2]);
            System.IO.File.WriteAllText(browserCache, JsonSerializer.Serialize(init), Encoding.UTF8);
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Control control = sender as Control;
            string[] tags = control.Tag.ToString().Split(",");
            InitBrowser(new int[] { int.Parse(tags[0]), int.Parse(tags[1]), int.Parse(tags[2]) });
        }

        /// <summary>
        /// 清理缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_clear_cache_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.gmain.Children.Clear();
                string cachePtah = AppDomain.CurrentDomain.BaseDirectory + "cache";
                System.Collections.Generic.IEnumerable<string> enumerable = System.IO.Directory.EnumerateFiles(cachePtah, "", SearchOption.AllDirectories);
                foreach (string file in enumerable)
                {
                    Debug.WriteLine(file);
                    try
                    {
                        File.Delete(file);
                    }
                    catch { }
                }
                InitBrowser();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void mi_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Control control in this.gmain.Children)
                {
                    ((MyBrowser)control).btn_go_Click(null, null);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void mi_set_url(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            string tag = mi.Tag.ToString();
            try
            {
                foreach (Control control in this.gmain.Children)
                {
                    ((MyBrowser)control).SetUrl(tag);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ResetUrlAll resetUrlAll = new ResetUrlAll();
            resetUrlAll.ShowDialog();
            Console.WriteLine(resetUrlAll.DialogResult);
            if (resetUrlAll.DialogResult == true)
            {
                try
                {
                    foreach (Control control in this.gmain.Children)
                    {
                        ((MyBrowser)control).SetUrl(resetUrlAll.url());
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
