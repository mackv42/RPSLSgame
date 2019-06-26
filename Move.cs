using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Move
    {
        private List<int> moves;
        private int move;

        public void setMove(String move)
        {
            switch (move)
            {
                case "R":
                case "r":
                    this.move = 0;
                    break;
                case "P":
                case "p":
                    this.move = 1;
                    break;
                case "S":
                case "s":
                    this.move = 2;
                    break;
                case "L":
                case "l":
                    this.move = 3;
                    break;
                case "Sp":
                case "sp":
                    this.move = 4;
                    break;
            }
        }


        public int getMove()
        {
            return this.move;
        }

        private bool Rock()
        {

        }

        private bool Paper()
        {

        }

        private bool Scissors()
        {

        }

        private bool Lizard()
        {

        }

        private bool Spock()
        {

        }

        public bool CheckWin(Move p2)
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
            return true;
        }
    }
}