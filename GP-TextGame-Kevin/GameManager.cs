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
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
            
            
        }
        
        public static int forestHeal = 3;
        public static int swampDamage = 3;
        public static int Score = 0;
        
        public static Map map = new Map();
        
        public static  Player player = new Player(100, 0, 0);
        
    }
}
