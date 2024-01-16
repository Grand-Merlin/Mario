using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    public class Utilities
    {
        /// <summary>
        /// Génere un nombre aléatoire entre un minimum et un maximum
        /// </summary>
        private static readonly Random rand = new Random();//Instancier en dehors de RandInt afin d'évité les même nombre aléatoire car crée trop vite avec les même valeur système
        public static int RandInt(int min, int max)
        {
            return rand.Next(min, max);
        }
        /// <summary>
        /// Cherche une paire de nombre déja présent dans un tableau de x lignes et 2 colonnes
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tab"></param>
        /// <returns>Retourne vrai si la paire et trouvée</returns>
        public static bool isAlreadyInTab(int x, int y, int[][] tab)
        {


            for (int i = 0; i < tab.Length; i++)
            {

                if (tab[i][0] == x && tab[i][1] == y)
                {
                    return true;
                }
            }
            return false;

        }
        /// <summary>
        /// Cherche une paire de nombre déja présent dans un tableau de 1 lignes et 1 colonnes
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="tab"></param>
        /// <returns></returns>
        public static bool isAlreadyInTab(int x, int y, int[] tab)
        {

                if (tab[0] == x && tab[1] == y)
                {
                    return true;
                }
            return false;

        }

        public static String getSpecificInput(String msg, String expectedAnswers)
        {
            String strAnswer;
            do
            {
                Console.Write(msg);
                strAnswer = Console.ReadLine().Trim().ToUpper();
                if (strAnswer.Length == 1 && expectedAnswers.ToUpper().IndexOf(strAnswer) >= 0)//si aucune lettre n'est trouvée dans la chaine, il renvoye -1, sinon, il renvoie l'index ou la lettre est trouvée (donc voilà pourquoi >= 0)
                {
                    return strAnswer;
                }
                else
                {
                    Console.WriteLine("Erreur de saisie, votre choix doit être parmi " + expectedAnswers + " une lettre seulement");
                }
            } while (true);
        }
    }
}
