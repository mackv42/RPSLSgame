using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Game
    {
        public static List<String> moves = new List<String> { "rock", "paper", "scissors", "lizard", "spock" };
        public static Dictionary<String, String> winStrings = new Dictionary<String, String>();
   
        public Game()
        {
            winStrings.Add("rocklizard", "Smashes");
            winStrings.Add("rockscissors", "Smashes");
            winStrings.Add("paperrock", "Covers");
            winStrings.Add("paperspock", "Disproves");
            winStrings.Add("scissorspaper", "Cuts");
            winStrings.Add("scissorslizard", "Decapitates");
            winStrings.Add("lizardspock", "Poisons");
            winStrings.Add("lizardpaper", "Eats");
            winStrings.Add("spockrock", "Vaporizes");
            winStrings.Add("spockscissors", "Smashes");
        }

        public void StartGame()
        {
            LoopUntilTrue(() =>
            {
                Console.WriteLine("How Many Players?");

                int players = -1;
                LoopUntilTrue(() =>
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

                if (players == 1)
                {
                    Console.WriteLine("Human Player1 vs. CPU Player2");
                    PlayGame(new Human(1), new Computer(2));
                }
                else if (players == 2)
                {
                    Console.WriteLine("Human Player1 vs. Human Player2");
                    PlayGame(new Human(1), new Human(2));
                }
                else
                {
                    Console.WriteLine("CPU Player1 vs. CPU Player2");
                    PlayGame(new Computer(1), new Computer(2));
                }

                return !YesNo("Would You like to play Again?");
            });
        }
        public static bool YesNo(String question)
        {
            string answer = ".";
            while (true)
            {
                Console.Write("{0} Y/N ", question);
                answer = Console.ReadLine();

                if (answer == "Y" || answer == "y")
                {
                    return true;
                }
                if (answer == "N" || answer == "n")
                {
                    return false;
                }
                Console.WriteLine("Invalid it's a yes or no question");
            }
        }


        public static void LoopUntilTrue(Func<bool> f)
        {
            while (!f()) { }
        }
        public static bool ValidateInput(String s)
        {
            for (int i = 0; i < moves.Count; i++)
            {
                if (moves[i] == s)
                {
                    return true;
                }
            }

            return false;
        }
        private bool CheckWin(String p1, String p2)
        {
            try
            {
                String s = winStrings[p1 + p2];
                return true;
            }
            catch (System.Collections.Generic.KeyNotFoundException E)
            {
                return false;
            }
        }
        private int PlayGame(Player p1, Player p2)
        {
            int winner = 0;
            while (winner == 0)
            {

                p1.MakeMove();
                p2.MakeMove();

                bool p1Winner = CheckWin(p1.MoveString(), p2.MoveString());
                bool p2Winner = CheckWin(p2.MoveString(), p1.MoveString());

                if (p1Winner)
                {
                    Console.WriteLine("{0} {1} {2}", p1.MoveString(), winStrings[p1.MoveString() + p2.MoveString()], p2.MoveString());
                    Console.WriteLine("Player 1 won this round");
                    p1.WinRound();
                }
                else if (p2Winner)
                {
                    Console.WriteLine("{0} {1} {2}", p2.MoveString(), winStrings[p2.MoveString() + p1.MoveString()], p1.MoveString());
                    Console.WriteLine("Player 2 won this round");
                    p2.WinRound();
                }
                else
                {
                    Console.WriteLine("Tie Match!");
                }

                if (p1.CheckWin())
                {
                    winner = 1;
                }
                if (p2.CheckWin())
                {
                    winner = 2;
                }
            }

            return winner;
        }
    }
}
