using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace DexOnline
{
    /// <summary>
    /// Interaction logic for ModAdministrativ.xaml
    /// </summary>
    public partial class ModAdministrativ : Window
    {
        string imagePath = null;
        private string category = null;
        Write newWord;
         List<string> categoryBox = new List<string>();
        
        public ModAdministrativ()
        {
            InitializeComponent();
            categoryBox = (DataContext as WordGenerate).Read();
            comboBox(categoryBox);
            //Category.Items.Add(Category.Text);
            string fileWords = "D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt";
            File.OpenWrite(fileWords);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (imagePath == null)
            {
                imagePath = "C:/Users/biama/Documents/PhotosDEX/Default.jpg";
            }
            (DataContext as WordGenerate).Words.Add(new Words() {
                Id = textBoxId.Text, Description = textBoxDescription.Text, Image = imagePath, Word = textBoxWord.Text, Category = Category.Text
            });
            
            //Category.Items.Add(textBoxCategory.Text);
            
            
            newWord = new Write(textBoxId.Text, textBoxWord.Text, textBoxDescription.Text, textBoxCategory.Text, imagePath);
            
            Image.Source = new BitmapImage(new Uri("C:/Users/biama/Documents/PhotosDEX/Default.jpg"));
            imagePath = null;

            textBoxId.Clear();
            textBoxCategory.Clear();
            textBoxWord.Clear();
            textBoxDescription.Clear();
        }
        
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            imagePath = Image.Source.ToString();
            var found = (DataContext as WordGenerate).Words.FirstOrDefault(index => index.Id == textBoxId.Text);
            int i = (DataContext as WordGenerate).Words.IndexOf(found);

            (DataContext as WordGenerate).Words[i] = new Words()
            {
                Id = textBoxId.Text,
                Category = textBoxCategory.Text,
                Word = textBoxWord.Text,
                Description = textBoxDescription.Text,
                Image = imagePath

            };

            string line = textBoxId.Text + "#" + textBoxWord.Text + "#" + textBoxDescription.Text + "#" + textBoxCategory.Text + "#" + imagePath;
            Words itemChanged = new Words();
            itemChanged.ChangeInFile(i.ToString(), line);

            textBoxId.Clear();
            textBoxCategory.Clear();
            textBoxWord.Clear();
            textBoxDescription.Clear();
            Image.Source = new BitmapImage(new Uri("C:/Users/biama/Documents/PhotosDEX/Default.jpg"));
            imagePath = null;

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int number = listBox.SelectedIndex;
            var found = (DataContext as WordGenerate).Words.FirstOrDefault(index => index.Id == textBoxId.Text);
            int i = (DataContext as WordGenerate).Words.IndexOf(found);

            (DataContext as WordGenerate).Words.RemoveAt(i);

            Words deleteFromFile = new Words();
            deleteFromFile.DeleteLine(textBoxId.Text);

            textBoxId.Clear();
            textBoxCategory.Clear();
            textBoxWord.Clear();
            textBoxDescription.Clear();
            Image.Source = new BitmapImage(new Uri("C:/Users/biama/Documents/PhotosDEX/Default.jpg"));
            imagePath = null;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            category = textBoxCategory.Text;
            Category.Items.Add(category);
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = false;
            CommonFileDialogResult result = dialog.ShowDialog();
            imagePath = dialog.FileName;
            var uriSource = new Uri(imagePath);
            Image.Source = new BitmapImage(uriSource);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int number = listBox.SelectedIndex;
            if (listBox.SelectedIndex > -1)
            {
                textBoxId.Text = (listBox.SelectedItem as Words).Id;
                textBoxWord.Text = (listBox.SelectedItem as Words).Word;
                textBoxCategory.Text = (listBox.SelectedItem as Words).Category;
                textBoxDescription.Text = (listBox.SelectedItem as Words).Description;
                imagePath = (listBox.SelectedItem as Words).Image;
                Image.Source = new BitmapImage(new Uri(imagePath));
                imagePath = null;
            }
        }

        private void comboBox(List<string>list)
        {
            int count = 0;
            while(count < list.Count())
            {
                Category.Items.Add(list[count]);
                count++;
            }
        }
    }
}
