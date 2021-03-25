using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DexOnline
{
    class WordGenerate
    {
        public Words NewWord { get; set; }
        public ObservableCollection<Words> Words { get; set; }
        public WordGenerate()
        {
            NewWord = new Words();
            Words = new ObservableCollection<Words>()
            {
                new Words()
            };


        }

        public List<string> Read()
        {
            List<string> categoryBox = new List<string>();
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {

                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    categoryBox.Add(dataVector[3]);
                    Words.Add(new Words
                    {
                        Id = dataVector[0],
                        Word = dataVector[1],
                        Description = dataVector[2],
                        Category = dataVector[3],
                        Image = dataVector[4]
                    });
                }

            }
            return categoryBox;
        }

        public List<string> ListOfWords()
        {
            List<string> listOfWords = new List<string>();
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    listOfWords.Add(dataVector[1]);
                }
            }
            return listOfWords;

        }
       
    }
}
