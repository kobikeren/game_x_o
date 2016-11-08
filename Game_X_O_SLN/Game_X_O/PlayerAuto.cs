using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_X_O
{
    class PlayerAuto : Player
    {
        /// <summary>
        /// The ctor
        /// </summary>
        /// <param name="gb1">The board of the game</param>
        public PlayerAuto(GameBoard gb1)
            : base(gb1)
        {
        }

        /// <summary>
        /// Fills an empty cell with his id 
        /// </summary>
        public new void Play()
        {
            Mygb.x[Action()] = MyID;
        }

        #region HelpFunctions
        /// <summary>
        /// Finds the other player id
        /// </summary>
        /// <returns>The other player id</returns>
        private int TheOtherID()
        {
            if (MyID == 1)
                return 2;
            return 1;
        }

        /// <summary>
        /// Calculates the best choice (of an empty cell)
        /// </summary>
        /// <returns>The position of the empty cell to play</returns>
        private int Action()
        {
            int n;
            //Decision making: priority 1 - Win
            if (Win(0, 1, 2, out n))
                return n;
            if (Win(3, 4, 5, out n))
                return n;
            if (Win(6, 7, 8, out n))
                return n;
            if (Win(0, 3, 6, out n))
                return n;
            if (Win(1, 4, 7, out n))
                return n;
            if (Win(2, 5, 8, out n))
                return n;
            if (Win(0, 4, 8, out n))
                return n;
            if (Win(2, 4, 6, out n))
                return n;
            //Decision making: priority 2 - Survive
            if (Survive(0, 1, 2, out n))
                return n;
            if (Survive(3, 4, 5, out n))
                return n;
            if (Survive(6, 7, 8, out n))
                return n;
            if (Survive(0, 3, 6, out n))
                return n;
            if (Survive(1, 4, 7, out n))
                return n;
            if (Survive(2, 5, 8, out n))
                return n;
            if (Survive(0, 4, 8, out n))
                return n;
            if (Survive(2, 4, 6, out n))
                return n;
            //Decision making: priority 3 - The middle
            if (Mygb.x[4] == 0)
                return 4;
            //Decision making: priority 4 - Best action

            //Create array 'decision' to calculate the best cell
            int[] decision = new int[9];
            if (Mygb.x[0] == 0)
            {
                decision[0] += 100;
                if (MoveToWin(0, 1, 2))
                    decision[0]++;
                if (MoveToWin(0, 3, 6))
                    decision[0]++;
                if (MoveToWin(0, 4, 8))
                    decision[0]++;
            }
            if (Mygb.x[1] == 0)
            {
                decision[1] += 100;
                if (MoveToWin(0, 1, 2))
                    decision[1]++;
                if (MoveToWin(1, 4, 7))
                    decision[1]++;
            }
            if (Mygb.x[2] == 0)
            {
                decision[2] += 100;
                if (MoveToWin(0, 1, 2))
                    decision[2]++;
                if (MoveToWin(2, 5, 8))
                    decision[2]++;
                if (MoveToWin(2, 4, 6))
                    decision[2]++;
            }
            if (Mygb.x[3] == 0)
            {
                decision[3] += 100;
                if (MoveToWin(3, 4, 5))
                    decision[3]++;
                if (MoveToWin(0, 3, 6))
                    decision[3]++;
            }
            if (Mygb.x[4] == 0)
            {
                decision[4] += 100;
                if (MoveToWin(3, 4, 5))
                    decision[4]++;
                if (MoveToWin(1, 4, 7))
                    decision[4]++;
                if (MoveToWin(0, 4, 8))
                    decision[4]++;
                if (MoveToWin(2, 4, 6))
                    decision[4]++;
            }
            if (Mygb.x[5] == 0)
            {
                decision[5] += 100;
                if (MoveToWin(3, 4, 5))
                    decision[5]++;
                if (MoveToWin(2, 5, 8))
                    decision[5]++;
            }
            if (Mygb.x[6] == 0)
            {
                decision[6] += 100;
                if (MoveToWin(6, 7, 8))
                    decision[6]++;
                if (MoveToWin(0, 3, 6))
                    decision[6]++;
                if (MoveToWin(2, 4, 6))
                    decision[6]++;
            }
            if (Mygb.x[7] == 0)
            {
                decision[7] += 100;
                if (MoveToWin(6, 7, 8))
                    decision[7]++;
                if (MoveToWin(1, 4, 7))
                    decision[7]++;
            }
            if (Mygb.x[8] == 0)
            {
                decision[8] += 100;
                if (MoveToWin(6, 7, 8))
                    decision[8]++;
                if (MoveToWin(2, 5, 8))
                    decision[8]++;
                if (MoveToWin(0, 4, 8))
                    decision[8]++;
            }
            int max = int.MinValue, maxIndx = int.MinValue;
            for (int i = 0; i < decision.Length; i++)
            {
                if (decision[i] > max)
                {
                    max = decision[i];
                    maxIndx = i;
                }
            }
            return maxIndx;
        }

        /// <summary>
        /// Checks if a line contains two cells with the player id and an empty cell
        /// </summary>
        /// <param name="n1">First position in the line</param>
        /// <param name="n2">Second position in the line</param>
        /// <param name="n3">Third position in the line</param>
        /// <param name="n">When the function returns will store the position of the empty cell (for later use if the function returns true)</param>
        /// <returns>True if the line contains two cells with the player id and an empty cell</returns>
        private bool Win(int n1, int n2, int n3, out int n)
        {
            n = 0;
            int a1, a2, a3;
            a1 = Mygb.x[n1];
            a2 = Mygb.x[n2];
            a3 = Mygb.x[n3];
            SortNumbers(ref a1, ref a2, ref a3);
            if (a1 == 0 && a2 == MyID && a3 == MyID)
            {
                if (Mygb.x[n1] == 0)
                    n = n1;
                if (Mygb.x[n2] == 0)
                    n = n2;
                if (Mygb.x[n3] == 0)
                    n = n3;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a line contains two cells with the other player id and an empty cell
        /// </summary>
        /// <param name="n1">First position in the line</param>
        /// <param name="n2">Second position in the line</param>
        /// <param name="n3">Third position in the line</param>
        /// <param name="n">When the function returns will store the position of the empty cell (for later use if the function returns true)</param>
        /// <returns>True if the line contains two cells with the other player id and an empty cell</returns>
        private bool Survive(int n1, int n2, int n3, out int n)
        {
            n = 0;
            int a1, a2, a3;
            a1 = Mygb.x[n1];
            a2 = Mygb.x[n2];
            a3 = Mygb.x[n3];
            SortNumbers(ref a1, ref a2, ref a3);
            if (a1 == 0 && a2 == TheOtherID() && a3 == TheOtherID())
            {
                if (Mygb.x[n1] == 0)
                    n = n1;
                if (Mygb.x[n2] == 0)
                    n = n2;
                if (Mygb.x[n3] == 0)
                    n = n3;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a line contains two empty cells and a cell with the player id
        /// </summary>
        /// <param name="n1">First position in the line</param>
        /// <param name="n2">Second position in the line</param>
        /// <param name="n3">Third position in the line</param>
        /// <returns>True if the line contains two empty cells and a cell with the player id</returns>
        private bool MoveToWin(int n1, int n2, int n3)
        {
            int a1, a2, a3;
            a1 = Mygb.x[n1];
            a2 = Mygb.x[n2];
            a3 = Mygb.x[n3];
            SortNumbers(ref a1, ref a2, ref a3);
            if (a1 == 0 && a2 == 0 && a3 == MyID)
                return true;
            return false;
        }

        /// <summary>
        /// Sorts three number passed by ref
        /// </summary>
        /// <param name="n1">First parameter</param>
        /// <param name="n2">Second parameter</param>
        /// <param name="n3">Third parameter</param>
        private void SortNumbers(ref int n1, ref int n2, ref int n3)
        {
            int temp;
            if (n1 > n2)
            {
                temp = n1;
                n1 = n2;
                n2 = temp;
            }
            if (n1 > n3)
            {
                temp = n1;
                n1 = n3;
                n3 = temp;
            }
            if (n2 > n3)
            {
                temp = n2;
                n2 = n3;
                n3 = temp;
            }
        }
        #endregion
    }
}
