using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Whitworthian
{
    class ExpandContent
    {
        public ExpandContent(string content)
        {
            var splitText = TextBlockSplitter.Instance.Split(content, 20, FontWeights.Normal,
                                             Application.Current.Host.Content.ActualWidth);
            Paragraphs = new ObservableCollection<string>(splitText);
        }

        public ObservableCollection<string> Paragraphs { get; set; }
    }
}
