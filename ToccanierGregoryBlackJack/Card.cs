using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
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

        // Constructeur
        public Card(Names name, Suits suit)
        {
            this.Name = name;
            this.Suit = suit;

        }
        // Récupére le nom de la carte
        public Names GetName()
        {
            return this.Name;
        }
        // Récupére le nom de la couleur
        public Suits GetSuit()
        {
            return this.Suit;
        }
        // Récupère la valeur de la carte
        public int GetValues()
        {   
            switch (Name)
            {
                case Names.Ace:
                    return 11;
                case Names.Two:
                    return 2;
                case Names.Three:
                    return 3;
                case Names.Four:
                    return 4;
                case Names.Five:
                    return 5;
                case Names.Six:
                    return 6;
                case Names.Seven:
                    return 7;
                case Names.Eight:
                    return 8;
                case Names.Nine:
                    return 9;
                case Names.Ten:
                    return 10;
                case Names.Jack:
                    return 10;
                case Names.Queen:
                    return 10;
                case Names.King:
                    return 10;
                default:
                    return 0;
            }
        }
        // Récupéré le symbole de la carte
        public string GetSymbole()
        {
            switch (Name)
            {
                case Names.Ace:
                    return "A";
                case Names.Two:
                    return "2";
                case Names.Three:
                    return "3";
                case Names.Four:
                    return "4";
                case Names.Five:
                    return "5";
                case Names.Six:
                    return "6";
                case Names.Seven:
                    return "7";
                case Names.Eight:
                    return "8";
                case Names.Nine:
                    return "9";
                case Names.Ten:
                    return "10";
                case Names.Jack:
                    return "V";
                case Names.Queen:
                    return "D";
                case Names.King:
                    return "R";
                default:
                    return null;
            }
        }
    }
}
