using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPSLS
{
    class Computer : Player
    {
        public Computer(int id) : base(id) { }
        public override void makeMove()
        {
            Console.WriteLine($"Its Your Turn Player {this.id}");
            Thread.Sleep(2000);
            Random rnd = new Random();
            this.moveString = Game.moves[rnd.Next(0, 4)];

        }
    }
}
