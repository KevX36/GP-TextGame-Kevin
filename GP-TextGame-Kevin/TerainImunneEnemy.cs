using FirstPlayable_GP2_Kevin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class TerainImunneEnemy : Enemy
    {
        public TerainImunneEnemy(int HP, int x, int y) : base(HP, x, y)
        {
            //changes how enemy is drawn
            _icon = '%';
        }

        protected override void Move(int newX, int newY)
        {

            if (moveStall <= 0)
            {
                //checks space enemy tries to move to
                string spaceMovedTo = GameManager.map.CheckSpace(newX, newY, _xPos, _yPos);
                //stops enemies stacking
                for (int i = 0; i < GameManager.enemies.Count; i++)
                {
                    if (GameManager.enemies[i]._xPos == newX && GameManager.enemies[i]._yPos == newY)
                    {

                        return;
                    }
                }
                //attacks player
                if (GameManager.player._xPos == newX && GameManager.player._yPos == newY)
                {
                    //enemies have a chance to miss
                    Random ran = new Random();
                    if (ran.Next(0, 10) > 0)
                    {
                        GameManager.player._health.TakeDamage(strength);
                    }
                }
                //moves normally if on grass
                else if (spaceMovedTo != "fail")
                {
                    _xPos = newX;
                    _yPos = newY;
                }

            }
            else
            {
                moveStall -= 1;
            }
        }
    }
}
