using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;

namespace DexOnline
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //string fileWords = "D:\\Facultate\\An 2 facultate\\Semestrul 2\\MVP\\Laborator\\Teme\\DexOnline\\DexOnline\\words.txt";
            //File.OpenWrite(fileWords);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModAdministrativ modAdministrativ = new ModAdministrativ();
            modAdministrativ.Show();
            this.Close();
            //(DataContext as WordGenerate).Words.Add(new Words() { Id = "2", Description = "NONE", Image = "None", Word = "banana" });
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ModDeCautareCuvinte modDeCautareCuvinte = new ModDeCautareCuvinte();
            modDeCautareCuvinte.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ModDivertisment divertisment = new ModDivertisment();
            divertisment.Show();
            this.Close();
        }
    }
}
