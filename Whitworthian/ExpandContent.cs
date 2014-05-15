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
        /// <summary>
        /// The purpose of this class is to overcome the TextBlock bug.
        /// Bug:  If the text content of a TextBlock goes over 2048px, the view is cut off
        /// Fix:  Split the single TextBlock into multiple TextBlocks.  This also stitches
        ///         them together to create a uniform, indistinguishable product.
        /// </summary>
        /// <param name="content"></param>
        public ExpandContent(string content)
        {
            var splitText = TextBlockSplitter.Instance.Split(content, 20, FontWeights.Normal,
                                             Application.Current.Host.Content.ActualWidth);
            Paragraphs = new ObservableCollection<string>(splitText);
        }

        public ObservableCollection<string> Paragraphs { get; set; }
    }
}
