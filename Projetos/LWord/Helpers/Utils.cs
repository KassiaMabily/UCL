using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LWord.Helpers
{
    public static class Utils
    {
        public static void HighlightText(this RichTextBox myRtb, string word, Color color)
        {

            if (word == string.Empty)
                return;

            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            while ((index = myRtb.Text.IndexOf(word, startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }

        public static int HashFunction(string s, int size)
        {
            int total = 0;
            char[] c;

            // c = s.ToLower().Normalize(NormalizationForm.FormD).ToCharArray();

            c = s.ToLower().ToCharArray();

            for (int k = 0; k <= c.GetUpperBound(0); k++)
                total += (int)c[k];

            return total % size;
        }

        public static string NormalizeString(string text)
        {
            string newText = Regex.Replace(text, @"[^a-zA-Z-]", "");
            if (newText.EndsWith("-")) {
                newText = Regex.Replace(newText, @"[-]", "");
            }
            //foreach (var chr in new string[] { "(", ")", "!", "@", "#", "[", "]", "?" })
            //{
            //    text = text.Replace(chr, "");
            //}

            return newText;
        }

        public static bool SearchValue(string[] array, string value) {
            bool isFounded = false;

            foreach (var item in array) {
                if (item == value) {
                    isFounded = true;
                }
            }

            return isFounded;
        }

        public static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }

    }
}
