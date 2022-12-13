using System;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace ToccanierGregoryBlackJack
{
    class Program
    {
        static void DisplayHeader(BlackJack monBlackJack)
        {
            string _money = "";
            string _pot = "";
            // Detection de la taille de monBlackJack.playerMoney
            if (monBlackJack.playerMoney.ToString().Length == 1) { _money = "0000" + monBlackJack.playerMoney; }
            else if (monBlackJack.playerMoney.ToString().Length == 2) { _money = "000" + monBlackJack.playerMoney; }
            else if (monBlackJack.playerMoney.ToString().Length == 3) { _money = "00" + monBlackJack.playerMoney; }
            else if (monBlackJack.playerMoney.ToString().Length == 4) { _money = "0" + monBlackJack.playerMoney; }
            else if (monBlackJack.playerMoney.ToString().Length == 5) { _money = "" + monBlackJack.playerMoney; }
            // Detection de la taille de monBlackJack.potMoney
            if (monBlackJack.potMoney.ToString().Length == 1) { _pot = "000" + monBlackJack.potMoney; }
            else if (monBlackJack.potMoney.ToString().Length == 2) { _pot = "00" + monBlackJack.potMoney; }
            else if (monBlackJack.potMoney.ToString().Length == 3) { _pot = "0" + monBlackJack.potMoney; }
            else if (monBlackJack.potMoney.ToString().Length == 4) { _pot = "" + monBlackJack.potMoney; }
            Console.WriteLine("******************************************************************************************");
            Console.WriteLine("*  Money : " + _money + "                                                             Pot : " + _pot + "  *");
            Console.WriteLine("******************************************************************************************");
        }
        static void DisplayDealerCard(BlackJack monBlackJack)
        {
            // Afficher les carte du dealeur
            Console.WriteLine("Carte du croupier : ");
            AfficherCarte(monBlackJack.dealerCard);
            Console.WriteLine("");
            Console.WriteLine("Point : " + monBlackJack.dealerCardValues);
        }
        static void DisplayPlayerCard(BlackJack monBlackJack)
        {
            // Afficher les carte du dealeur
            Console.WriteLine("Vos Cartes : ");
            AfficherCarte(monBlackJack.playerCard);
            Console.WriteLine("");
            Console.WriteLine("Point : " + monBlackJack.playerCardValues);
        }
        static void Pause()
        {
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
        static int RetrieveMise(int MaxBet)
        {
            bool numberisValid = false;
            int number = 0;
            while (!numberisValid)
            {
                Console.WriteLine("    Combien vouler vous miser :");
                string _mise = Console.ReadLine();
                if (Int32.TryParse(_mise, out number))
                {
                    if (number <= MaxBet)
                    {
                        numberisValid = true;
                    }
                    else
                    {
                        Console.WriteLine("    Vous n'avez pas assez d'argent pour miser " + number);
                    }
                }
                else
                {
                    Console.WriteLine("    La mise rentrée n'est pas valide");
                }
            }

            return number;
        }
        static int RetrieveChoice()
        {
            bool numberisValid = false;
            int number = 0;
            while (!numberisValid)
            {
                string _Choice = Console.ReadLine();
                if (Int32.TryParse(_Choice, out number))
                {
                    numberisValid = true;
                }
                else
                {
                    Console.WriteLine("    L'information rentrée n'est pas valide");
                }
            }

            return number;
        }
        static void AfficherCarte(List<Card> _Carte)
        {
            // Déclaration du tableau
            string[] Tableau = new string[9];
            // Boucle pour remplir le tableau
            for (int i = 0; i < _Carte.Count; i++)
            {
                string symbole = _Carte[i].GetSymbole();
                string couleur = _Carte[i].GetSuit().ToString();


                // Dessinez le haut de la carte
                Tableau[0] += ("┌─────────┐ ");
                if (symbole == "10") { Tableau[1] += "│ " + symbole + "      │ "; }
                else { Tableau[1] += ("│ " + symbole + "       │ "); }
                // Dessinez le milieu de la carte
                Tableau[2] += ("│         │ ");
                Tableau[3] += ("│         │ ");
                switch (couleur)
                {
                    case "Spades":
                        Tableau[4] += ("│    ♠    │ ");
                        break;
                    case "Hearts":
                        Tableau[4] += ("│    ♥    │ ");
                        break;
                    case "Diamond":
                        Tableau[4] += ("│    ♦    │ ");
                        break;
                    case "Clubs":
                        Tableau[4] += ("│    ♣    │ ");
                        break;
                }
                // Dessinez le bas de la carte
                Tableau[5] += ("│         │ ");
                Tableau[6] += ("│         │ ");
                if (symbole == "10") { Tableau[7] += "│      " + symbole + " │ "; }
                else { Tableau[7] += "│       " + symbole + " │ "; }
                Tableau[8] += ("└─────────┘ ");
            }
            // Boucle pour afficher le tableau
            for (int i = 0; i < 9; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Tableau[i]);
                Console.ResetColor();
            }
        }
        static void Main(string[] args)
        {
            // Création de la partie
            BlackJack monBlackJack = new BlackJack();
            // Lancement de la partie et création du paquet de 52 Cartes
            monBlackJack.StartGame();
            // Condition pour la boucle while de l'application
            bool Retry = true;
            // Boucle while
            while (Retry)
            {
                #region Miser
                // Mise
                Console.WriteLine("***********************************************");
                Console.WriteLine("    Votre argent : " + monBlackJack.playerMoney + "$");
                int number = RetrieveMise(monBlackJack.playerMoney);
                monBlackJack.Bet(number);
                Console.WriteLine("    Argent dans le pot : " + monBlackJack.potMoney + "$");
                Console.WriteLine("    Argent restant : " + monBlackJack.playerMoney + "$");
                Console.WriteLine("***********************************************");
                #endregion

                Pause();
                Console.Clear();
                // Affichage du headers
                DisplayHeader(monBlackJack);

                #region Distribuer Carte
                // Donne une carte au dealers
                monBlackJack.DistributeCard("Dealer", 1);
                // Donne une carte au dealers
                monBlackJack.DistributeCard("Player", 2);
                #endregion

                #region Afficher les cartes du dealer
                // Afficher les carte du croupier
                DisplayDealerCard(monBlackJack);
                #endregion

                Console.WriteLine("******************************************************************************************");

                #region Afficher les cartes du joueur
                // Afficher les carte du joueur
                DisplayPlayerCard(monBlackJack);
                #endregion

                Console.WriteLine("******************************************************************************************");

                #region Tour du joueur
                int Choix = 2;
                while (Choix == 2 && monBlackJack.playerCardValues <= 21)
                {
                    // Affiche les possibilités
                    Console.WriteLine("Que voulez vous faire ? ([1] - Rester | [2] - Tirer | [3] - Doublé)");
                    // Récupere la valeur entrer par l'utilisateur et la stocke dans la variable Choix
                    Choix = RetrieveChoice();
                    // Efface la console
                    Console.Clear();
                    // Traite le choix
                    switch (Choix)
                    {
                        case 1:
                            // Affichage du headers
                            DisplayHeader(monBlackJack);
                            break;
                        case 2:
                            // Donne une carte au Joueur
                            monBlackJack.DistributeCard("Player", 1);
                            // Affichage du headers
                            DisplayHeader(monBlackJack);
                            // Afficher les carte du croupier
                            DisplayDealerCard(monBlackJack);
                            Console.WriteLine("******************************************************************************************");
                            // Afficher les carte du joueur
                            DisplayPlayerCard(monBlackJack);
                            Console.WriteLine("******************************************************************************************");
                            break;
                        case 3:
                            // Donne une carte au Joueur
                            monBlackJack.DistributeCard("Player", 1);
                            // Double la mise
                            monBlackJack.playerMoney -= monBlackJack.potMoney;
                            monBlackJack.potMoney *= 2;
                            // Affichage du headers
                            DisplayHeader(monBlackJack);
                            // Afficher les carte du croupier
                            DisplayDealerCard(monBlackJack);
                            Console.WriteLine("******************************************************************************************");
                            // Afficher les carte du joueur
                            DisplayPlayerCard(monBlackJack);
                            Console.WriteLine("******************************************************************************************");

                            break;
                        default:
                            break;
                    }
                }
                if (monBlackJack.playerCardValues > 21)
                {
                    Console.WriteLine("Vous avez sauté !!!");
                    monBlackJack.potMoney = 0;
                }
                Console.WriteLine("***********************************************");
                #endregion

                #region Tour du croupier
                // Au croupier de jouer
                if (monBlackJack.playerCardValues <= 21)
                {
                    while ((monBlackJack.dealerCardValues < 17) && (monBlackJack.dealerCardValues < monBlackJack.playerCardValues))
                    {
                        // Efface la console
                        Console.Clear();
                        // Affichage du headers
                        DisplayHeader(monBlackJack);
                        // Donne une carte au croupier
                        monBlackJack.DistributeCard("Dealer", 1);
                        // Afficher les carte du croupier
                        DisplayDealerCard(monBlackJack);
                        Console.WriteLine("******************************************************************************************");
                        // Afficher les carte du joueur
                        DisplayPlayerCard(monBlackJack);
                        Console.WriteLine("******************************************************************************************");

                        Thread.Sleep(1000); // Attente de 5 secondes
                    }
                }
                #endregion


                #region Afficher le résultat

                // Efface la console
                Console.Clear();
                // Affichage du headers
                DisplayHeader(monBlackJack);
                // Affichage d'une version simplifiée du croupier
                Console.WriteLine("*********** Récapitulatif de la partie ***********");
                Console.WriteLine("");
                Console.WriteLine("Croupier : " + monBlackJack.dealerCardValues + " points");
                Console.WriteLine("");
                // Affichage d'une version simplifiée du Joueur
                Console.WriteLine("Joueurs : " + monBlackJack.playerCardValues + " points");
                Console.WriteLine("");

                int PlayerValue = monBlackJack.playerCardValues;
                int DealerValue = monBlackJack.dealerCardValues;

                if (PlayerValue > 21)
                {
                    Console.WriteLine("Perdu");
                }
                else if (DealerValue > 21 && PlayerValue < 21)
                {
                    Console.WriteLine("Gagné");
                    monBlackJack.playerMoney += monBlackJack.potMoney * 2;
                }
                else if (DealerValue == PlayerValue && PlayerValue < 21)
                {
                    Console.WriteLine("Egalité");
                    monBlackJack.playerMoney += monBlackJack.potMoney;
                }
                else if (DealerValue > PlayerValue)
                {
                    Console.WriteLine("Perdu");
                }
                else if (DealerValue < PlayerValue)
                {
                    Console.WriteLine("Gagné");
                    monBlackJack.playerMoney += monBlackJack.potMoney * 2;
                }
                #endregion

                Pause();

                monBlackJack.RestartGame();
                Console.Clear();
            }
        }
    }
}