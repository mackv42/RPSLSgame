using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace RPSLS
{
    class Move
    {
        public List<String> moves;
        private int move;

        public Move()
        {
            
        }

        public Move(Func<String> m)
        {
            this.moves = new List<String> { "Rock", "Paper", "Scissors", "Lizard", "Spock" };
            Console.WriteLine($"Choose From one of the Following {moves[0]} {moves[1]} {moves[2]} {moves[3]} {moves[4]}");
            setMove(m());

            while (! (this.move >= 0 && this.move <= 4) )
            {
                Console.WriteLine($"Invalid Choose From one of the Following {moves[0]} {moves[1]} {moves[2]} {moves[3]} {moves[4]}");
                setMove(Console.ReadLine());
            }
        }

        public void setMove(String move)
        {
            switch (move)
            {
                case "Rock":
                case "rock":
                    this.move = 0;
                    break;
                case "Paper":
                case "paper":
                    this.move = 1;
                    break;
                case "Scissors":
                case "scissors":
                    this.move = 2;
                    break;
                case "Lizard":
                case "lizard":
                    this.move = 3;
                    break;
                case "Spock":
                case "spock":
                    this.move = 4;
                    break;
                default:
                    this.move = -1;
                    break;
            }
            
        }


        public int getMove()
        {
            return this.move;
        }

        private int Rock()
        {
            switch (this.move)
            {
                case 0:
                    return 0;
                    break;
                case 1:
                    return -1;
                    break;
                case 4:
                    return -1;
                    break;
                default:
                    return 1;
                    break;
            }

            return 1;
        }

        private int Paper()
        {
            switch (this.move)
            {
                case 1:
                    return 0;
                    break;
                case 2:
                    return -1;
                    break;
                case 3:
                    return -1;
                    break;

                default:
                    return 1;
            }
        }

        private int Scissors()
        {
            switch (this.move)
            {
                case 2:
                    return 0;
                    break;
                case 0:
                    return -1;
                    break;
                case 4:
                    return -1;
                    break;
                default:
                    break;
            }
            return 1;
        }

        private int Lizard()
        {
            switch (this.move)
            {
                case 3:
                    return 0;
                    break;
                case 0:
                    return -1;
                    break;
                case 2:
                    return -1;
                    break;
                case 4:
                    return -1;
                    break;
                default:
                    break;
            }

            return 1;
        }

        private int Spock()
        {
            switch (this.move)
            {
                case 4:
                    return 0;
                    break;
                case 3:
                    return -1;
                    break;
                case 1:
                    return -1;
                    break;
                default:
                    
                    break;
            }

            return 1;
        }

        public int checkWin(Move p2)
        {
            switch (p2.getMove())
            {
                case 0:
                    return Rock();
                case 1:
                    return Paper();
                case 2:
                    return Scissors();
                case 3:
                    return Lizard();
                case 4:
                    return Spock();
                default:
                    break;
            }
            return -1;
        }
    }
}