using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TicTacToe_Game_Code_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string User;

            do
            {
                Console.Clear();

                char[] Position = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                int Player = 1;
                int GameStatus = 0;

                do
                {
                    Console.Clear();

                    HeadsUpDisplay(Position);

                    Console.WriteLine();
                    Console.WriteLine("Player " + Player + " to move, select any number from 1 to 9 from the game board.");
                    Console.WriteLine();

                    int choice = int.Parse(Console.ReadLine());

                    if (Position[choice] != 'X' && Position[choice] != 'O')
                    {
                        if (Player % 2 == 0)
                        {
                            Position[choice] = 'O';
                            Player--;
                        }
                        else
                        {
                            Position[choice] = 'X';
                            Player++;
                        }
                    }
                    else if (Position[choice] == 'X' || Position[choice] == 'O')
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry the position was already taken");
                        Console.WriteLine("\n");
                        Console.WriteLine("Please wait 2 seconds, Board is loading again.....");
                        Thread.Sleep(2000);
                    }

                    GameStatus = CheckWin(Position);


                } while (GameStatus != 1 && GameStatus != -1);

                Console.Clear();

                HeadsUpDisplay(Position);

                if (Player % 2 == 0)
                {
                    Player = 1;
                }
                else
                {
                    Player = 2;
                }

                if (GameStatus == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Player " + Player + " has won");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("The Match is Draw");
                }

                Console.WriteLine();
                Console.WriteLine("If You Want To Continue to Play, Type Y");
                string temp = (Console.ReadLine());
                User = temp;
                User = User.ToUpper();
                Console.WriteLine();

            } while (User == "Y");

        }

        public static void HeadsUpDisplay(char[] Position)
        {
            Console.WriteLine("Welcome to the Tic Tac Toe Game");
            Console.WriteLine();
            Console.WriteLine("Its a Two Player Game");
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();
            Console.WriteLine("The Pattern of Tic Tac Toe Game");
            Console.WriteLine();
            Console.WriteLine("" + Position[1] + " | " + Position[2] + " | " + Position[3] + "");
            Console.WriteLine("--+---+---");
            Console.WriteLine("" + Position[4] + " | " + Position[5] + " | " + Position[6] + "");
            Console.WriteLine("--+---+---");
            Console.WriteLine("" + Position[7] + " | " + Position[8] + " | " + Position[9] + "");

        }

        public static int CheckWin(char[] Position)
        {
            if (Position[1] == Position[2] && Position[2] == Position[3])
            {
                return 1;
            }
            else if (Position[4] == Position[5] && Position[5] == Position[6])
            {
                return 1;
            }
            else if (Position[7] == Position[8] && Position[8] == Position[9])
            {
                return 1;
            }
            else if (Position[1] == Position[4] && Position[4] == Position[7])
            {
                return 1;
            }
            else if (Position[2] == Position[5] && Position[5] == Position[8])
            {
                return 1;
            }
            else if (Position[3] == Position[6] && Position[6] == Position[9])
            {
                return 1;
            }
            else if (Position[1] == Position[5] && Position[5] == Position[9])
            {
                return 1;
            }
            else if (Position[3] == Position[5] && Position[5] == Position[7])
            {
                return 1;
            }
            else if (Position[1] != '1' &&
                     Position[2] != '2' &&
                     Position[3] != '3' &&
                     Position[4] != '4' &&
                     Position[5] != '5' &&
                     Position[6] != '6' &&
                     Position[7] != '7' &&
                     Position[8] != '8' &&
                     Position[9] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
