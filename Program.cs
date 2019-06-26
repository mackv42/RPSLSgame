using System;
using System.Collections.Generic;

namespace RPSLS
{
    class Program
    {
       public static List<String> moves = new List<String> {"Rock", "Paper", "Scissors", "Lizard", "Spock"};
    public static void loopUntilTrue(Func<bool> f)
        {
            while(!f()){}
        }

        public static void gameLoop(Func<int> f)
        {

        }

        public static int game(Player p1, Player p2)
        {
            int winner = 0;
            while(winner == 0)
            {
                p1.makeMove();
                p2.makeMove();
                int currentWinner = p1.getMove().checkWin(p2.getMove());

                if (currentWinner == -1)
                {
                    Console.WriteLine("Player 1 won this round");
                    p1.winRound();
                }
                else if(currentWinner == 1)
                {
                    Console.WriteLine("Player 2 won this round");
                    p2.winRound();
                }
                else
                {
                    Console.WriteLine("Tie Match!");
                }

                if (p1.checkWin())
                {
                    winner = 1;
                }
                if (p2.checkWin())
                {
                    winner = 2;
                }
            }

            return winner;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How Many Players?");

            int players = -1;
            loopUntilTrue(() =>
            {
                try
                {
                    players = Int32.Parse(Console.ReadLine());
                    if (players > 2 || players < 0)
                    {
                        Console.WriteLine("Invalid input enter a number between 0 and 2");
                        return false;
                    }
                }
                catch (FormatException E)
                {
                    Console.WriteLine("Invalid input enter a number between 0 and 2");
                    return false;
                }
                return true;
            });

            if(players == 1)
            {
                Console.WriteLine("Human Player1 vs. CPU Player2");
                game(new Human(1), new Computer(2));
            } else if(players == 2)
            {
                Console.WriteLine("Human Player1 vs. Human Player2");
                game(new Human(1), new Human(2));
            }
            else
            {
                Console.WriteLine("CPU Player1 vs. CPU Player2");
                game(new Computer(1), new Computer(2));
            }
        }
    }
}
