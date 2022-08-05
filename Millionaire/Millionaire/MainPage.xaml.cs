using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Millionaire
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Shuffle();
        }

        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            Shuffle();
        }

        private void Shuffle()
        {
            Random rnd = new Random();
            IEnumerable<Card> cards = Enumerable.Range(0, 53)
                .OrderBy(x => rnd.Next())
                .Select(x => new Card(x))
                .Take(6)
                .OrderBy(x => x.Rank)
                .ThenBy(x => x.Suit);
            CardList.ItemsSource = cards;
        }
    }
}
