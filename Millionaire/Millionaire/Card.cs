using System;

namespace Millionaire
{
    public class Card
    {
        private const int JOKER = 52;
        private int id;
        public Card(int id)
        {
            this.id = id;
        }
        public Card(Suit suit, int number)
        {
            if (suit == Suit.Joker)
            {
                this.id = JOKER;
                return;
            }
            if (number < 1 || 13 < number)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.id = (int)suit * 13 + (number - 1);
        }
        public int Number 
        {
            get
            {
                if (id == JOKER) return 0;
                return (id % 13) + 1;
            }
        }
        public int Rank
        {
            get
            {
                if (id == JOKER) return 13;
                return (id + 11) % 13;
            }
        }
        public Suit Suit
        {
            get
            {
                return (Suit)(id / 13);
            }
        }
        public override string ToString()
        {
            if (id == JOKER) return "Joker";
            string[] names = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            return string.Format("{0} of {1}", names[this.Number - 1], this.Suit);
        }
    }
}
