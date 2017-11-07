using System;
using System.Collections.Generic;

namespace S03EX01
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n------------");
                Console.WriteLine("    Menu    ");
                Console.WriteLine("------------");
                Console.WriteLine("\nVos options sont :\n1) Choisir un fichier de mots\n2) Jouer\n3) Afficher les scores\n4) Terminer\n");

                try
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int action = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    TraiterAction(action);
                }
                catch
                {
                    Console.ResetColor();
                    continue;
                }

            }
        }

        private static void TraiterAction(int action)
        {
            switch (action)
            {
                case 1:
                    // Charger les mots
                    ChargerMots();
                    break;
                case 2:
                    // Jouer
                    if (mots != null && mots.Length > 0)
                        Jouer();
                    else
                        Console.WriteLine("\n/!\\ Commencer par charger un fichier de mots (pas vide).\n");
                    break;
                case 3:
                    // Afficher les scores
                    if (scores != null)
                        AfficherScores();
                    else
                        Console.WriteLine("\n/!\\ Commencer par charger un fichier de mots (pas vide).\n");
                    break;
                case 4:
                    // Sortir
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void AfficherScores()
        {
            Console.WriteLine("\n------------");
            Console.WriteLine("   Scores   ");
            Console.WriteLine("------------\n");

            foreach (var score in scores)
            {
                Console.Write($"{score.Key.GetHashCode()} : ");
                foreach (var lettre in score.Key)
                {
                    Console.Write("_ ");
                }
                if (score.Value > -1)
                    Console.WriteLine($" {score.Value} essais.\n");
                else
                    Console.WriteLine($" pas trouvé\n");
            }

        }

        private static void Jouer()
        {
            Console.WriteLine("\n------------");
            Console.WriteLine("    Jouer   ");
            Console.WriteLine("------------\n");

            // On choisi un mot aléatoirement
            Random random = new Random();
            int index = random.Next(0, mots.Length - 1);
            string mot = mots[index].Trim();

            // Les set contiennent qu'une seule fois chaque lettres
            HashSet<char> lettresDuMot = new HashSet<char>(mot);
            HashSet<char> lettresTrouvees = new HashSet<char>();

            // Variable incrémentée à chaque nouvel essai
            int nbEssais = 0;

            // Tant que le mot n'est pas trouvé
            while (true)
            {
                Console.Write("\nMot :");

                // On affiches les lettres trouvées du mot, _ si pas trouvé
                foreach (char l in mot)
                {
                    if (lettresTrouvees.Contains(l))
                    {
                        Console.Write($" {l}");
                    }
                    else
                    {
                        Console.Write(" _");
                    }
                }

                Console.WriteLine();
                Console.Write("Proposer une lettre : ");
                Console.ForegroundColor = ConsoleColor.Yellow;

                // On demande une lettre
                string entree = Console.ReadLine();
                Console.ResetColor();
                try
                {
                    char lettre = entree[0];
                    nbEssais++;

                    // Si la lettre est dans le mot
                    if (lettresDuMot.Contains(lettre))
                    {
                        lettresTrouvees.Add(lettre);
                        if (lettresTrouvees.Count == lettresDuMot.Count)
                        {
                            bool record = AjouterScore(nbEssais, mot);
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write(bravo);
                            Console.ResetColor();
                            Console.Write($"\r\nMot trouvé en {nbEssais} essais.");

                            if (record)
                                Console.Write(" (nouveau record)\n");
                            else
                                Console.Write("\n");
                            return;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    // Au cas ou l'utilisateur ne rentre pas de lettres
                    Console.WriteLine("Il faut entrer une lettre.");
                }
            }
        }

        // Retourne vrai si c'est un nouveau record
        private static bool AjouterScore(int essais, string mot)
        {
            var score = scores[mot];
            if (score == -1 || score > essais)
            {
                scores[mot] = essais;
                return true;
            }
            return false;
        }

        private static void ChargerMots()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("   Charger mots   ");
            Console.WriteLine("------------------");
            Console.Write("\nEntrer le nom du fichier : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string fileName = Console.ReadLine();
            Console.ResetColor();

            try
            {
                mots = System.IO.File.ReadAllLines(fileName);
                Console.WriteLine($"\n{mots.Length} mots chargés avec succès !\n");
                scores = new Dictionary<string, int>(mots.Length);
                foreach (var mot in mots)
                {
                    scores.Add(mot, -1);
                }
            }
            catch
            {
                Console.WriteLine("Fichier non trouvé ou non valide.");
            }
        }


        // Attributs
        private static string[] mots = null;
        private static Dictionary<string, int> scores = null;
        private static string bravo = @"
     ____                            __
    / __ )_________ __   ______     / /
   / __  / ___/ __ `/ | / / __ \   / / 
  / /_/ / /  / /_/ /| |/ / /_/ /  /_/  
 /_____/_/   \__,_/ |___/\____/  (_)   
";
    }
}
