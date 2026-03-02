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
        private GameManager()
        {

        }
        public static GameManager _instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
            private set
            {
                
            }
            
        }
        
        public static Map map = new Map();
        public static List<Enemy> enemies = new List<Enemy>();
        public static  Player player = new Player(100, 0, 0);
        
    }
}
