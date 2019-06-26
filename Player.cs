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

        public void win()
        {
            Console.WriteLine("Player {0} Wins!", this.id);
        }

    }
}
