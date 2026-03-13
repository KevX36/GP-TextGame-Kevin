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
                        GameManager.map.redrawSpace(GameManager.enemies[i]._xPos, GameManager.enemies[i]._yPos);
                        enemiesToRemove.Add(i);
                    }
                }
                if (enemiesToRemove.Any())
                {
                    for (int i = 0; i < enemiesToRemove.Count; i++)
                    {
                        
                        
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
                        GameManager.map.redrawSpace(GameManager.items[i]._xPos, GameManager.items[i]._yPos);
                        itemsToRemove.Add(i);
                    }
                }
                if (itemsToRemove.Any())
                {
                    for (int i = 0; i < itemsToRemove.Count; i++)
                    {

                       


                        GameManager.items.Remove(GameManager.items[itemsToRemove[i]]);
                        
                    }
                    itemsToRemove.Clear();
                }
                //adds new items and enemies if there's less then the maximum
                if (GameManager.enemies.Count < GameManager.maxEnemies)
                {
                    AddNewEnemies(1);
                }
                if (GameManager.items.Count < GameManager.maxItems)
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
                x = random.Next(0, GameManager.map._map[1].Length);
                y = random.Next(0, GameManager.map._map.Length);
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
                GameManager.items.Add(new Heal(x, y, 5));
            }
            else
            {
                //replace with 3rd enemy type later
                GameManager.items.Add(new ExtraLife(x, y, 1));
            }
        }
        
        static void AddNewEnemies(int enemiesToAdd)
        {
            int x = 19;
            int y = 19;
            
            for (int i = 0; i < enemiesToAdd; i++)
            {
                bool emptySpace = false;
                while (!emptySpace)
                {
                    x = random.Next(0, GameManager.map._map[1].Length);
                    y = random.Next(0, GameManager.map._map.Length);
                    string checkedSpace = GameManager.map.CheckSpace(x, y, x, y);
                    if (checkedSpace == "clear" && x != GameManager.player._xPos && y != GameManager.player._yPos)
                    {
                        emptySpace = true;
                    }

                }
                //sets enemy type
                int enemyType = random.Next(1, 101);
                if (enemyType <= 50)
                {
                    GameManager.enemies.Add(new Enemy(5, x, y));
                }
                else if (enemyType <= 80)
                {
                    GameManager.enemies.Add(new TerainImunneEnemy(5, x, y));
                }
                else if (enemyType <= 95)
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
