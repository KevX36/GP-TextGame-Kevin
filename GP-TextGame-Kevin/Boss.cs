using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstPlayable_GP2_Kevin;

namespace GP_TextGame_Kevin
{
    internal class Boss : Enemy
    {
        public Boss(int HP, int x, int y) : base(HP, x, y)
        {
            //changes how enemy is drawn
            _icon = 'B';
        }
        protected override void Setstrength()
        {
            strength = 5;
        }
        protected override void Move(int newX, int newY)
        {
            //almost the same as base enemy but stalls after moving
            if (moveStall <= 0)
            {
                //checks space enemy tries to move to
                string spaceMovedTo = GameManager.map.CheckSpace(newX, newY, _xPos, _yPos);
                //stops enemies stacking
                for (int i = 0; i < EnemyManager.enemies.Count; i++)
                {
                    if (EnemyManager.enemies[i]._xPos == newX && EnemyManager.enemies[i]._yPos == newY)
                    {

                        return;
                    }
                }
                //attacks player
                if (GameManager.player._xPos == newX && GameManager.player._yPos == newY)
                {
                    GameManager.player._health.TakeDamage(strength);
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
                    moveStall += 2;
                }
                else if (spaceMovedTo == "forest")
                {
                    _xPos = newX;
                    _yPos = newY;
                    _health.Heal(GameManager.forestHeal);
                }
                else if (spaceMovedTo == "swamp")
                {
                    _xPos = newX;
                    _yPos = newY;
                    _health.TakeDamage(GameManager.swampDamage);
                }
                Random stall = new Random();
                int stallInt = stall.Next(0, 4);
                moveStall += stallInt;
                if (moveStall == 0)
                {
                    strength = 3;
                }
                else if (stallInt == 1)
                {
                    strength = 5;
                }
                else if (stallInt == 2)
                {
                    strength = 10;
                }
                else
                {
                    strength = 30;
                }
            }
            else
            {
                moveStall -= 1;
            }
        }
    }
}
