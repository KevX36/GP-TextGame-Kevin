using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class Heal : Item
    {
        private int healing;
        public Heal(int x, int y,int HP) :base (x,y)
        {
            healing = HP;
            _icon = "+";
            color = ConsoleColor.Magenta;
        }
        public override void use()
        {
            GameManager.player._health.Heal(healing);
            base.use();
        }





    }
}
