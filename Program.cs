using System;
using System.Collections.Generic;

namespace RPSLS
{
    class Program
    {
       public static List<String> moves = new List<String> {"rock", "paper", "scissors", "lizard", "spock"};
        public static Dictionary<String, String> winStrings = new Dictionary<String, String> ();
        public static bool yesNo(String question)
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

        public static bool checkWin(String p1, String p2)
        {
            try
            {
                String s = p1 + p2;
                s = winStrings[s];

                return true;
            }
            catch(System.Collections.Generic.KeyNotFoundException E)
            {
                return false;
            }
            finally
            {
                
            }
        }
    public static void loopUntilTrue(Func<bool> f)
        {
            while(!f()){}
        }

        public static bool validateInput(String s)
        {
            for(int  i=0; i<moves.Count; i++)
            {
                if(moves[i] == s)
                {
                    return true;
                }
            }

            return false;
        }

        public static int game(Player p1, Player p2)
        {
            int winner = 0;
            while(winner == 0)
            {
                
                p1.makeMove();
                p2.makeMove();
                
                bool p1Winner = checkWin(p1.getMoveString(), p2.getMoveString());
                bool p2Winner = checkWin(p2.getMoveString(), p1.getMoveString());
               
                if (p1Winner)
                {
                    Console.WriteLine("{0} {1} {2}", p1.getMoveString(), winStrings[p1.getMoveString()+p2.getMoveString()], p2.getMoveString());
                    Console.WriteLine("Player 1 won this round");
                    p1.winRound();
                }
                else if(p2Winner)
                {
                    Console.WriteLine("{0} {1} {2}", p2.getMoveString(), winStrings[p2.getMoveString() + p1.getMoveString()], p1.getMoveString());
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

            loopUntilTrue(() =>
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

               if (players == 1)
               {
                   Console.WriteLine("Human Player1 vs. CPU Player2");
                   game(new Human(1), new Computer(2));
               }
               else if (players == 2)
               {
                   Console.WriteLine("Human Player1 vs. Human Player2");
                   game(new Human(1), new Human(2));
               }
               else
               {
                   Console.WriteLine("CPU Player1 vs. CPU Player2");
                   game(new Computer(1), new Computer(2));
               }

               return !yesNo("Would You like to play Again?");
           });
        }
    }
}
