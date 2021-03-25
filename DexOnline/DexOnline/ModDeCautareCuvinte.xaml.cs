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
    /// Interaction logic for ModDeCautareCuvinte.xaml
    /// </summary>
    public partial class ModDeCautareCuvinte : Window
    {
        List<string> listOfCategory;
        List<string> listOfWords;
        List<string> categoryBox = new List<string>();
        public ModDeCautareCuvinte()
        {
            InitializeComponent();
            listOfWords = (DataContext as WordGenerate).ListOfWords();
            givenWord.TextChanged += new TextChangedEventHandler(givenWord_TextChanged);
            categoryBox = (DataContext as WordGenerate).Read();
            comboBox(categoryBox);
            listOfCategory = categoryList();
        }

        private void listWords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listWords.ItemsSource != null)
            {
                listWords.Visibility = Visibility.Collapsed;
                givenWord.TextChanged -= new TextChangedEventHandler(givenWord_TextChanged);
                if (listWords.SelectedIndex != -1)
                {
                    givenWord.Text = listWords.SelectedItem.ToString();
                }
                givenWord.TextChanged += new TextChangedEventHandler(givenWord_TextChanged);

            }
        }

        private void givenWord_TextChanged(object sender, TextChangedEventArgs e)
        {
            string currentWord = givenWord.Text;
            List<string> autoListWords = new List<string>();
            autoListWords.Clear();
            string category_chosen = Category.Text;

            if (category_chosen == "")
            {
                foreach (string element in listOfWords)
                {
                    if (!string.IsNullOrEmpty(givenWord.Text))
                    {
                        if (element.StartsWith(currentWord))
                        {
                            autoListWords.Add(element);
                        }
                    }
                }
            }
            else
            {

                for(int count = 0; count < listOfWords.Count; count++)
                {
                    if(listOfCategory[count] == Category.Text)
                    {
                        if (!string.IsNullOrEmpty(givenWord.Text))
                        {
                            if (listOfWords[count].StartsWith(currentWord))
                            {
                                autoListWords.Add(listOfWords[count]);
                            }
                        }
                    }
                    //count++;
                }

            }
            if (autoListWords.Count() > 0)
            {
                listWords.ItemsSource = autoListWords;
                listWords.Visibility = Visibility.Visible;
            }
            else if (givenWord.Text.Equals(""))
            {

                listWords.Visibility = Visibility.Collapsed;
                listWords.ItemsSource = null;

            }
            else
            {
                listWords.Visibility = Visibility.Collapsed;
                listWords.ItemsSource = null;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currentWord = givenWord.Text;
            if (listOfWords.Contains(currentWord))
            {
                string path = "D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt";
                string[] lines = File.ReadAllLines(path);
                int linesLength = 0;
                while (linesLength < lines.Length)
                {
                    string[] dexList = lines[linesLength].Split('#');
                    if (dexList[1] == currentWord)
                    {
                        textBoxWord.Text = dexList[1];
                        textBoxCategory.Text = dexList[3];
                        textBoxDescription.Text = dexList[2];
                        Image.Source = new BitmapImage(new Uri(dexList[4]));
                        break;

                    }
                    linesLength++;
                }
            }
            else
            {
                MessageBox.Show("The word do not exist");
            }
            Category.Text = String.Empty;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void comboBox(List<string> list)
        {
            int count = 0;
            while (count < list.Count())
            {
                if (!Category.Items.Contains(list[count]))
                {
                    Category.Items.Add(list[count]);
                    
                }
                count++;
            }
        }

        private List<string> categoryList()
        {
            List<string> categoryItems = new List<string>();
            using (StreamReader sr = new StreamReader("D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt"))
            {

                while (sr.Peek() >= 0)
                {
                    string data;
                    string[] dataVector;
                    data = sr.ReadLine();
                    dataVector = data.Split('#');
                    categoryItems.Add(dataVector[3]);
                    
                }

            }
            return categoryItems;
        }
     }
}
