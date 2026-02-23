using FirstPlayable_GP2_Kevin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class GameManager
    {
        static public Map map = new Map();
        static public List<Enemy> enemies = new List<Enemy>();
        static public Player player = new Player(100, 0, 0);
        
    }
}
