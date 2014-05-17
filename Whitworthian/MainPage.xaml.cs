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

        
        /// <summary>
        /// Navigate to the News Article View.
        /// Gets the data from the ItemViewModel, 
        ///     parses into title, picture, and content, 
        ///     and navigates to new screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewsNav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {   
            // Get the title of the article from the TextBlock
            TextBlock tb = (TextBlock)sender;
            string msg = tb.Text;
            string title = "";

            // Get data from the ItemsSource
            var data = NewsData.ItemsSource;
            ItemViewModel current = new ItemViewModel();
            string content = "content";
            string image = "";

            // Search all articles for the article tapped on, and set to content and image
            for(int i = 0; i < data.Count; i++)
            {
                current = (ItemViewModel)data[i];
                if (current.NewsLineTitle == msg)
                {
                    title = msg;
                    content = current.NewsLineText;
                    image = current.NewsLinePic;
                    break;
                }
                else if (current.NewsLineSummary == msg)
                {
                    title = current.NewsLineTitle;
                    content = current.NewsLineText;
                    image = current.NewsLinePic;
                    break;

                }

            }
            // Send the content through the HTML parser -- this formats the string and erases HTML tags
            content = fixString(content);
            // Open new URI
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));            
            
        }

        /// <summary>
        /// Navigate to the Arts & Culture Article View.
        /// Gets the data from the ItemViewModel, 
        ///     parses into title, picture, and content, 
        ///     and navigates to new screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ACNav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Get the title of the article from the TextBlock
            TextBlock tb = (TextBlock)sender;
            string msg = tb.Text;
            string title = "";

            // Get data from the ItemsSource
            var data = ACData.ItemsSource;
            ItemViewModel current = new ItemViewModel();
            string content = "content";
            string image = "";

            // Search all articles for the article tapped on, and set to content and image
            for (int i = 0; i < data.Count; i++)
            {
                current = (ItemViewModel)data[i];
                if (current.ACLineTitle == msg)
                {
                    title = msg;
                    content = current.ACLineText;
                    image = current.ACLinePic;
                    break;
                }
                else if (current.ACLineSummary == msg)
                {
                    title = current.ACLineTitle;
                    content = current.ACLineText;
                    image = current.ACLinePic;
                    break;
                }
            }
            // Send the content through the HTML parser -- this formats the string and erases HTML tags
            content = fixString(content);
            // Send in a new URI
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));  
        }

        /// <summary>
        /// Navigate to the Opinions Article View.
        /// Gets the data from the ItemViewModel, 
        ///     parses into title, picture, and content, 
        ///     and navigates to new screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpinionsNav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Get the title of the article from the TextBlock
            TextBlock tb = (TextBlock)sender;
            string msg = tb.Text;
            string title = "";

            // Get data from the ItemsSource
            var data = OpinionsData.ItemsSource;
            ItemViewModel current = new ItemViewModel();
            string content = "content";
            string image = "";

            // Search all articles for the article tapped on, and set to content and image
            for (int i = 0; i < data.Count; i++)
            {
                current = (ItemViewModel)data[i];

                if (current.OpinionsLineTitle == msg)
                {
                    title = msg;
                    content = current.OpinionsLineText;
                    image = current.OpinionsLinePic;
                    break;
                }
                else if (current.OpinionsLineSummary == msg)
                {
                    title = current.OpinionsLineTitle;
                    content = current.OpinionsLineText;
                    image = current.OpinionsLinePic;
                    break;
                }
            }
            // Send the content through the HTML parser -- this formats the string and erases HTML tags
            content = fixString(content);
            // Send in a new URI
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));
        }

        /// <summary>
        /// Navigate to the Sports Article View.
        /// Gets the data from the ItemViewModel, 
        ///     parses into title, picture, and content, 
        ///     and navigates to new screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SportsNav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            // Get the title of the article from the TextBlock
            TextBlock tb = (TextBlock)sender;
            string msg = tb.Text;
            string title = "";

            // Get data from the ItemsSource
            var data = SportsData.ItemsSource;
            ItemViewModel current = new ItemViewModel();
            string content = "content";
            string image = "";

            // Search all articles for the article tapped on, and set to content and image
            for (int i = 0; i < data.Count; i++)
            {
                current = (ItemViewModel)data[i];
                if (current.SportsLineTitle == msg)
                {
                    title = msg;
                    content = current.SportsLineText;
                    image = current.SportsLinePic;
                    break;
                }
                else if (current.SportsLineSummary == msg)
                {
                    title = current.SportsLineTitle;
                    content = current.SportsLineText;
                    image = current.SportsLinePic;
                    break;
                }
            }
            // Send the content through the HTML parser -- this formats the string and erases HTML tags
            content = fixString(content);
            // Send in a new URI
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));
        }

        /// <summary>
        /// When the user taps on the 'search' bar at the bottom, 
        ///     open up a new view for search.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/Search.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Parses HTML.
        ///     First, formats the string by replacing tags with appropriate characters.
        ///     Secondly, removes all text between "<div " and "</div>"
        ///     Thirdly, removes all text between '<' and '>'
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string fixString(string c)
        {
            // Replace finicky tags with empty string
            c = c.Replace("<p", "<");
            c = c.Replace("<strong>", "");
            c = c.Replace("</strong>", "");

            // Replace the special character codes with the correct character
            // Note:  '&' seems to mess up the TextBlock
            c = c.Replace("&#8211;", " - ");
            c = c.Replace("&nbsp;", " ");
            c = c.Replace("&#8217;", "'");
            c = c.Replace("&amp;", "amp;");

            // startDiv and endDiv are the starting and ending indices for deletion
            int startDiv = -1, endDiv = -1;
            // First time through, we are 'inside the div tag' so we want to remove
            bool inDiv = true;
            // Go through the entire string and check for div tags
            for (int i = 0; i < c.Length; i++)
            {
                // Check for the start tag:  "<div "
                if(i+4 < c.Length)
                {
                    // Note:  Searching for "<div" will strip out too much (things like authors get removed sometimes)
                    if(c.Substring(i, 5) == "<div ")
                    {
                        // Set the starting index to i
                        startDiv = i;
                        // Set inDiv to true -- we have begun a new tag
                        inDiv = true;
                    }
                }
                // Check for the end tag:  "</div>"
                if(i+5 < c.Length)
                {
                    if(c.Substring(i, 6) == "</div>")
                    {
                        // Set the ending index to i (+6 to get to the end of the unwanted substring)
                        endDiv = i+6;                        
                    }
                }

                // If endDiv > startDiv (so we don't delete between '>' and '<'
                // AND if startDiv and endDiv are not at their initial values
                // AND if inDiv is true,
                if (endDiv > startDiv && startDiv != -1 && endDiv != -1 && inDiv == true)
                {
                   // Remove from startDiv, and go for endDiv - startDiv characters
                   c = c.Remove(startDiv, endDiv-startDiv);
                   // Set inDiv to false, we have exited the div tags
                   inDiv = false;
                }
            }

            // Strip all tags out of the content
            int start = -1, end = -1;
            bool startChanged = false, endChanged = false;
            for (int i = 0; i < c.Length; i++)
            {
                // If the current character is '<', then set the start index
                if (c[i] == '<')
                {
                    // Start has changed
                    start = i;
                    startChanged = true;

                }
                // If the current character is '>', then set the end index
                if (c[i] == '>')
                {
                    // End has changed
                    end = i;
                    endChanged = true;
                }
                // If end is initialized AND start < end AND both bools are set to true...
                if (end != -1 && start < end && startChanged && endChanged)
                {
                    // Remove at start, go end - start + 1 characters
                    c = c.Remove(start, end - start + 1);
                    // Reset the bools, and reset the counter
                    startChanged = false;
                    endChanged = false;
                    i = 0;
                }
            }

            return c;
        }
    }
}