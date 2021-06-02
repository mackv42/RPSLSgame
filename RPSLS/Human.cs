using System;
using System.Collections.Generic;
using System.Text;

namespace RPSLS
{
    class Human : Player
    {
        public Human(int id): base(id){}
        public override void MakeMove()
        {
            Game.LoopUntilTrue(() => {
                Console.WriteLine($"Choose From one of the Following {Game.moves[0]} {Game.moves[1]} {Game.moves[2]} {Game.moves[3]} {Game.moves[4]}");
                Console.Write("Player {0}: ", this.id);
                this.moveString = Console.ReadLine().ToLower();
                return Game.ValidateInput(this.moveString);
            });
            
            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }
    }
}
