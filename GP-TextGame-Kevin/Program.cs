using GP_TextGame_Kevin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Program
    {
        static GameManager gameManager = new GameManager();
        static List<int> enemiesToRemove = new List<int>();
        static int Score = 0;
        static Random random = new Random();
        static void Main(string[] args)
        {
            GameManager.map.DrawMap();
            AddNewEnemies(3);
            
            
            while (GameManager.player._health.CheakIfAlive())
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Health: {GameManager.player._health._health}    strength:{GameManager.player.strength}     Score: {Score}      Enemy Health: {GameManager.player._lastEnemyHP}      Enemy Strength: {GameManager.player._lastEnemyStrength}                 ");
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

                        GameManager.enemies.Remove(GameManager.enemies[enemiesToRemove[i]]);
                        Score++;
                    }
                    enemiesToRemove.Clear();
                }

                if (!GameManager.enemies.Any())
                {
                    AddNewEnemies(4);
                }


                GameManager.player.DrawPlayer();
                for (int i = 0; i < GameManager.enemies.Count; i++)
                {
                    GameManager.enemies[i].DrawEnemy();
                }


                GameManager.player.MoveInput(GameManager.enemies, GameManager.map);

                for (int i = 0; i < GameManager.enemies.Count; i++)
                {

                    GameManager.enemies[i].MoveDirection(GameManager.player, GameManager.enemies, GameManager.map);

                }











            }


            Console.WriteLine("You Died, Game Over");








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
