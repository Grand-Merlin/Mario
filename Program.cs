using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
    internal class Program
    {
        //Constantes globales
        const int LIGNE = 5;
        const int COLONNE = 7;
        const int NBR_OF_BOMBS = 5;
        const string UP = "U";
        const string DOWN = "D";
        const string RIGHT = "R";
        const string LEFT = "L";
        const string EXPECTED_ANSWERS = "RLUD";
        const string GAME_OVER = "Bombe touchée - Vous avez perdu!";
        const string GAME_WIN = "Félicitations, vous avez gagné !";

        static void Main(string[] args)
        {
            //Variables locales
            int[][] BombPositions;
            int[] marioPosition;
            //Instructions
            marioPosition = InitialMarioPositions(LIGNE, COLONNE);
            BombPositions = ComputeBombPositions(marioPosition);
            ShowBombsPosition(BombPositions);
            UpdateMarioPositions(marioPosition, BombPositions);


            Console.WriteLine();
            Console.WriteLine("Appuie sur une touche pour fermer...");
            Console.ReadKey();
        }

        public static int[] InitialMarioPositions(int ligne, int colonne)
        {
            //Variables locales
            int[] marioPosition = { (ligne - 1) / 2, (colonne - 1) / 2 };
            //Instructions
            return marioPosition;
        }

        public static int[][] ComputeBombPositions(int[] marioPosition)
        {
            //Variables locales
            int[][] BombPositions = new int[NBR_OF_BOMBS][];
            int x;
            int y;
            //Instructions
            //Instanciation complete de mon tableau
            for (int i = 0; i < BombPositions.Length; i++)
            {
                BombPositions[i] = new int[] { -1, -1 };
            }
            for (int i = 0; i < BombPositions.Length; i++)
            {
                do
                {
                    x = Utilities.RandInt(0, COLONNE - 1);
                    y = Utilities.RandInt(0, COLONNE - 1);
                }
                while (Utilities.isAlreadyInTab(x, y, marioPosition) || Utilities.isAlreadyInTab(x, y, BombPositions));

                BombPositions[i][0] = x;
                BombPositions[i][1] = y;
            }

            return BombPositions;
        }

        public static void ShowBombsPosition(int[][] BombPosition)
        {
            for (int i = 0; i < BombPosition.Length; i++)
            {
                //Console.Write(("(" + BombPosition[i][0] + "," + BombPosition[i][1] + ")"));

                Console.Write("(");
                Console.Write(BombPosition[i][0]);
                Console.Write(",");
                Console.Write(BombPosition[i][1]);
                Console.Write(") ");
            }
            Console.WriteLine("\n------------");

        }

        public static void UpdateMarioPositions(int[] MarioPositions, int[][] BombsPos)
        {
            //Variables locales
            String Move;
            bool isMarioPositionWin;
            //Instructions
            do
            {
                Move = Utilities.getSpecificInput("Pos actu " + "(" + MarioPositions[0] + ", " + MarioPositions[1] + ") déplacement RLUD ?", EXPECTED_ANSWERS);
                if (Move == UP)
                {
                    //MarioPositions[0] -= 1;
                    MarioPositions[0] --;
                }
                else if (Move == DOWN)
                {
                    //MarioPositions[0] += 1;
                    MarioPositions[0] ++;
                }
                else if (Move == RIGHT)
                {
                    //MarioPositions[1] += 1;
                    MarioPositions[1] ++;
                }
                else if (Move == LEFT)
                {
                    //MarioPositions[1] -= 1;
                    MarioPositions[1] --;
                }
                    
                isMarioPositionWin = 0 <= MarioPositions[0] && MarioPositions[0] < LIGNE && 0 <= MarioPositions[1] && MarioPositions[1] < COLONNE;
                //Console.WriteLine("Mario est sur une bombe ? "+ Utilities.isAlreadyInTab(MarioPositions[0], MarioPositions[1], BombsPos));
                //Console.WriteLine($"Mario est sur x={MarioPositions[0]} et y = {MarioPositions[1]}");

            } while (!Utilities.isAlreadyInTab(MarioPositions[0], MarioPositions[1], BombsPos) && isMarioPositionWin);
            
            Console.WriteLine(isMarioPositionWin ? GAME_OVER : GAME_WIN);
                
        }
    }
}
