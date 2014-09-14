using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Documents;

namespace _03_Rx_Query
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> wordList;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWords();
        }

        private void InitializeWords()
        {
            wordList = File.ReadAllLines(@"..\..\words.txt").ToList();
            wordList.ForEach(item => ListBox.Items.Add(item));
        }
    }
}