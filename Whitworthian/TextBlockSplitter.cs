﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Whitworthian
{
    /// <summary>
    /// TextBlockSplitter splits the TextBlock to accomodate content longer than 2048px in height.
    /// Code courtesy of Denis Stankovski at http://ppe.blogs.msdn.com/b/stankovski/archive/2013/08/27/yet-another-scrollable-textblock-for-windows-phone.aspx
    /// Originally posted:  8/27/2013  Accessed:  5/15/2014
    /// </summary>
    public class TextBlockSplitter
    {
        private TextBlock measureBlock;
        private const double maxHeight = 2048;

        public FontFamily FontFamily { get; set; }

        private TextBlockSplitter()
        {
            measureBlock = GenerateTextBlock();
        }

        private static TextBlockSplitter instance;
        public static TextBlockSplitter Instance
        {
            get
            {
                if (instance == null)
                    instance = new TextBlockSplitter();
                return instance;
            }
        }

        private TextBlock GenerateTextBlock()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Margin = new Thickness(10);
            return textBlock;
        }

        public IList<string> Split(string value, double fontSize, FontWeight fontWeight, double screenWidth)
        {
            List<string> parsedText = new List<string>();
            StringReader reader = new StringReader(value);
            measureBlock.FontSize = fontSize;
            measureBlock.FontWeight = fontWeight;
            measureBlock.Foreground = new SolidColorBrush(Colors.Black);
            measureBlock.Width = screenWidth;

            int maxTextCount = this.GetMaxTextSize();

            if (value.Length < maxTextCount)
            {
                parsedText.Add(value);
            }
            else
            {
                while (reader.Peek() > 0)
                {
                    string line = reader.ReadLine();
                    parsedText.AddRange(ParseLine(line, maxTextCount));
                }
            }
            return parsedText;
        }

        private IList<string> ParseLine(string line, int maxTextCount)
        {
            int maxLineCount = GetMaxLineCount();
            string tempLine = line;
            var parsedText = new List<string>();

            try
            {
                while (tempLine.Trim().Length > 0)
                {
                    int charactersFitted = GetCharactersThatFit(tempLine, maxTextCount);
                    parsedText.Add(tempLine.Substring(0, charactersFitted).Trim());
                    tempLine = tempLine.Substring(charactersFitted, tempLine.Length - (charactersFitted));
                }
            }
            catch (Exception e)
            {
                // Ignore
            }
            return parsedText;
        }

        private int GetCharactersThatFit(string text, int maxTextCount)
        {
            int maxLineLength = maxTextCount > text.Length ? text.Length : maxTextCount;
            for (int i = maxLineLength - 1; i > 1; i--)
            {
                if (text[i] == ' ')
                {
                    var nHeight = MeasureString(text.Substring(0, i - 1)).Height;
                    if (nHeight <= maxHeight)
                        return i;
                }
            }
            return maxLineLength;
        }

        private Size MeasureString(string text)
        {
            this.measureBlock.Text = text;
            return new Size(measureBlock.ActualWidth, measureBlock.ActualHeight);
        }

        private int GetMaxTextSize()
        {
            // Get average char size
            Size size = this.MeasureText(" ");
            // Get number of char that fit in the line
            int charLineCount = (int)(measureBlock.Width / size.Width);
            // Get line count
            int lineCount = (int)(maxHeight / size.Height);

            return charLineCount * lineCount / 2;
        }

        private int GetMaxLineCount()
        {
            Size size = this.MeasureText(" ");
            // Get number of char that fit in the line
            int charLineCount = (int)(measureBlock.Width / size.Width);
            // Get line count
            int lineCount = (int)(maxHeight / size.Height) - 5;

            return lineCount;
        }

        private Size MeasureText(string value)
        {
            measureBlock.Text = value;
            return new Size(measureBlock.ActualWidth, measureBlock.ActualHeight);
        }
    }
}
