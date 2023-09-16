using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LWord.Helpers.DictionaryHelper;
using static LWord.Helpers.Utils;
using static LWord.Helpers.FileHelper;
using System.IO;

namespace LWord
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            setDictionaryFilename(FindFileByName("dictionary"));

            bool isDictionaryLoaded = LoadDictionary();

            if (!isDictionaryLoaded) MessageBox.Show("Não foi possível carregar as palavras do arquivo selecionado");

            LoadText(richTextBox1);
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string content = OpenFile();
            richTextBox1.Text = content;
            LoadText(richTextBox1);
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                Point point = new Point(e.X, e.Y);
                int index = richTextBox1.GetCharIndexFromPosition(point);

                int length = 1;

                if (!Char.IsWhiteSpace(richTextBox1.Text[index]))
                {
                    while (index > 0 && !Char.IsWhiteSpace(richTextBox1.Text[index - 1]))
                    { 
                        index--; length++; 
                    }

                    while (index + length < richTextBox1.Text.Length &&
                        !Char.IsWhiteSpace(richTextBox1.Text[index + length]) &&
                        (!Char.IsPunctuation(richTextBox1.Text[index + length]) ||
                        richTextBox1.Text[index + length] == Char.Parse("'"))
                    )
                    {
                        length++;
                    }

                    richTextBox1.SelectionStart = index;
                    richTextBox1.SelectionLength = length;

                    if(richTextBox1.SelectionColor == Color.Red)
                    {
                        Debug.WriteLine(string.Format("Deseja adicionar a palavra {0} no dicionário?", richTextBox1.SelectedText.ToLower()));

                        DialogResult res = MessageBox.Show(string.Format("Deseja adicionar a palavra {0} no dicionário?", richTextBox1.SelectedText.ToLower()), "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        
                        if (res == DialogResult.OK)
                        {
                            string newWord = RemoveDiacritics(NormalizeString(richTextBox1.SelectedText.ToLower()));
                            InsertWordToDictionaryFile(newWord);
                            CheckWordExists(newWord, richTextBox1);
                        }
                        if (res == DialogResult.Cancel)
                        {
                            Debug.WriteLine("You have clicked Cancel Button");
                        }
                    }
                    else
                    {
                        richTextBox1.DeselectAll();
                    }

                }
            }
            
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            // Se o usuário digitar enter ou espaço, então é uma nova palavra
            if(e.KeyValue == 32 || e.KeyValue == 13)
            {
                string[] words = richTextBox1.Text.Split(" ");
                string lastWord = words[words.Length - 2];

                CheckWordExists(lastWord, richTextBox1);
            }

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(richTextBox1.Text);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFile();
            richTextBox1.Text = "";
        }
    }
}
