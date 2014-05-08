using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using Whitworthian.Resources;
using System.Xml.Linq;
using System.Net;
using System.Windows;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.Phone.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Whitworthian.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.NewsItems = new ObservableCollection<ItemViewModel>();
            this.ACItems = new ObservableCollection<ItemViewModel>();
            this.OpinionsItems = new ObservableCollection<ItemViewModel>();
            this.SportsItems = new ObservableCollection<ItemViewModel>();


            //New

            //WebClient for News
            WebClient webClientNews = new WebClient();
            // Subscribe to the DownloadStringCompleted event prior to downloading the RSS feed.
            webClientNews.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompletedNews);
            // Download the RSS feed. 
            webClientNews.DownloadStringAsync(new System.Uri("http://www.thewhitworthian.com/category/news/feed/"));

            //Opinions

            //WebClient for Opinions
            WebClient webClientOpinions = new WebClient();
            // Subscribe to the DownloadStringCompleted event prior to downloading the RSS feed.
            webClientOpinions.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompletedOpinions);
            // Download the RSS feed. 
            webClientOpinions.DownloadStringAsync(new System.Uri("http://www.thewhitworthian.com/category/opinions/feed/"));

            //AC

            //WebClient for AC
            WebClient webClientAC = new WebClient();
            // Subscribe to the DownloadStringCompleted event prior to downloading the RSS feed.
            webClientAC.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompletedAC);
            // Download the RSS feed.
            webClientAC.DownloadStringAsync(new System.Uri("http://www.thewhitworthian.com/category/arts-and-culture/feed/"));

            //Sports

            //WebClient for Sports
            WebClient webClientSports = new WebClient();
            // Subscribe to the DownloadStringCompleted event prior to downloading the RSS feed.
            webClientSports.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadStringCompletedSports);
            // Download the RSS feed.  
            webClientSports.DownloadStringAsync(new System.Uri("http://www.thewhitworthian.com/category/sports/feed/"));

        }

        // This method sets up the News feed and binds it to our NewsItems 
        private void UpdateFeedListNews(string feedXML)
        {
            // Load the feed into a SyndicationFeed instance.
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
            //XElement rss = XElement.Parse(feedXML);

            // In Windows Phone OS 7.1 or later versions, WebClient events are raised on the same type of thread they were called upon. 
            // For example, if WebClient was run on a background thread, the event would be raised on the background thread. 
            // While WebClient can raise an event on the UI thread if called from the UI thread, a best practice is to always 
            // use the Dispatcher to update the UI. This keeps the UI thread free from heavy processing.

            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                //Populating NewsItems                
                foreach (SyndicationItem item in feed.Items)
                {
                    string content = "";
                    var url = "";
                    foreach (SyndicationElementExtension ext in item.ElementExtensions)
                    {
                        if (ext.GetObject<XElement>().Name.LocalName == "encoded")
                        {
                            content = ext.GetObject<XElement>().Value;
                        }

                        if (ext.GetObject<XElement>().Name.LocalName == "thumbnail")
                        {
                            url = ext.GetObject<XElement>().Attribute("url").Value;
                           
                        }
                    }

                    this.NewsItems.Add(new ItemViewModel() { NewsLineTitle = item.Title.Text, NewsLineSummary = item.Summary.Text, NewsLineText = content, NewsLinePic = url});
                }
                
                
            });
        }

        // This method sets up the Opinions feed and binds it to our OpinionsItems 
        private void UpdateFeedListOpinions(string feedXML)
        {
            // Load the feed into a SyndicationFeed instance.
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            // In Windows Phone OS 7.1 or later versions, WebClient events are raised on the same type of thread they were called upon. 
            // For example, if WebClient was run on a background thread, the event would be raised on the background thread. 
            // While WebClient can raise an event on the UI thread if called from the UI thread, a best practice is to always 
            // use the Dispatcher to update the UI. This keeps the UI thread free from heavy processing.
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                //Populating Opinions                
                foreach (SyndicationItem item in feed.Items)
                {
                    string content = "";
                    var url = "";
                    foreach (SyndicationElementExtension ext in item.ElementExtensions)
                    {
                        if (ext.GetObject<XElement>().Name.LocalName == "encoded")
                        {
                            content = ext.GetObject<XElement>().Value;
                        }
                        if (ext.GetObject<XElement>().Name.LocalName == "thumbnail")
                        {
                            url = ext.GetObject<XElement>().Attribute("url").Value;
                        }
                    }
                    this.OpinionsItems.Add(new ItemViewModel() { OpinionsLineTitle = item.Title.Text, OpinionsLineSummary = item.Summary.Text, OpinionsLineText = content, OpinionsLinePic = url });
                }

            });
        }

        // This method sets up the AC feed and binds it to our ACItems 
        private void UpdateFeedListAC(string feedXML)
        {
            // Load the feed into a SyndicationFeed instance.
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            // In Windows Phone OS 7.1 or later versions, WebClient events are raised on the same type of thread they were called upon. 
            // For example, if WebClient was run on a background thread, the event would be raised on the background thread. 
            // While WebClient can raise an event on the UI thread if called from the UI thread, a best practice is to always 
            // use the Dispatcher to update the UI. This keeps the UI thread free from heavy processing.
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                //Populating ACItems                
                foreach (SyndicationItem item in feed.Items)
                {
                    string content = "";
                    var url = "";
                    foreach (SyndicationElementExtension ext in item.ElementExtensions)
                    {
                        if (ext.GetObject<XElement>().Name.LocalName == "encoded")
                        {
                            content = ext.GetObject<XElement>().Value;
                        }
                        if (ext.GetObject<XElement>().Name.LocalName == "thumbnail")
                        {
                            url = ext.GetObject<XElement>().Attribute("url").Value;
                        }
                    }
                    this.ACItems.Add(new ItemViewModel() { ACLineTitle = item.Title.Text, ACLineSummary = item.Summary.Text, ACLineText = content, ACLinePic = url });
                }

            });
        }

        // This method sets up the Sports feed and binds it to our SportsItems 
        private void UpdateFeedListSports(string feedXML)
        {
            // Load the feed into a SyndicationFeed instance.
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            // In Windows Phone OS 7.1 or later versions, WebClient events are raised on the same type of thread they were called upon. 
            // For example, if WebClient was run on a background thread, the event would be raised on the background thread. 
            // While WebClient can raise an event on the UI thread if called from the UI thread, a best practice is to always 
            // use the Dispatcher to update the UI. This keeps the UI thread free from heavy processing.
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                //Populating SportsItems                
                foreach (SyndicationItem item in feed.Items)
                {
                    string content = "";
                    var url = "";
                    foreach (SyndicationElementExtension ext in item.ElementExtensions)
                    {
                        if (ext.GetObject<XElement>().Name.LocalName == "encoded")
                        {
                            content = ext.GetObject<XElement>().Value;
                        }
                        if (ext.GetObject<XElement>().Name.LocalName == "thumbnail")
                        {
                            url = ext.GetObject<XElement>().Attribute("url").Value;
                        }
                    }
                    this.SportsItems.Add(new ItemViewModel() { SportsLineTitle = item.Title.Text, SportsLineSummary = item.Summary.Text, SportsLineText = content, SportsLinePic = url });
                }

            });
        }


        // Event handler which runs after the News feed is fully downloaded.
        private void webClient_DownloadStringCompletedNews(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    // Showing the exact error message is useful for debugging. In a finalized application, 
                    // output a friendly and applicable string to the user instead. 
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                // Save the feed into the State property in case the application is tombstoned. 
                //this.State["feed"] = e.Result;

                UpdateFeedListNews(e.Result);
            }
        }

        // Event handler which runs after the Opinions feed is fully downloaded.
        private void webClient_DownloadStringCompletedOpinions(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    // Showing the exact error message is useful for debugging. In a finalized application, 
                    // output a friendly and applicable string to the user instead. 
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                // Save the feed into the State property in case the application is tombstoned. 
                //this.State["feed"] = e.Result;

                UpdateFeedListOpinions(e.Result);
            }
        }

        // Event handler which runs after the AC feed is fully downloaded.
        private void webClient_DownloadStringCompletedAC(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    // Showing the exact error message is useful for debugging. In a finalized application, 
                    // output a friendly and applicable string to the user instead. 
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                // Save the feed into the State property in case the application is tombstoned. 
                //this.State["feed"] = e.Result;

                UpdateFeedListAC(e.Result);
            }
        }

        // Event handler which runs after the Sports feed is fully downloaded.
        private void webClient_DownloadStringCompletedSports(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    // Showing the exact error message is useful for debugging. In a finalized application, 
                    // output a friendly and applicable string to the user instead. 
                    MessageBox.Show(e.Error.Message);
                });
            }
            else
            {
                // Save the feed into the State property in case the application is tombstoned. 
                //this.State["feed"] = e.Result;

                UpdateFeedListSports(e.Result);
            }
        }
                  


        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<ItemViewModel> NewsItems { get; private set; }
        public ObservableCollection<ItemViewModel> ACItems { get; private set; }
        public ObservableCollection<ItemViewModel> OpinionsItems { get; private set; }
        public ObservableCollection<ItemViewModel> SportsItems { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {

            


            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() { LineOne = "runtime one", LineTwo = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
           

            this.IsDataLoaded = true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}