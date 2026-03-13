using GP_TextGame_Kevin;
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
        public int _lastEnemyStrength = 1;
        public int _xPos { get; private set; }
        public int _yPos { get; private set; }
        public Health _health;
        public int moveStall = 0;
        public int strength { get; private set; }
        public Player(int HP, int x, int y)
        {
            _xPos = x;
            _yPos = y;
            _health = new Health(HP,0);
            strength = 1;
        }
        //handles movment input
        public void MoveInput()
        {
            
            
            
            if (moveStall <= 0)
            {
                ConsoleKeyInfo moveInput = Console.ReadKey();

                if (moveInput.Key == ConsoleKey.W)
                {
                    Move(_xPos, _yPos - 1);
                }
                else if (moveInput.Key == ConsoleKey.S)
                {
                    Move( _xPos, _yPos + 1);
                }
                else if (moveInput.Key == ConsoleKey.A)
                {
                    Move(_xPos - 1, _yPos);
                }
                else if (moveInput.Key == ConsoleKey.D)
                {
                    Move(_xPos + 1, _yPos);
                }
            }
            else
            {
                moveStall -= 1;
            }

        }
        //actually moves player or attacks if enemy is in the way
        private void Move(int newX, int newY)
        {
            
            bool didNotAct = true;
            for (int i = 0; i < GameManager.enemies.Count; i++)
            {
                if (GameManager.enemies[i]._xPos == newX && GameManager.enemies[i]._yPos == newY)
                {

                    GameManager.enemies[i]._health.TakeDamage(strength);
                    didNotAct = false;
                    _lastEnemyHP = GameManager.enemies[i]._health._health;
                    _lastEnemyStrength = GameManager.enemies[i].strength;
                }
            }
            for(int i = 0; i < GameManager.items.Count; i++)
            {
                if (GameManager.items[i]._xPos == newX && GameManager.items[i]._yPos == newY)
                {
                    
                    GameManager.items[i].use();
                    didNotAct = false;
                    
                }
            }

            if (didNotAct)
            {
                string spaceMovedTo = GameManager.map.CheckSpace(newX, newY, _xPos, _yPos);
                if (spaceMovedTo == "clear")
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
