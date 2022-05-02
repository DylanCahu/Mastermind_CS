namespace Namespace
{

   // using Random ;

    using System.Collections.Generic;

    using System;

    using System.Linq;


    public class Module
    {


        public static int[] choixPC = new int[4];

        public static int[] choixJoueur = new int[4];

        public static int genererRandom()
        {//permet de générer un chiffre aléatoire entre 1 et 4
            Random rd = new Random();
            int rand_num = rd.Next(1, 4);
            return rand_num;
        }
        
        public void choixOrdinateur()
        {//génère un tableau de 4 chiffres aléatoires
            for (int i = 0; i < 4; i++)
            {
                choixPC[i] = genererRandom();
            }
        }


        public Array ChoixJoueur()
        {//transforme un int de 4 chiffre en tableau de ces 4 même chiffres
            
            //variables locale
            int n = Convert.ToInt32(Console.ReadLine());
            int choixvalide = 0;
            for (int i = 0; i < 4; i++)
            {
                choixJoueur[3 - i] = n % 10;
                n = (n - choixJoueur[3 - i]) / 10;
            }
            for (int i = 0; i < 4; i++)
            {
                if (0 < choixJoueur[i] && choixJoueur[i] < 5)
                {
                    choixvalide = choixvalide + 1;
                }
            }
            if (choixvalide == 4 && choixJoueur.Length == 4)
            {
                return choixJoueur;
            }
            else
            {
                Console.WriteLine("entré invalide");
                ChoixJoueur();
                return choixJoueur; //bidouille
            }
        }


        public static int nbCommun(int[] TabPC, int[] TabJoueur)
        {
            //variables locale
            int cpt = 0;
            int[] choixPC2 = TabPC;
            for (int i = 0; i < 4; i++)
            {
                if (choixPC2[i] == TabJoueur[i])
                {
                    choixPC2[i] = 6;
                    cpt = cpt + 1;
                }
            }
            if (cpt == 4)
            {
                Console.WriteLine("Bravo ! Tu as réussi. La solution été : ", TabPC);
            }
            else if (cpt > 1)
            {
                Console.WriteLine(cpt + "bonnes réponses, essaye encore !");
            }
            else
            {
                Console.WriteLine(cpt + "bonne réponse, essaye encore !");
            }
            for (int i = 0; i < 4; i++)
            {
                if (choixPC2[i] != TabJoueur[i] && TabJoueur.count(choixPC2[i]) > 0)
                {
                    Console.WriteLine("Mais", choixPC2[i], "est correct");
                }
            }
            return cpt;
        }

        public void Jeu()
        {
            //variables locale
            var nbJeu = 0;
            choixOrdinateur();
            Console.WriteLine(choixPC); //debug
            ChoixJoueur(); //1ère manche
            while (nbCommun(choixPC, choixJoueur) != 4)
            {
                if (nbJeu <= 10)
                {
                    //soit 11 manches de plus donc 12 manches totals
                    nbJeu += 1;
                    ChoixJoueur();
                }
                else
                {
                    Console.WriteLine("PERDUUUUUU, c'était : ", choixPC);
                }
            }
        }
        
        public void main()
        {
            Jeu();
        }
    }
}