using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.Phone.Tasks;
using Whitworthian.ViewModels;
using System.Windows.Input;

namespace Whitworthian
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        private void OnNavigatedTo(NavigationEventArgs e)
        {
            // Ensure that application state is restored appropriately
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        
        //Navigate to the News Article Page
        private void NewsNav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {            
            TextBlock tb = (TextBlock)sender;            
            string title = tb.Text;

            var data = NewsData.ItemsSource;
            ItemViewModel current = new ItemViewModel();
            string content = "content";
            string image = "";

            for(int i = 0; i < data.Count; i++)
            {
                current = (ItemViewModel)data[i];
                if (current.NewsLineTitle == title)
                {
                    content = current.NewsLineText;
                    image = current.NewsLinePic;
                    break;
                }
            }
            content = fixString(content);
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));            
            
        }
        //Navigate to the AC Article Page
        private void ACNav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            string title = tb.Text;

            var data = ACData.ItemsSource;
            ItemViewModel current = new ItemViewModel();
            string content = "content";
            string image = "";

            for (int i = 0; i < data.Count; i++)
            {
                current = (ItemViewModel)data[i];
                if (current.ACLineTitle == title)
                {
                    content = current.ACLineText;
                    image = current.ACLinePic;
                    break;
                }
            }
            content = fixString(content);
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));  
        }
        //Navigate to the Opinions Article Page
        private void OpinionsNav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            string title = tb.Text;

            var data = OpinionsData.ItemsSource;
            ItemViewModel current = new ItemViewModel();
            string content = "content";
            string image = "";

            for (int i = 0; i < data.Count; i++)
            {
                current = (ItemViewModel)data[i];
                if (current.OpinionsLineTitle == title)
                {
                    content = current.OpinionsLineText;
                    image = current.OpinionsLinePic;
                    break;
                }
            }
            content = fixString(content);
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));
        }
        //Navigate to the Sports Article Page
        private void SportsNav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            string title = tb.Text;

            var data = SportsData.ItemsSource;
            ItemViewModel current = new ItemViewModel();
            string content = "content";
            string image = "";
            for (int i = 0; i < data.Count; i++)
            {
                current = (ItemViewModel)data[i];
                if (current.SportsLineTitle == title)
                {
                    content = current.SportsLineText;
                    image = current.SportsLinePic;
                    break;
                }
            }
            content = fixString(content);
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));
        }

        private void Search_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        //Need to remove before naviagation because '&' is a special character in Uri's
        private static string fixString(string c)
        {
            c = c.Replace("<p", "<");
            c = c.Replace("<strong>", "");
            c = c.Replace("</strong>", "");

            c = c.Replace("&#8211;", " - ");
            c = c.Replace("&nbsp;", " ");
            c = c.Replace("&#8217;", "'");
            c = c.Replace("&amp;", "amp;");


            int startDiv = -1, endDiv = -1;
            bool inDiv = true;
            for (int i = 0; i < c.Length; i++)
            {
                if(i+4 < c.Length)
                {
                    if(c.Substring(i, 5) == "<div ")
                    {
                        startDiv = i;
                        inDiv = true;
                    }
                }
                if(i+5 < c.Length)
                {
                    if(c.Substring(i, 6) == "</div>")
                    {
                        endDiv = i+6;                        
                    }
                }

                if (endDiv > startDiv && startDiv != -1 && endDiv != -1 && inDiv == true)
                {
                   c = c.Remove(startDiv, endDiv-startDiv);
                   inDiv = false;
                }
            }

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