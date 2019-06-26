using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    abstract class Player
    {
        protected int wins;
        protected int id;
        protected Move currentMove;
        protected String moveString;

        public Player(int id) {
            this.id = id;
        }

        public void winRound()
        {
            this.wins++;
        }
        public bool win()
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Player {0} Wins!", this.id);
            return true;
        }

        public bool checkWin()
        {
            if (wins >= 2)
                return win();

            return false;
        }
        
        public Move getMove()
        {
            return currentMove;
        }

        public String getMoveString()
        {
            return this.moveString;
        }

        public virtual void makeMove() { }
    }
}
