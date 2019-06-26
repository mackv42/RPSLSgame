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
            this.currentMove = new Move(() =>
            {
                Thread.Sleep(1000);
                /*switch (Math.rand())
                {

                }*/
                return "a";
            });
        }
    }
}
