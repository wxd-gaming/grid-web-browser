using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    public class UrlBak
    {
        public List<string> Urls { get; set; }

        public void addBak(string url)
        {
            if (Urls == null)
            {
                Urls = new List<string>();
            }
            if (Urls.Contains(url))
            {
                return;
            }
            Urls.Add(url);
        }

    }
}
