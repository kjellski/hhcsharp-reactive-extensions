using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using ReactiveUI;

namespace _03_Rx_Query
{
    public partial class MainWindow
    {
        private readonly List<string> _wordList;

        public MainWindow()
        {
            InitializeComponent();
            _wordList = InitializeWords();

            SetupSelectCommand();

            var textBoxText = SetupObservableTextBoxContentChange();
            textBoxText
                /*
                                                                                                                                                                                                                                //.Throttle(TimeSpan.FromMilliseconds(1000))
                                                                                                                                                                                                                                //.ObserveOn(DispatcherScheduler.Current)
                */
                .Subscribe(s =>
                    FillListBoxWith(_wordList.Where(w => w.Contains(s)).ToList()));

            FillListBoxWith(_wordList);
        }

        private void SetupSelectCommand()
        {
            // ReactiveUI Extensions
            this.WhenAny(x => x.ListBox.SelectedItem, item => (String) item.Value).Subscribe(x =>
            {
                if (!String.IsNullOrEmpty(x))
                {
                    // something more interesting then a MessageBox please...
                    MessageBox.Show(this, x);
                }
            });
        }

        private IObservable<string> SetupObservableTextBoxContentChange()
        {
            return Observable.FromEventPattern(TextBox, "TextChanged")
                .Select(e => ((TextBox) e.Sender).Text);
        }

        private List<string> InitializeWords()
        {
            return File.ReadAllLines(@"..\..\words.txt").ToList();
        }

        private void FillListBoxWith(List<string> words)
        {
            ListBox.Items.Clear();
            words.ForEach(item => ListBox.Items.Add(item));
        }

        /// <summary>
        /// What's the problem really? How do we get to the text?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            // why does this suck so much???
        }
    }
}