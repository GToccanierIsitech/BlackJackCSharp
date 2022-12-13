using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ToccanierGregoryBlackJack
{
  
    internal class BlackJack
    {
        //////// Déclaration des propriétés de la classe
        // Le deck de carte 
        private List<Card> deck;
        // Le cartes du croupier
        public List<Card> dealerCard;
        public int dealerCardValues;
        // Les cartes du joueur 
        public List<Card> playerCard;
        public int playerCardValues;
        // Argent du joueur
        public int playerMoney;
        // Argent dans le pot
        public int potMoney;

        //////// Constrcuteur de la classe 
        public BlackJack()
        {
            this.deck = new List<Card>();
            this.dealerCard = new List<Card>();
            this.playerCard = new List<Card>();
            this.playerMoney = 500;
            this.potMoney = 0;
        }

        //////// Méthodes de la classe
        // Commencer la partie
        public void StartGame()
        {
            // Création d'un nouveau paquet de cartes
            this.deck = this.CreateDeck();
            // On mélange le paquet
            this.deck = this.ShuffleDeck();
        }


        public void RestartGame()
        {
            // Reset des valeurs par défaut
            this.deck.Clear();
            this.dealerCard.Clear();
            this.playerCard.Clear();
            this.playerCardValues = 0;
            this.dealerCardValues = 0;
            this.potMoney = 0;
            // Création d'un nouveau paquet de cartes
            this.deck = this.CreateDeck();
            // On mélange le paquet
            this.deck = this.ShuffleDeck();
        }
        // Crée un deck de 52 cartes
        private List<Card> CreateDeck()
        {
            List<Card> _deck = new List<Card>();
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Names name in Enum.GetValues(typeof(Names)))
                {
                    _deck.Add(new Card(name, suit));
                }
            }
            return _deck;

        }
        // Mélange les cartes
        private List<Card> ShuffleDeck()
        {
            // Création du nouveau packets
            List<Card> _deck = new List<Card>();
            // Création de l'objet random qui va nous donné une valeur aléatoire
            Random rnd = new Random();
            for (int i = 0; i < 52; i++)
            {
                // Génération d'un numéro aléatoire entre 1 et le nombre de carte dans le paquet
                int randomNumber = rnd.Next(0, this.deck.Count);
                // On met la carte dans le nouveau paquet et on le supprime du paquet précedent
                _deck.Add(this.deck[randomNumber]);
                this.deck.Remove(this.deck[randomNumber]);
            }


            return _deck;
        }

        //Mise
        public string Bet(int betValue)
        {
            if (betValue <= this.playerMoney)
            {
                this.playerMoney -= betValue;
                this.potMoney += betValue;
                return ("Mise de " + betValue);
            }
            else
            {
                return ("Le joueur n'a pas assez d'argent pour miser " + betValue);
            }
        }
        //Distribue des cartes
        public void DistributeCard(string Personne, int nbrOfCard)
        {
            // Distribue le nombre de carte passé en paramètre
            for (int i = 0; i < nbrOfCard; i++)
            {
                // Récupère une carte du paquet
                Card Carte = this.deck.Last();
                // Supprime la carte du paquet
                this.deck.Remove(this.deck.Last());
                // Donne la carte a la personne passé en paramètre
                if (Personne == "Dealer") { 
                    dealerCard.Add(Carte);
                    dealerCardValues += Carte.GetValues();
                }
                else if (Personne == "Player") { 
                    playerCard.Add(Carte);
                    playerCardValues += Carte.GetValues();
                }
            }
        }
    }
}
