using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static LWord.Helpers.Utils;

namespace LWord.Helpers
{
    class DictionaryHelper
    {
        public static int DICTIONARY_SIZE = 5000;
        public static string DICTIONARY_FILENAME = @"dictionary.txt";
        public static Node[] DICTIONARY = new Node[DICTIONARY_SIZE];

        public static void setDictionaryFilename(string filename)
        {
            DICTIONARY_FILENAME = filename;
        }

        public static bool LoadDictionary()
        {
            FileStream myFile = new FileStream(DICTIONARY_FILENAME, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sw = new StreamReader(myFile, Encoding.UTF8);

            


            // Verifica se o arquivo não existe
            if (!File.Exists(DICTIONARY_FILENAME))
            {
                Debug.WriteLine(String.Format("Arquivo {0} não existe", DICTIONARY_FILENAME));
                return false;
            }

            string line = "";
            while ((line = sw.ReadLine()) != null)
            {
                InsertWordIntoDictionary(line);
            }

            sw.Close();
            myFile.Close();

            return true;
        }

        public static bool InsertWordToDictionaryFile(string word)
        {

            FileStream myFile = new FileStream(DICTIONARY_FILENAME, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(myFile, Encoding.UTF8);

            sw.WriteLine(word);

            sw.Close();
            myFile.Close();

            InsertWordIntoDictionary(word);

            return false;
        }

        public static void InsertWordIntoDictionary(string word)
        {
            int hashCode = HashFunction(word, DICTIONARY_SIZE);
            if (DICTIONARY[hashCode] == null)
            {
                Node newNode = new Node(word, null, null);
                DICTIONARY[hashCode] = newNode;
            }

            else
            {
                DICTIONARY[hashCode].insertOrdenate(word);
            }
        }

        public static bool CheckWordExists(string word, RichTextBox richTextBox)
        {
            string[] ignoredWords = new string[] { "de", "da", "do", "a", "e", "o", "as", "os" };

            // Ignorar textos que forem digitos
            if (!int.TryParse(word, out _) && !SearchValue(ignoredWords, word))
            {
                string normalizedWord = NormalizeString(RemoveDiacritics(word));
                int hashCode = HashFunction(normalizedWord, DICTIONARY_SIZE);


                if (DICTIONARY[hashCode] == null)
                {
                    Utils.HighlightText(richTextBox, NormalizeString(word), Color.Red);

                    return false;
                }

                else
                {
                    Node node = DICTIONARY[hashCode].find(normalizedWord);

                    if (node.getElement() == null)
                    {
                        Utils.HighlightText(richTextBox, NormalizeString(word), Color.Red);

                        return false;
                    }
                    else
                    {
                        Utils.HighlightText(richTextBox, NormalizeString(word), Color.Black);

                        return true;
                    }
                }
            }

            return true;
        }

        public static void LoadText(RichTextBox richTextBox)
        {
            string[] words = richTextBox.ToString().Split(" ");

            for (int i = 2; i < words.Length; i++)
            {
                CheckWordExists(words[i], richTextBox);
            }
        }
    }
}