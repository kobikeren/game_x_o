using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_X_O
{
    class Program
    {
        //*******************************************************************
        //****************** Created by kobi keren **************************
        //******************     on 09/11/2016     **************************
        //*******************************************************************

        static GameBoard gb1 = new GameBoard();

        /// <summary>
        /// Runs the program
        /// </summary>
        /// <param name="args">Not in use</param>
        static void Main(string[] args)
        {
            char mainChoice;
            do
            {
                gb1.ResetGameBoard();
                PrintMainMenu();
                //The main menu item chosen by the user will be stored in 'mainChoice'
                mainChoice = Console.ReadKey().KeyChar;
                switch (mainChoice)
                {
                    case '1':
                        //Create two players, and connect them to 'gb1' (the game board)
                        Player p1 = new Player(gb1);
                        Player p2 = new Player(gb1);
                        Console.Clear();
                        //Get the players names
                        Console.Write("\nPlayer 1, please enter your name: ");
                        p1.Name = Console.ReadLine();
                        Console.Clear();
                        Console.Write("\nPlayer 2, please enter your name: ");
                        p2.Name = Console.ReadLine();
                        Console.Clear();
                        //Give ID 1 to player 1, and ID 2 to player 2
                        p1.MyID = 1;
                        p2.MyID = 2;
                        do
                        {
                            gb1.PrintGameBoard();
                            p1.Play();
                            //gb1.GameState() will return 0, 1 or 2 if the game is over,
                            //and will return -1 if the game is on
                            if (gb1.GameState() >= 0)
                                //Get out of the loop only if the game is over
                                break;
                            gb1.PrintGameBoard();
                            p2.Play();
                            if (gb1.GameState() >= 0)
                                //Get out of the loop only if the game is over
                                break;
                        } while (true);
                        gb1.PrintGameBoard();
                        Console.WriteLine("Game over\n");
                        switch (gb1.GameState())
                        {
                            case 0:
                                //gb1.GameState() will return 0 if the game is over, and no one won
                                Console.WriteLine("No winner");
                                break;
                            case 1:
                                //gb1.GameState() will return 1 if the game is over, and player 1 won
                                Console.WriteLine("{0} is the winner (player 1)", p1.Name);
                                break;
                            case 2:
                                //gb1.GameState() will return 2 if the game is over, and player 2 won
                                Console.WriteLine("{0} is the winner (player 2)", p2.Name);
                                break;
                        }
                        Console.WriteLine("\n\n\nPress any key to go back to main menu");
                        Console.ReadKey();
                        break;
                    case '2':
                        char choice;
                        string message = string.Empty;
                        //Create a player, and connect him to 'gb1' (the game board)
                        Player p = new Player(gb1);
                        Console.Clear();
                        //Get the player name
                        Console.Write("\nPlease enter your name: ");
                        p.Name = Console.ReadLine();
                        //Create an auto-player (the computer), and connect him to 'gb1' (the game board)
                        PlayerAuto pa = new PlayerAuto(gb1);
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("{0}", message);
                            //The user will decide if he will play first ('choice' will store 'y'),
                            //or the computer will play first ('choice' will store 'c')
                            Console.WriteLine("{0}, who will play first? y-you, c-the computer: ", p.Name);
                            choice = Console.ReadKey().KeyChar;
                            message = "you did not enter y or c!";
                        } while (choice != 'y' && choice != 'c');
                        if (choice == 'y')
                        {
                            p.MyID = 1;
                            pa.MyID = 2;
                        }
                        else
                        {
                            p.MyID = 2;
                            pa.MyID = 1;
                        }
                        do
                        {
                            if (choice == 'y')
                            {
                                gb1.PrintGameBoard();
                                p.Play();
                                if (gb1.GameState() >= 0)
                                    break;
                            }
                            gb1.PrintGameBoard();
                            System.Threading.Thread.Sleep(1000);
                            pa.Play();
                            if (gb1.GameState() >= 0)
                                break;
                            if (choice == 'c')
                            {
                                gb1.PrintGameBoard();
                                p.Play();
                                if (gb1.GameState() >= 0)
                                    break;
                            }
                        } while (true);
                        gb1.PrintGameBoard();
                        Console.WriteLine("Game over\n");
                        switch (gb1.GameState())
                        {
                            case 0:
                                Console.WriteLine("No winner");
                                break;
                            case 1:
                                Console.WriteLine("{0} is the winner", (choice == 'y') ? p.Name : "The computer");
                                break;
                            case 2:
                                Console.WriteLine("{0} is the winner", (choice == 'y') ? "The computer" : p.Name);
                                break;
                        }
                        Console.WriteLine("\n\n\nPress any key to go back to main menu");
                        Console.ReadKey();
                        break;
                }
            } while (mainChoice != '3');
        }

        /// <summary>
        /// Prints the game main menu
        /// </summary>
        static void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\nGame X O - Main menu");
            Console.WriteLine("--------------------");
            Console.WriteLine("1)Two players");
            Console.WriteLine("2)Against the computer");
            Console.WriteLine("3)Exit");
            Console.WriteLine("\n\n");
            Console.Write("Please enter your choice: ");
        } 
    }
}
