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
            Program.loopUntilTrue(() => {
                Console.WriteLine($"Choose From one of the Following {Program.moves[0]} {Program.moves[1]} {Program.moves[2]} {Program.moves[3]} {Program.moves[4]}");
                Console.Write("Player {0}: ", this.id);
                this.moveString = Console.ReadLine().ToLower();
                return Program.validateInput(this.moveString);
            });
            
            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }
    }
}
