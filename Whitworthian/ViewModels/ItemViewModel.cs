using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Whitworthian.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {



        //News Items
        private string _NewsLineTitle;
        /// <summary>
        /// News Line Title for Binding.
        /// </summary>
        /// <returns></returns>
        public string NewsLineTitle
        {
            get
            {
                return _NewsLineTitle;
            }
            set
            {
                if (value != _NewsLineTitle)
                {
                    _NewsLineTitle = value;
                    NotifyPropertyChanged("NewsLineTitle");
                }
            }
        }

        private string _NewsLineText;
        /// <summary>
        /// News Line Text for Binding
        /// </summary>
        /// <returns></returns>
        public string NewsLineText
        {
            get
            {
                return _NewsLineText;
            }
            set
            {
                if (value != _NewsLineText)
                {
                    _NewsLineText = value;
                    NotifyPropertyChanged("NewsLineText");
                }
            }
        }

        private string _NewsLineSummary;
        /// <summary>
        /// News Line Summary for Binding
        /// </summary>
        /// <returns></returns>
        public string NewsLineSummary
        {
            get
            {
                return _NewsLineSummary;
            }
            set
            {
                if (value != _NewsLineSummary)
                {
                    _NewsLineSummary = value;
                    NotifyPropertyChanged("NewsLineSummary");
                }
            }
        }

        private string _NewsLinePic;
        /// <summary>
        /// News Line Pic for Binding
        /// </summary>
        /// <returns></returns>
        public string NewsLinePic
        {
            get
            {
                return _NewsLinePic;
            }
            set
            {
                if (value != _NewsLinePic)
                {
                    _NewsLinePic = value;
                    NotifyPropertyChanged("NewsLinePic");
                }
            }
        }

        

        //AC

        private string _ACLineTitle;
        /// <summary>
        /// AC Line Title for Binding.
        /// </summary>
        /// <returns></returns>
        public string ACLineTitle
        {
            get
            {
                return _ACLineTitle;
            }
            set
            {
                if (value != _ACLineTitle)
                {
                    _ACLineTitle = value;
                    NotifyPropertyChanged("ACLineTitle");
                }
            }
        }

        private string _ACLineText;
        /// <summary>
        /// AC Line Text for Binding
        /// </summary>
        /// <returns></returns>
        public string ACLineText
        {
            get
            {
                return _ACLineText;
            }
            set
            {
                if (value != _ACLineText)
                {
                    _ACLineText = value;
                    NotifyPropertyChanged("ACLineText");
                }
            }
        }

        private string _ACLineSummary;
        /// <summary>
        /// AC Line Summary for Binding
        /// </summary>
        /// <returns></returns>
        public string ACLineSummary
        {
            get
            {
                return _ACLineSummary;
            }
            set
            {
                if (value != _ACLineSummary)
                {
                    _ACLineSummary = value;
                    NotifyPropertyChanged("ACLineSummary");
                }
            }
        }

        private string _ACLinePic;
        /// <summary>
        /// AC Line Pic for Binding
        /// </summary>
        /// <returns></returns>
        public string ACLinePic
        {
            get
            {
                return _ACLinePic;
            }
            set
            {
                if (value != _ACLinePic)
                {
                    _ACLinePic = value;
                    NotifyPropertyChanged("ACLinePic");
                }
            }
        }

        //Opinions
        private string _OpinionsLineTitle;
        /// <summary>
        /// Opinions Line Title for Binding.
        /// </summary>
        /// <returns></returns>
        public string OpinionsLineTitle
        {
            get
            {
                return _OpinionsLineTitle;
            }
            set
            {
                if (value != _OpinionsLineTitle)
                {
                    _OpinionsLineTitle = value;
                    NotifyPropertyChanged("OpinionsLineTitle");
                }
            }
        }

        private string _OpinionsLineText;
        /// <summary>
        /// Opinions Line Text for Binding
        /// </summary>
        /// <returns></returns>
        public string OpinionsLineText
        {
            get
            {
                return _OpinionsLineText;
            }
            set
            {
                if (value != _OpinionsLineText)
                {
                    _OpinionsLineText = value;
                    NotifyPropertyChanged("OpinionsLineText");
                }
            }
        }

        private string _OpinionsLineSummary;
        /// <summary>
        /// Opinions Line Summary for Binding
        /// </summary>
        /// <returns></returns>
        public string OpinionsLineSummary
        {
            get
            {
                return _OpinionsLineSummary;
            }
            set
            {
                if (value != _OpinionsLineSummary)
                {
                    _OpinionsLineSummary = value;
                    NotifyPropertyChanged("OpinionsLineSummary");
                }
            }
        }

        private string _OpinionsLinePic;
        /// <summary>
        /// Opinions Line Pic for Binding
        /// </summary>
        /// <returns></returns>
        public string OpinionsLinePic
        {
            get
            {
                return _OpinionsLinePic;
            }
            set
            {
                if (value != _OpinionsLinePic)
                {
                    _OpinionsLinePic = value;
                    NotifyPropertyChanged("OpinionsLinePic");
                }
            }
        }

        //Sports
        private string _SportsLineTitle;
        /// <summary>
        /// Sports Line Title for Binding.
        /// </summary>
        /// <returns></returns>
        public string SportsLineTitle
        {
            get
            {
                return _SportsLineTitle;
            }
            set
            {
                if (value != _SportsLineTitle)
                {
                    _SportsLineTitle = value;
                    NotifyPropertyChanged("SportsLineTitle");
                }
            }
        }

        private string _SportsLineText;
        /// <summary>
        /// Sports Line Text for Binding
        /// </summary>
        /// <returns></returns>
        public string SportsLineText
        {
            get
            {
                return _SportsLineText;
            }
            set
            {
                if (value != _SportsLineText)
                {
                    _SportsLineText = value;
                    NotifyPropertyChanged("SportsLineText");
                }
            }
        }

        private string _SportsLineSummary;
        /// <summary>
        /// Sports Line Summary for Binding
        /// </summary>
        /// <returns></returns>
        public string SportsLineSummary
        {
            get
            {
                return _SportsLineSummary;
            }
            set
            {
                if (value != _SportsLineSummary)
                {
                    _SportsLineSummary = value;
                    NotifyPropertyChanged("SportsLineSummary");
                }
            }
        }

        private string _SportsLinePic;
        /// <summary>
        /// Sports Line Pic for Binding
        /// </summary>
        /// <returns></returns>
        public string SportsLinePic
        {
            get
            {
                return _SportsLinePic;
            }
            set
            {
                if (value != _SportsLinePic)
                {
                    _SportsLinePic = value;
                    NotifyPropertyChanged("SportsLinePic");
                }
            }
        }



        private string _lineOne;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineOne
        {
            get
            {
                return _lineOne;
            }
            set
            {
                if (value != _lineOne)
                {
                    _lineOne = value;
                    NotifyPropertyChanged("LineOne");
                }
            }
        }

        private string _lineTwo;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineTwo
        {
            get
            {
                return _lineTwo;
            }
            set
            {
                if (value != _lineTwo)
                {
                    _lineTwo = value;
                    NotifyPropertyChanged("LineTwo");
                }
            }
        }

        private string _lineThree;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineThree
        {
            get
            {
                return _lineThree;
            }
            set
            {
                if (value != _lineThree)
                {
                    _lineThree = value;
                    NotifyPropertyChanged("LineThree");
                }
            }
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