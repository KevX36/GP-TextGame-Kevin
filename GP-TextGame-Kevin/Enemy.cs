using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Enemy
    {
        public int _xPos { get; private set; }
        public int _yPos { get; private set; }
        public Health _health;
        public Enemy(int HP, int x, int y)
        {
            _xPos = x;
            _yPos = y;
            _health = new Health(HP);
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
                if (_xPos < player._xPos)
                {
                    Move(player, enemies, map, _xPos + 1, _yPos);
                }
                else if (_xPos > player._xPos)
                {
                    Move(player, enemies, map, _xPos - 1, _yPos);
                }
                else if (_yPos < player._yPos)
                {
                    Move(player, enemies, map, _xPos, _yPos + 1);
                }
                else if (_yPos > player._yPos)
                {
                    Move(player, enemies, map, _xPos, _yPos + -1);
                }
            }
            else
            {
                if (_yPos < player._yPos)
                {
                    Move(player, enemies, map, _xPos, _yPos + 1);
                }
                else if (_yPos > player._yPos)
                {
                    Move(player, enemies, map, _xPos, _yPos - 1);
                }
                else if (_xPos < player._xPos)
                {
                    Move(player, enemies, map, _xPos + 1, _yPos);
                }
                else if (_xPos > player._xPos)
                {
                    Move(player, enemies, map, _xPos - 1, _yPos);
                }

            }
        }
        //will move enemy or attack if player is in the way
        private void Move(Player player, List<Enemy> enemies, Map map, int newX, int newY)
        {
            //checks space enemy tries to move to
            string spaceMovedTo = map.CheakSpace(newX, newY);
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
                player._health.TakeDamage(1);
            }
            //moves normally if on grass
            else if (spaceMovedTo == "clear")
            {
                _xPos = newX;
                _yPos = newY;
            }
        }
        
        public virtual void DrawEnemy()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(_xPos + 5, _yPos + 5);
            Console.Write("X");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }















    }
}

