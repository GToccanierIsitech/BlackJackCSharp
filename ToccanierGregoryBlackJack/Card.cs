using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToccanierGregoryBlackJack
{
    enum Names
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    };

    // Pique, Coeur, Carreau, Trefle
    enum Suits
    {
        Spades,
        Hearts,
        Diamond,
        Clubs
    };
    internal class Card
    {
        private Names Name;
        private Suits Suit;

        public Card(Names name, Suits suit)
        {
            this.Name = name;
            this.Suit = suit;

        }

        public Names GetName()
        {
            return this.Name;
        }
        public Suits GetSuit()
        {
            return this.Suit;
        }
    }
}
