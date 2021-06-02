using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    abstract class Player
    {
        protected int wins;
        protected int id;

        protected String moveString;

        public Player(int id) {
            this.id = id;
        }

        public void WinRound()
        {
            this.wins++;
        }
        public bool Win()
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Player {0} Wins!", this.id);
            return true;
        }

        public bool CheckWin()
        {
            if (wins >= 2)
                return Win();

            return false;
        }
        
        public String MoveString()
        {
            return this.moveString;
        }

        public virtual void MakeMove() { }
    }
}
