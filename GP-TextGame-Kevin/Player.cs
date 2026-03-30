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
        public int _lastEnemy = 0;
        public int _xPos;
        public int _yPos;
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
            if (EnemyManager.enemies.Any())
            {
                for (int i = 0; i < EnemyManager.enemies.Count; i++)
                {
                    if (EnemyManager.enemies[i]._xPos == newX && EnemyManager.enemies[i]._yPos == newY)
                    {

                        EnemyManager.enemies[i]._health.TakeDamage(strength);
                        didNotAct = false;
                        _lastEnemy = i+1;
                    }
                }
                
            }
            
            if (EnemyManager.boss._xPos == newX && EnemyManager.boss._yPos == newY)
            {

                EnemyManager.boss._health.TakeDamage(strength);
                didNotAct = false;
                _lastEnemy = 0;
            }
            //sets enemy stats in hud
            if (_lastEnemy == 0)
            {
                _lastEnemyHP = EnemyManager.boss._health._health;
                _lastEnemyStrength = EnemyManager.boss.strength;
            }
            else
            {
                _lastEnemyHP = EnemyManager.enemies[_lastEnemy-1]._health._health;
                _lastEnemyStrength = EnemyManager.enemies[_lastEnemy-1].strength;
            }
            if (Item_manager.items.Any())
            {
                for (int i = 0; i < Item_manager.items.Count; i++)
                {
                    if (Item_manager.items[i]._xPos == newX && Item_manager.items[i]._yPos == newY)
                    {

                        Item_manager.items[i].use();
                        didNotAct = false;

                    }
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
