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
using Whitworthian.ViewModels;
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
                this.DataContext = new ExpandContent(addAmp(content));
            }

        }

        //The only thing that can't be passed through
        private static string addAmp(string c)
        {        
            c = c.Replace("amp;", "&");   
            return c;
        }
        
    }
}