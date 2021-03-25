using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DexOnline
{
    /// <summary>
    /// Interaction logic for ModDivertisment.xaml
    /// </summary>
    public partial class ModDivertisment : Window
    {
        int correctNumbers = 0;
        List<string> words;
        Random randInt = new Random();
        List<string> randomWords = new List<string>();
        string image;
        string description;
        int randomNumber;
        int iterations;
        public ModDivertisment()
        {
            InitializeComponent();
            randomWords = ListOfRandomWords();
            iterations = 0;
            description = giveDescription(randomWords[iterations]);
            image = giveImage(randomWords[iterations]);
            if(image == "file:///C:/Users/biama/Documents/PhotosDEX/Default.jpg")
            {
                    wordDescription.Text = description;
            }
            else
            {
                    randomNumber = randInt.Next(0, 2);
                    //0 is for description and 1 for image
                    //randomNumber = randInt.Next(0, 2);
                    if(randomNumber == 0)
                    {
                        wordDescription.Text = description;
                    }
                    else
                    {
                        wordImage.Source = new BitmapImage(new Uri(image));
                    }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void wordNext_Click(object sender, RoutedEventArgs e)
        {

            iterations++;


            if (iterations == 4)
            {
                wordNext.Content = "Finish";
            }
            if (iterations == 5)
            {
                Finish window = new Finish(correctNumbers);
                window.Show();
                this.Close();
            }
            
            else
            {
                wordGuess.Background = Brushes.White;
                wordDescription.Text = String.Empty;
                wordImage.Source = null;
                wrongWord.Text = String.Empty;
                
                wordGuess.Clear();
                description = giveDescription(randomWords[iterations]);
                image = giveImage(randomWords[iterations]);
                if (image == "file:///C:/Users/biama/Documents/PhotosDEX/Default.jpg")
                {
                    wordDescription.Text = description;
                }
                else
                {
                    randomNumber = randInt.Next(0, 2);
                    //0 is for description and 1 for image
                    //randomNumber = randInt.Next(0, 2);
                    if (randomNumber == 0)
                    {
                        wordDescription.Text = description;
                    }
                    else
                    {
                        wordImage.Source = new BitmapImage(new Uri(image));
                    }
                }
            }
           
        }

        private void wordVerify_Click(object sender, RoutedEventArgs e)
        {
            string aux = null;
            string text = wordGuess.Text;
            string aux1 = null;
            if (wordImage.Source != null)
            {
               aux = giveWordForImage(wordImage.Source.ToString());
            }
            if (wordDescription.Text != "")
            {
                aux1 = giveWordForDescription(wordDescription.Text);
            }
            if (giveDescription(text) == wordDescription.Text)
            {
                    wordGuess.Background = Brushes.Green;
                    correctNumbers++;
            }

         
            else if (text == aux)
            {
                wordGuess.Background = Brushes.Green;
                correctNumbers++;
                
            }
            else
            {
                wordGuess.Background = Brushes.Red;
                if (wordImage.Source != null)
                {
                    wrongWord.Text = aux;
                }
                else
                {
                    wrongWord.Text = aux1;
                }
            }
           
        }

        public List<int> ListOfIndex()
        {
            List<int> listOfIndex = new List<int>();
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    listOfIndex.Add(Int32.Parse(dataVector[0]));
                }
            }
            return listOfIndex;

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


        public string giveWord(int index)
        {
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    if (dataVector[0] == index.ToString())
                    {
                        return dataVector[1];
                    }
                }
            }
            return "";

        }

        public List<string> ListOfRandomWords()
        {
            Random rand = new Random();
            List<string> listOfWords = new List<string>();
            List<int> listOfIndex = new List<int>();
            List<string> randomWords = new List<string>();

            int ok = 0;
            int count = 0;
            listOfWords = ListOfWords();
            listOfIndex = ListOfIndex();

            while (count < 5)
            {
                int number = rand.Next(listOfIndex[0], listOfIndex.Last());
                string word = giveWord(number);
                if (word != "" && !randomWords.Contains(word))
                {
                    randomWords.Add(word);
                    count++;
                }

            }
            return randomWords;

        }

        public string giveDescription(string word)
        {
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    if(dataVector[1] == word)
                    {
                        return dataVector[2];
                    }
                }
            }
            return "";
        }

        public string giveWordForImage(string path)
        {
            string path2 = path.Replace("file:///", "").Replace(@"/", @"\").Replace(@"\\", @"\");
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    if(dataVector[4] == path || dataVector[4] == path2)
                    {
                        return dataVector[1];
                    }
                }
            }

            return "";
        }

        public string giveWordForDescription(string path)
        {
           
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    if (dataVector[2] == path)
                    {
                        return dataVector[1];
                    }
                }
            }

            return "";
        }

            public string giveImage(string word)
        {
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    if (dataVector[1] == word)
                    {
                        return dataVector[4];
                    }
                }
            }
            return "";
        }
    }
}

