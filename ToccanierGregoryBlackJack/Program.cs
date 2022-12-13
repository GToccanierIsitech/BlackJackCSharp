using System;

namespace ToccanierGregoryBlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création de la partie
            BlackJack monBlackJack = new BlackJack();
            // Lancement de la partie et création du paquet de 52 Cartes
            monBlackJack.StartGame();
            // Donne une carte au dealers
            monBlackJack.DistributeCard("Dealer", 1);
            // Donne une carte au dealers
            monBlackJack.DistributeCard("Player", 2);

            // Afficher les carte du dealeur
            Console.WriteLine("Dealer : ");
            for (int i = 0; i < monBlackJack.dealerCard.Count; i++)
            {
                Console.WriteLine(monBlackJack.dealerCard[i].GetName() + " " + monBlackJack.dealerCard[i].GetSuit());
            }
            // Afficher les carte du joueur
            Console.WriteLine("Player : ");
            for (int i = 0; i < monBlackJack.playerCard.Count; i++)
            {
                Console.WriteLine(monBlackJack.playerCard[i].GetName() + " " + monBlackJack.playerCard[i].GetSuit());
            }

            // Faire les choix (1 - S'arréter 2 - Pioché 3 - Doublé)
            int Choix = 2;
            switch (Choix)
            {
                case 1:
                    Console.WriteLine("S'arreter");
                    break;
                case 2:
                    Console.WriteLine("Pioche");
                    // Donne une carte au dealers
                    monBlackJack.DistributeCard("Player", 1);
                    break;
                case 3:
                    Console.WriteLine("Double");
                    // Donne une carte au dealers
                    monBlackJack.DistributeCard("Player", 1);
                    break;
                default:
                    break;
            }
            // Afficher les carte du joueur
            Console.WriteLine("Player : ");
            for (int i = 0; i < monBlackJack.playerCard.Count; i++)
            {
                Console.WriteLine(monBlackJack.playerCard[i].GetName() + " " + monBlackJack.playerCard[i].GetSuit());
            }



        }
    }
}