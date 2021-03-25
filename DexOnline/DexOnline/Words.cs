using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DexOnline
{
    class Words : INotifyPropertyChanged
    {
        public Words() {}
        private string id;
       
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged("Id");
            }
        }
        private string word;
        public string Word
        {
            get
            {
                return word;
            }
            set
            {
                word = value;
                NotifyPropertyChanged("Word");
            }
        }
        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }
        private string image;
        
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                NotifyPropertyChanged("Image");
            }
        }

        private string category;
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeleteLine(string indexRemove)
        {
            string fileName = "D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt";

            string[] lines = File.ReadAllLines(fileName).ToArray();

            int indexFile = 0;

            while (indexFile < lines.Length)
            {
                string[] dexList = lines[indexFile].Split('#');

                if (dexList[0] == indexRemove)
                {
                    //int copyIndex = indexFile - 1;
                    for (int index = indexFile; index < lines.Length - 1; index++)
                    {
                        lines[index] = lines[index + 1];
                    }
                    lines = lines.Take(lines.Count() - 1).ToArray();
                    break;
                }
                indexFile++;
            }

            File.WriteAllLines(fileName, lines);
        }
        public void ChangeInFile(string indexRemove, string list)
        {
            string fileName = "D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt";
            int count = int.Parse(indexRemove);
            string[] lines = File.ReadAllLines(fileName).ToArray();
            lines[count - 1] = list;
            File.WriteAllLines(fileName, lines);
        }
    }

}
