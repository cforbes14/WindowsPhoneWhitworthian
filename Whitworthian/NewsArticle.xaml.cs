using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace Whitworthian
{
    public partial class NewsArticle : PhoneApplicationPage
    {
        public NewsArticle()
        {
            InitializeComponent();

            
           
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {      
    
            string title = "";
            if(NavigationContext.QueryString.TryGetValue("title", out title))
            {                
                NewsArtTitle.Text = title;
                                
            }
            string image = "";
            if (NavigationContext.QueryString.TryGetValue("image", out image))
            {
                NewsImage.Source = new BitmapImage(new Uri(image, UriKind.Absolute));
            }
            string content = "";
            if (NavigationContext.QueryString.TryGetValue("content", out content))
            {
                this.DataContext = new ExpandContent(fixString(content));
            }

        }

        private static string fixString(string c)
        {
            c = c.Replace("<p>", "\n");
            c = c.Replace("</p>", "");
            c = c.Replace("<p", "\n<");
            c = c.Replace("<p dir=\"ltr\">", "\n");
            c = c.Replace("<div>", "");
            c = c.Replace("</div>", "");
            c = c.Replace("<strong>", "");
            c = c.Replace("</strong>", "");
            c = c.Replace("<br />", "");
            c = c.Replace("<em>", "");
            c = c.Replace("</em>", "");

            int start = -1, end = -1;
            bool startChanged = false, endChanged = false;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == '<')
                {
                    start = i;
                    startChanged = true;

                }
                if (c[i] == '>')
                {
                    end = i;
                    endChanged = true;
                }
                if (end != -1 && start < end && startChanged && endChanged)
                {
                    c = c.Remove(start, end - start + 1);
                    startChanged = false;
                    endChanged = false;
                    i = 0;
                }
            }
                
                return c;
        }
        
    }
}