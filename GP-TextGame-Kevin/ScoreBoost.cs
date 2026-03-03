using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class ScoreBoost :Item
    {
        private int _Score;
        public ScoreBoost(int x, int y, int Score) : base(x, y)
        {
            _Score = Score;
            _icon = "S";
            color = ConsoleColor.Yellow;
        }
        public override void use()
        {
            GameManager.Score+= _Score;
            base.use();
        }
    }
}
