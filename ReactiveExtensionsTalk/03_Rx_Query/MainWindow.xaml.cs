using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;

namespace _03_Rx_Query
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> _wordList;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWords();
            
            var textBoxText = SetupSearchQuery();

            textBoxText
                //.Throttle(TimeSpan.FromMilliseconds(500))
                //.ObserveOn(DispatcherScheduler.Current)
                .Subscribe(s => 
                    FillListBoxWith(_wordList.Where(w => w.Contains(s)).ToList()));

            FillListBoxWith(_wordList);
        }

        private IObservable<string> SetupSearchQuery()
        {
            return Observable.FromEventPattern(TextBox, "TextChanged")
                .Select(e => ((TextBox)e.Sender).Text);
        }

        private void InitializeWords()
        {
            _wordList = File.ReadAllLines(@"..\..\words.txt").ToList();
        }

        private void FillListBoxWith(List<string> words)
        {
            ListBox.Items.Clear();
            words.ForEach(item => ListBox.Items.Add(item));            
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // why does this suck so much???
        }
    }
}