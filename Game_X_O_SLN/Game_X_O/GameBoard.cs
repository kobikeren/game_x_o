using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_X_O
{
    class GameBoard
    {
        //x is an array with 9 positions(0 to 8), that will control the state of the game board (positions with value 0 represent
        //empty cells, positions with value 1 represent cells with X, positions with value 2 represent cells with O)
        public int[] x = new int[9];

        /// <summary>
        /// Empty the cells in the game board, for a new game
        /// </summary>
        public void ResetGameBoard()
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = 0;
            }
        }

        /// <summary>
        /// Prints the game board
        /// </summary>
        public void PrintGameBoard()
        {
            Console.Clear();
            //Line 1
            Console.WriteLine("        |        |        ");
            //Line 2(*)                                    
            Console.Write("   ");
            if (x[0] == 0)
                Console.Write("  ");
            else if (x[0] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[1] == 0)
                Console.Write("  ");
            else if (x[1] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[2] == 0)
                Console.Write("  ");
            else if (x[2] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.WriteLine("   ");
            //Line 3(*)
            Console.Write("   ");
            if (x[0] == 0)
                Console.Write("  ");
            else if (x[0] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[1] == 0)
                Console.Write("  ");
            else if (x[1] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[2] == 0)
                Console.Write("  ");
            else if (x[2] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.WriteLine("   ");
            //Line 4
            Console.WriteLine("________|________|________");
            //Line 5
            Console.WriteLine("        |        |        ");
            //Line 6(*)
            Console.Write("   ");
            if (x[3] == 0)
                Console.Write("  ");
            else if (x[3] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[4] == 0)
                Console.Write("  ");
            else if (x[4] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[5] == 0)
                Console.Write("  ");
            else if (x[5] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.WriteLine("   ");
            //Line 7(*)
            Console.Write("   ");
            if (x[3] == 0)
                Console.Write("  ");
            else if (x[3] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[4] == 0)
                Console.Write("  ");
            else if (x[4] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[5] == 0)
                Console.Write("  ");
            else if (x[5] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.WriteLine("   ");
            //Line 8
            Console.WriteLine("________|________|________");
            //Line 9
            Console.WriteLine("        |        |        ");
            //Line 10(*)
            Console.Write("   ");
            if (x[6] == 0)
                Console.Write("  ");
            else if (x[6] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[7] == 0)
                Console.Write("  ");
            else if (x[7] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[8] == 0)
                Console.Write("  ");
            else if (x[8] == 1)
                Console.Write("\\/");
            else
                Console.Write("00");
            Console.WriteLine("   ");
            //Line 11(*)
            Console.Write("   ");
            if (x[6] == 0)
                Console.Write("  ");
            else if (x[6] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[7] == 0)
                Console.Write("  ");
            else if (x[7] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.Write("   |   ");
            if (x[8] == 0)
                Console.Write("  ");
            else if (x[8] == 1)
                Console.Write("/\\");
            else
                Console.Write("00");
            Console.WriteLine("   ");
            //Line 12
            Console.WriteLine("        |        |        ");
            Console.WriteLine("\n\n\n");
        }

        /// <summary>
        /// Checks the game status (on/over)(if game over, who won)
        /// </summary>
        /// <returns>(-1)-game on, 0-game over(no winner), 1-game over(X won), 2-game over(O won)</returns>
        public int GameState()
        {
            int a;
            if (WinningLine(x[0], x[1], x[2], out a))
                return a;
            if (WinningLine(x[3], x[4], x[5], out a))
                return a;
            if (WinningLine(x[6], x[7], x[8], out a))
                return a;
            if (WinningLine(x[0], x[3], x[6], out a))
                return a;
            if (WinningLine(x[1], x[4], x[7], out a))
                return a;
            if (WinningLine(x[2], x[5], x[8], out a))
                return a;
            if (WinningLine(x[0], x[4], x[8], out a))
                return a;
            if (WinningLine(x[2], x[4], x[6], out a))
                return a;

            if (Array.IndexOf(x, 0) == -1)
                return 0;
            return -1;
        }

        /// <summary>
        /// Checks if a line is all X's or all O's
        /// </summary>
        /// <param name="n1">First position in the line</param>
        /// <param name="n2">Second position in the line</param>
        /// <param name="n3">Third position in the line</param>
        /// <param name="res">When the function returns will store the winners id (for later use if the function returns true)</param>
        /// <returns>True if the line is all X's or all O's</returns>
        private bool WinningLine(int n1, int n2, int n3, out int res)
        {
            res = n1;
            if (n1 == n2 && n2 == n3 && n1 != 0)
                return true;
            return false;
        }
    }
}
