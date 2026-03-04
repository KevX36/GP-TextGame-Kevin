using GP_TextGame_Kevin;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Program
    {
        
        static List<int> enemiesToRemove = new List<int>();
        static List<int> itemsToRemove = new List<int>();
        static Random random = new Random();
        static void Main(string[] args)
        {
            GameManager.map.DrawMap();
            AddNewEnemies(3);
            
            
            while (GameManager.player._health.CheakIfAlive())
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Health: {GameManager.player._health._health}    strength:{GameManager.player.strength}     Score: {GameManager.Score}       ExtraLives: {GameManager.player._health._revives}      Enemy Health: {GameManager.player._lastEnemyHP}      Enemy Strength: {GameManager.player._lastEnemyStrength}                 ");
                //removes dead enemies
                for (int i = 0; i < GameManager.enemies.Count; i++)
                {
                    if (!GameManager.enemies[i]._health.CheakIfAlive())
                    {
                        enemiesToRemove.Add(i);
                    }
                }
                if (enemiesToRemove.Any())
                {
                    for (int i = 0; i < enemiesToRemove.Count; i++)
                    {
                        GameManager.map.redrawSpace(GameManager.enemies[i]._xPos, GameManager.enemies[i]._yPos);
                        
                        GameManager.enemies.Remove(GameManager.enemies[enemiesToRemove[i]]);
                        GameManager.Score++;
                    }
                    enemiesToRemove.Clear();
                }
                //removes used items
                for (int i = 0; i < GameManager.items.Count; i++)
                {
                    if (GameManager.items[i].hasBeenUsed)
                    {
                        itemsToRemove.Add(i);
                    }
                }
                if (itemsToRemove.Any())
                {
                    for (int i = 0; i < itemsToRemove.Count; i++)
                    {
                        GameManager.map.redrawSpace(GameManager.items[i]._xPos, GameManager.items[i]._yPos);

                        GameManager.items.Remove(GameManager.items[itemsToRemove[i]]);
                        
                    }
                    itemsToRemove.Clear();
                }
                if (!GameManager.enemies.Any())
                {
                    AddNewEnemies(4);
                }
                if (GameManager.items.Count < 3)
                {
                    AddNewItem();
                }

                GameManager.player.DrawPlayer();
                for (int i = 0; i < GameManager.items.Count; i++)
                {
                    GameManager.items[i].Draw();
                }
                for (int i = 0; i < GameManager.enemies.Count; i++)
                {
                    GameManager.enemies[i].DrawEnemy();
                }


                GameManager.player.MoveInput();

                for (int i = 0; i < GameManager.enemies.Count; i++)
                {

                    GameManager.enemies[i].MoveDirection(GameManager.player, GameManager.enemies, GameManager.map);

                }


                








            }


            Console.WriteLine("You Died, Game Over");








        }
        static void AddNewItem()
        {
            int x = 19;
            int y = 19;
            bool emptySpace = false;
            while (!emptySpace)
            {
                x = random.Next(0, 20);
                y = random.Next(0, 20);
                string checkedSpace = GameManager.map.CheckSpace(x, y, x, y);
                if (checkedSpace == "clear")
                {
                    emptySpace = true;
                }

            }
            int itemType = random.Next(1, 101);
            if (itemType <= 50)
            {
                GameManager.items.Add(new ScoreBoost(x, y,10));
            }
            else if (itemType <= 90)
            {
                GameManager.items.Add(new Heal(x, y,5));
            }
            else
            {
                //replace with 3rd enemy type later
                GameManager.items.Add(new ExtraLife(x, y,1));
            }
        }
        
        static void AddNewEnemies(int enemiesToAdd)
        {
            int x = 19;
            int y = 19;
            
            for (int i = 0; i < enemiesToAdd; i++)
            {
                //sets position
                if(i == 0)
                {
                    x = 19;
                    y = 0;
                }
                else if(i == 1)
                {
                    x = 0;
                    y = 19;
                }
                else if (i == 2)
                {
                    x = 19;
                    y = 19;
                }
                else if(i == 3)
                {
                    x = 0;
                    y = 0;
                }
                else
                {
                    bool emptySpace = false;
                    while (!emptySpace)
                    {
                        x = random.Next(0, 20);
                        y = random.Next(0, 20);
                        string checkedSpace = GameManager.map.CheckSpace(x, y, x, y);
                        if(checkedSpace == "clear")
                        {
                            emptySpace = true;
                        }

                    }
                    
                }
                //sets enemy type
                    int enemyType = random.Next(1, 101);
                if (enemyType <= 50)
                {
                    GameManager.enemies.Add(new Enemy(5, x, y));
                }
                else if (enemyType <= 90)
                {
                    GameManager.enemies.Add(new LostEnemy(3, x, y));
                }
                else
                {
                    //replace with 3rd enemy type later
                    GameManager.enemies.Add(new StrongEnemy(10, x, y));
                }
            }
        }
    }
}
