using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Human : Player
    {
        public Human(int id): base(id){}
        public override void makeMove()
        {
            this.currentMove = new Move(() => {
                Console.Write("Player {0}: ", this.id);
                return Console.ReadLine();
            });
        }
    }
}
