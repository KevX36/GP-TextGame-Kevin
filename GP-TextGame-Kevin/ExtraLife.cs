using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class ExtraLife : Item
    {
        int _liveToAdd;
        public ExtraLife(int x, int y,int livesToAdd) : base(x, y)
        {
            
            _icon = "L";
            color = ConsoleColor.DarkGreen;
            _liveToAdd = livesToAdd;
        }
        public override void use()
        {
            GameManager.player._health._revives += _liveToAdd;
            base.use();
        }
    }
}
