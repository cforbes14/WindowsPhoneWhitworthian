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

        /// <summary>
        /// Load the data for the ViewModels.
        /// Each genre is loaded separately -- future improvements may condensce this.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {      
    
            // Get the title
            string title = "";
            if(NavigationContext.QueryString.TryGetValue("title", out title))
            {                
                NewsArtTitle.Text = title;
                                
            }
            // Get the image
            string image = "";
            if (NavigationContext.QueryString.TryGetValue("image", out image))
            {
                // Convert string to BitmapImage, and feed it into the source
                NewsImage.Source = new BitmapImage(new Uri(image, UriKind.Absolute));
            }

            string content = "";
            // Get the content string (and format it)
            if (NavigationContext.QueryString.TryGetValue("content", out content))
            {
                this.DataContext = new ExpandContent(addAmp(content));
            }

        }

        /// <summary>
        /// Strip any ampersand out of the content string.
        /// The ampersand is the only character that gives us trouble
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string addAmp(string c)
        {        
            c = c.Replace("amp;", "&");   
            return c;
        }
        
    }
}