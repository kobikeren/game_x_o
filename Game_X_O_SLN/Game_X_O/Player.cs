using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_X_O
{
    class Player
    {
        public int MyID;
        public GameBoard Mygb;
        public string Name { get; set; }

        /// <summary>
        /// The ctor
        /// </summary>
        /// <param name="gb1">The board of the game</param>
        public Player(GameBoard gb1)
        {
            Mygb = gb1;
        }

        /// <summary>
        /// Prompts the player to fill an empty cell with his id 
        /// </summary>
        public void Play()
        {
            char choice;
            bool flag = true;
            do
            {
                Console.Write("{0}, please enter a number between 1 and 9: ", Name);
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (choice)
                {
                    case '1':
                        if (Mygb.x[0] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[0] = MyID;
                            flag = false;
                        }
                        break;
                    case '2':
                        if (Mygb.x[1] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[1] = MyID;
                            flag = false;
                        }
                        break;
                    case '3':
                        if (Mygb.x[2] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[2] = MyID;
                            flag = false;
                        }
                        break;
                    case '4':
                        if (Mygb.x[3] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[3] = MyID;
                            flag = false;
                        }
                        break;
                    case '5':
                        if (Mygb.x[4] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[4] = MyID;
                            flag = false;
                        }
                        break;
                    case '6':
                        if (Mygb.x[5] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[5] = MyID;
                            flag = false;
                        }
                        break;
                    case '7':
                        if (Mygb.x[6] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[6] = MyID;
                            flag = false;
                        }
                        break;
                    case '8':
                        if (Mygb.x[7] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[7] = MyID;
                            flag = false;
                        }
                        break;
                    case '9':
                        if (Mygb.x[8] != 0)
                            Console.WriteLine("try again");
                        else
                        {
                            Mygb.x[8] = MyID;
                            flag = false;
                        }
                        break;
                    default:
                        Console.WriteLine("try again");
                        break;
                }
            } while (flag);
        }
    }
}
