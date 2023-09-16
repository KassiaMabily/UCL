using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LWord.Helpers
{
    class FileHelper
    {
        public static string CURRENT_FILENAME = "";

        public static void SaveFile(string text)
        {

            if (CURRENT_FILENAME == "")
            {
                CreateFile();
            }


            FileStream myFile = new FileStream(CURRENT_FILENAME, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(myFile, Encoding.UTF8);

            sw.Write(text);

            sw.Close();
            myFile.Close();

            MessageBox.Show("Arquivo salvo com sucesso!");
        }

        public static void CreateFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "arquivo de texto (*.txt)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.FileName = "lWord";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null)
                {
                    // Code to write the stream goes here.
                    CURRENT_FILENAME = saveFileDialog1.FileName;
                }
            }
        }

        public static string OpenFile()
        {
            string content = "";

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Selecionar arquivo";

            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                CURRENT_FILENAME = openFileDialog1.FileName;

                FileStream myFile = new FileStream(CURRENT_FILENAME, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(myFile, Encoding.UTF8);

                while (sr.Peek() >= 0)
                {
                    content += sr.ReadLine();
                }

                sr.Close();
                myFile.Close();
            }

            return content;
        }

        public static string FindFileByName(string partialName) {
            string fileName = "";

            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo("..\\..\\..\\");
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");

            foreach (FileInfo foundFile in filesInDir) {
                fileName = foundFile.FullName;
            }

            return fileName;
        }
    }
}
