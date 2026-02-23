using FirstPlayable_GP2_Kevin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class LostEnemy : Enemy
    {
        
        public LostEnemy(int HP, int x, int y) : base(HP, x, y)
        {
            //changes how enemy is drawn
            Icon = '?';
        }
        public override void MoveDirection(Player player, List<Enemy> enemies, Map map)
        {
            
            
            Random direction = new Random();
            int directionMoved = direction.Next(1, 5);
            
            
            if (directionMoved == 1)
            {
                Move(player, enemies, map, _xPos, _yPos + 1);
            }
            else if (directionMoved == 2)
            {
                Move(player, enemies, map, _xPos, _yPos - 1);
            }
            else if (directionMoved ==3)
            {
                Move(player, enemies, map, _xPos + 1, _yPos);
            }
            else
            {
                Move(player, enemies, map, _xPos - 1, _yPos);
            }

        }
        
    }
}
