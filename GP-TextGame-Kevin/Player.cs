using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Player
    {
        public int _lastEnemyHP = 5;
        public int _xPos { get; private set; }
        public int _yPos { get; private set; }
        public Health _health;
        public int moveStall = 0;
        public int strength { get; private set; }
        public Player(int HP, int x, int y)
        {
            _xPos = x;
            _yPos = y;
            _health = new Health(HP);
            strength = 1;
        }
        //handles movment input
        public void MoveInput(List<Enemy> enemies, Map map)
        {
            ConsoleKeyInfo moveInput = Console.ReadKey();
            
            if (moveInput.Key == ConsoleKey.W)
            {
                Move(enemies, map, _xPos, _yPos - 1);
            }
            else if (moveInput.Key == ConsoleKey.S)
            {
                Move(enemies, map, _xPos, _yPos + 1);
            }
            else if (moveInput.Key == ConsoleKey.A)
            {
                Move(enemies, map, _xPos - 1, _yPos);
            }
            else if (moveInput.Key == ConsoleKey.D)
            {
                Move(enemies, map, _xPos + 1, _yPos);
            }


        }
        //actually moves player or attacks if enemy is in the way
        private void Move(List<Enemy> enemies, Map map, int newX, int newY)
        {
            if(moveStall <= 0)
            {
                bool didNotAttack = true;
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i]._xPos == newX && enemies[i]._yPos == newY)
                    {

                        enemies[i]._health.TakeDamage(strength);
                        didNotAttack = false;
                        _lastEnemyHP = enemies[i]._health._health;
                    }
                }


                if (didNotAttack)
                {
                    string spaceMovedTo = map.CheakSpace(newX, newY, _xPos,_yPos);
                    if (spaceMovedTo == "clear")
                    {
                        _xPos = newX;
                        _yPos = newY;
                    }

                }
            }
            else
            {
                moveStall -= 1;
            }

        }

        public void DrawPlayer()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(_xPos + 5, _yPos + 5);
            Console.Write("*");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }

    }
}
