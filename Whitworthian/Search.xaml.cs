using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using Whitworthian.ViewModels;
using System.Windows.Media;

namespace Whitworthian
{
    public partial class Search : PhoneApplicationPage
    {
        public Search()
        {
            InitializeComponent();
            DataContext = App.ViewModel;
           
        }
        
        /// <summary>
        /// Clears out old text after search has executed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Func(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SearchBox.Text = "";
            searchResultsScroll.Items.Clear();                                          
        }

        /// <summary>
        /// Searches for articles.  Case-insensitive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Get data from MainViewModel
            var data = (MainViewModel)DataContext;
           
            if (e.Key == Key.Enter)
            {
                // Remove the pesky last-space from search box
                SearchBox.Text = removeLastSpace(SearchBox.Text);
                for (int i = 0; i < 10; i++)
                {
                    // Convert the arts & culture article titles and search string to lowercase
                    // Note:  same for each if statement below.  Future improvements may condensce this.
                    if (convertToLower(data.ACItems[i].ACLineTitle).Contains(convertToLower(SearchBox.Text)))
                    {
                        // Create a new TextBlock to accomodate the results
                        TextBlock searchResults = new TextBlock();
                        // Set the font color to black (to accomodate Windows dark theme)
                        searchResults.Foreground = new SolidColorBrush(Colors.Black);
                        searchResults.Tap += Nav_Tap;
                        // Set title to the results text
                        searchResults.Text = data.ACItems[i].ACLineTitle;
                        // Format the text
                        searchResults.TextWrapping = TextWrapping.Wrap;
                        searchResults.FontSize = 30;
                        searchResults.Padding = new Thickness(0, 0, 0, 10);
                        searchResultsScroll.Items.Add(searchResults);
                    }
                    if (convertToLower(data.NewsItems[i].NewsLineTitle).Contains(convertToLower(SearchBox.Text)))
                    {
                        TextBlock searchResults = new TextBlock();
                        searchResults.Foreground = new SolidColorBrush(Colors.Black);
                        searchResults.Tap += Nav_Tap;
                        searchResults.Text = data.NewsItems[i].NewsLineTitle;
                        searchResults.TextWrapping = TextWrapping.Wrap;
                        searchResults.FontSize = 30;
                        searchResults.Padding = new Thickness(0, 0, 0, 10);
                        searchResultsScroll.Items.Add(searchResults);
                    }
                    if (convertToLower(data.OpinionsItems[i].OpinionsLineTitle).Contains(convertToLower(SearchBox.Text)))
                    {
                        TextBlock searchResults = new TextBlock();
                        searchResults.Foreground = new SolidColorBrush(Colors.Black);
                        searchResults.Tap += Nav_Tap;
                        searchResults.Text = data.OpinionsItems[i].OpinionsLineTitle;
                        searchResults.TextWrapping = TextWrapping.Wrap;
                        searchResults.FontSize = 30;
                        searchResults.Padding = new Thickness(0, 0, 0, 10);
                        searchResultsScroll.Items.Add(searchResults);
                    }
                    if (convertToLower(data.SportsItems[i].SportsLineTitle).Contains(convertToLower(SearchBox.Text)))
                    {
                        TextBlock searchResults = new TextBlock();
                        searchResults.Foreground = new SolidColorBrush(Colors.Black);
                        searchResults.Tap += Nav_Tap;
                        searchResults.Text = data.SportsItems[i].SportsLineTitle;
                        searchResults.TextWrapping = TextWrapping.Wrap;
                        searchResults.FontSize = 30;
                        searchResults.Padding = new Thickness(0, 0, 0, 10);
                        searchResultsScroll.Items.Add(searchResults);
                    }
                }

                
            }
        }

        /// <summary>
        /// Removes the last space in a search bar
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private string removeLastSpace(string c)
        {
           if(c[c.Length-1] == ' ')
           {
               c = c.Remove(c.Length-1);
           }
           return c;
        }

        /// <summary>
        /// Convert a string to lowercase
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private string convertToLower(string c)
        {
            string newC = "";
            for (int i = 0; i < c.Length; i++ )
            {
                newC += char.ToLower(c[i]);
            }
            return newC;
        }

        /// <summary>
        /// Navigate to the News Article page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            string title = tb.Text;

            // Pull the data, and get the ItemViewModels from each genre
            var data = (MainViewModel)DataContext;
            ItemViewModel currentAC = new ItemViewModel();
            ItemViewModel currentNews = new ItemViewModel();
            ItemViewModel currentOpinons = new ItemViewModel();
            ItemViewModel currentSports = new ItemViewModel();
            string content = "content";
            string image = "";
            
            // Set items to the appropriate ViewModel
            for (int i = 0; i < data.ACItems.Count; i++)
            {
                currentAC = (ItemViewModel)data.ACItems[i];
                currentNews = (ItemViewModel)data.NewsItems[i];
                currentOpinons = (ItemViewModel)data.OpinionsItems[i];
                currentSports = (ItemViewModel)data.SportsItems[i];
                // If the data title matches the title we're looking at, set the image and content
                if (currentAC.ACLineTitle == title)
                {
                    content = currentAC.ACLineText;
                    image = currentAC.ACLinePic;
                }
                if (currentNews.NewsLineTitle == title)
                {
                    content = currentNews.NewsLineText;
                    image = currentNews.NewsLinePic;
                }
                if (currentOpinons.OpinionsLineTitle == title)
                {
                    content = currentOpinons.OpinionsLineText;
                    image = currentOpinons.OpinionsLinePic;
                }
                if (currentSports.SportsLineTitle == title)
                {
                    content = currentSports.SportsLineText;
                    image = currentSports.SportsLinePic;
                }
            }
            // Format the content before navigating to the article view
            content = fixString(content);
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));
        }

        /// <summary>
        /// Parses HTML.
        ///     First, formats the string by replacing tags with appropriate characters.
        ///     Secondly, removes all text between "<div " and "</div>"
        ///     Thirdly, removes all text between '<' and '>'
        ///     
        /// Note:  this function is identical to fixString(string) in MainPage.xaml.cs
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
                if (i + 4 < c.Length)
                {
                    // Note:  Searching for "<div" will strip out too much (things like authors get removed sometimes)
                    if (c.Substring(i, 5) == "<div ")
                    {
                        // Set the starting index to i
                        startDiv = i;
                        // Set inDiv to true -- we have begun a new tag
                        inDiv = true;
                    }
                }
                // Check for the end tag:  "</div>"
                if (i + 5 < c.Length)
                {
                    if (c.Substring(i, 6) == "</div>")
                    {
                        // Set the ending index to i (+6 to get to the end of the unwanted substring)
                        endDiv = i + 6;
                    }
                }

                // If endDiv > startDiv (so we don't delete between '>' and '<'
                // AND if startDiv and endDiv are not at their initial values
                // AND if inDiv is true,
                if (endDiv > startDiv && startDiv != -1 && endDiv != -1 && inDiv == true)
                {
                    // Remove from startDiv, and go for endDiv - startDiv characters
                    c = c.Remove(startDiv, endDiv - startDiv);
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