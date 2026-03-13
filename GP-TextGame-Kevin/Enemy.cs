using GP_TextGame_Kevin;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Enemy
    {
        public int _xPos;
        public int _yPos;
        public Health _health;
        public int moveStall = 0;
        public int strength;
        public char _icon = 'X';
        protected int _sightRange = 10;
        public Enemy(int HP, int x, int y)
        {
            _xPos = x;
            _yPos = y;
            _health = new Health(HP,0);
            Setstrength();
        }
        protected virtual void Setstrength()
        {
            strength = 1;
        }
        //checks if the player is within 10 spaces in all directions
        private bool PlayerIsClose()
        {

            if (GameManager.player._yPos <= _yPos + _sightRange && GameManager.player._xPos >= _xPos - _sightRange && GameManager.player._yPos <= _yPos + _sightRange && GameManager.player._yPos >= _yPos - _sightRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //detemings how enemy will move
        public virtual void MoveDirection(Player player, List<Enemy> enemies, Map map)
        {
            bool XFirst;
            Random XOrY = new Random();
            int priority = XOrY.Next(1, 3);
            if (priority == 1)
            {
                XFirst = true;
            }
            else
            {
                XFirst = false;
            }
            if (XFirst)
            {
                if (_xPos < player._xPos && PlayerIsClose())
                {
                    Move(_xPos + 1, _yPos );
                }
                else if (_xPos > player._xPos && PlayerIsClose())
                {
                    Move( _xPos - 1, _yPos);
                }
                else if (_yPos < player._yPos && PlayerIsClose())
                {
                    Move( _xPos, _yPos + 1);
                }
                else if (_yPos > player._yPos && PlayerIsClose())
                {
                    Move( _xPos, _yPos + -1);
                }
            }
            else
            {
                if (_yPos < player._yPos && PlayerIsClose())
                {
                    Move(_xPos, _yPos + 1);
                }
                else if (_yPos > player._yPos && PlayerIsClose())
                {
                    Move( _xPos, _yPos - 1);
                }
                else if (_xPos < player._xPos && PlayerIsClose())
                {
                    Move( _xPos + 1, _yPos);
                }
                else if (_xPos > player._xPos && PlayerIsClose())
                {
                    Move( _xPos - 1, _yPos);
                }

            }
        }
        //will move enemy or attack if player is in the way
        protected virtual void Move(int newX, int newY)
        {
            
            if(moveStall <= 0)
            {
                //checks space enemy tries to move to
                string spaceMovedTo = GameManager.map.CheckSpace(newX, newY,_xPos,_yPos);
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
                    moveStall++;
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

            }
            else
            {
                moveStall -= 1;
            }
        }
        
        public  void DrawEnemy()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_xPos + 5, _yPos + 5);
            Console.Write(_icon);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }















    }
}

