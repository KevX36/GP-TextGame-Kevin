using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Program
    {
        
        static Map map = new Map();
        static List<Enemy> enemies = new List<Enemy>();
        static List<int> enemiesToRemove = new List<int>();
        static int Score = 0;
        static void Main(string[] args)
        {
            
            enemies.Add(new Enemy(5, 19, 19));
            enemies.Add(new Enemy(5, 0, 19));
            enemies.Add(new Enemy(5, 19, 0));
            Player player = new Player(100, 0, 0);
            while (player._health.CheakIfAlive())
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Health: {player._health._health}        Score: {Score}      Enemy Health: {player._lastEnemyHP}");
                //removes dead enemies
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (!enemies[i]._health.CheakIfAlive())
                    {
                        enemiesToRemove.Add(i);
                    }
                }
                if (enemiesToRemove.Any())
                {
                    for (int i = 0; i < enemiesToRemove.Count; i++)
                    {
                        
                        enemies.Remove(enemies[enemiesToRemove[i]]);
                        Score++;
                    }
                    enemiesToRemove.Clear();
                }

                if (!enemies.Any())
                {
                    enemies.Add(new Enemy(5, 19, 19));
                    enemies.Add(new Enemy(5, 0, 19));
                    enemies.Add(new Enemy(5, 19, 0));
                    enemies.Add(new Enemy(5, 0, 0));
                }

                map.DrawMap();
                player.DrawPlayer();
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].DrawEnemy();
                }


                player.MoveInput(enemies, map);

                for (int i = 0; i < enemies.Count; i++)
                {
                    
                    enemies[i].MoveDirection(player,enemies, map);

                }











            }


            Console.WriteLine("You Died, Game Over");








        }
    }
}
