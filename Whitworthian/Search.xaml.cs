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
        //Just clears the annoying left over text
        private void Search_Func(object sender, System.Windows.Input.GestureEventArgs e)
        {
            SearchBox.Text = "";
            searchResultsScroll.Items.Clear();                                          
        }

        //Searches for articles
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            var data = (MainViewModel)DataContext;
           
            if (e.Key == Key.Enter)
            {
                SearchBox.Text = removeLastSpace(SearchBox.Text);
                for (int i = 0; i < 10; i++)
                {
                    if (convertToLower(data.ACItems[i].ACLineTitle).Contains(convertToLower(SearchBox.Text)))
                    {
                        TextBlock searchResults = new TextBlock();
                        searchResults.Foreground = new SolidColorBrush(Colors.Black);
                        searchResults.Tap += Nav_Tap;
                        searchResults.Text = data.ACItems[i].ACLineTitle;
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

        private string removeLastSpace(string c)
        {
           if(c[c.Length-1] == ' ')
           {
               c = c.Remove(c.Length-1);
           }
           return c;
        }

        private string convertToLower(string c)
        {
            string newC = "";
            for (int i = 0; i < c.Length; i++ )
            {
                newC += char.ToLower(c[i]);
            }
            return newC;
        }

        //Navigate to the News Article Page
        private void Nav_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            string title = tb.Text;

            var data = (MainViewModel)DataContext;
            ItemViewModel currentAC = new ItemViewModel();
            ItemViewModel currentNews = new ItemViewModel();
            ItemViewModel currentOpinons = new ItemViewModel();
            ItemViewModel currentSports = new ItemViewModel();
            string content = "content";
            string image = "";
            
            for (int i = 0; i < data.ACItems.Count; i++)
            {
                currentAC = (ItemViewModel)data.ACItems[i];
                currentNews = (ItemViewModel)data.NewsItems[i];
                currentOpinons = (ItemViewModel)data.OpinionsItems[i];
                currentSports = (ItemViewModel)data.SportsItems[i];
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
            content = fixString(content);
            NavigationService.Navigate(new Uri("/NewsArticle.xaml?title=" + title + "&content=" + content + "&image=" + image, UriKind.Relative));
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
                if (i + 4 < c.Length)
                {
                    if (c.Substring(i, 5) == "<div ")
                    {
                        startDiv = i;
                        inDiv = true;
                    }
                }
                if (i + 5 < c.Length)
                {
                    if (c.Substring(i, 6) == "</div>")
                    {
                        endDiv = i + 6;
                    }
                }

                if (endDiv > startDiv && startDiv != -1 && endDiv != -1 && inDiv == true)
                {
                    c = c.Remove(startDiv, endDiv - startDiv);
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