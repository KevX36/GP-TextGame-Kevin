using FirstPlayable_GP2_Kevin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class StrongEnemy : Enemy
    {


        public StrongEnemy(int HP, int x, int y) : base(HP, x, y)
        {
            //changes how enemy is drawn
            _icon = '!';
        }
        protected override void Setstrength()
        {
            strength = 5;
        }
        protected override void Move(Player player, List<Enemy> enemies, Map map, int newX, int newY)
        {

            if (moveStall <= 0)
            {
                //checks space enemy tries to move to
                string spaceMovedTo = map.CheckSpace(newX, newY, _xPos, _yPos);
                //stops enemies stacking
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i]._xPos == newX && enemies[i]._yPos == newY)
                    {

                        return;
                    }
                }
                //attacks player
                if (player._xPos == newX && player._yPos == newY)
                {
                    player._health.TakeDamage(strength);
                }
                //moves normally if on grass
                else if (spaceMovedTo == "clear")
                {
                    _xPos = newX;
                    _yPos = newY;
                }
                else if (spaceMovedTo == "water")
                {
                    _xPos = newX;
                    _yPos = newY;
                    moveStall+= 2;
                }
                moveStall += 2;
            }
            else
            {
                moveStall -= 1;
            }
        }










    }
}
