using FirstPlayable_GP2_Kevin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class EnemyManager
    {
        public static Enemy boss = new Boss(30, 99, 21);
        public static List<Enemy> enemies = new List<Enemy>();
        public static void SpwanEnemies()
        {
            EnemyManager.enemies.Add(new Enemy(3, 4, 4));
            EnemyManager.enemies.Add(new LostEnemy(3, 2, 14));
            EnemyManager.enemies.Add(new Enemy(3, 21, 0));
            EnemyManager.enemies.Add(new Enemy(3, 31, 1));
            EnemyManager.enemies.Add(new StrongEnemy(5, 14, 16));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 13, 14));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 15, 14));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 19, 17));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 8, 16));
            EnemyManager.enemies.Add(new Enemy(5, 19, 10));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 20, 2));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 27, 2));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 25, 8));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 34, 8));
            EnemyManager.enemies.Add(new StrongEnemy(3, 33, 15));
            EnemyManager.enemies.Add(new Enemy(5, 26, 16));
            EnemyManager.enemies.Add(new Enemy(5, 19, 21));
            EnemyManager.enemies.Add(new Enemy(5, 21, 21));
            EnemyManager.enemies.Add(new LostEnemy(3, 29, 16));
            EnemyManager.enemies.Add(new LostEnemy(3, 33, 12));
            EnemyManager.enemies.Add(new LostEnemy(3, 41, 20));
            EnemyManager.enemies.Add(new Enemy(5, 40, 22));
            EnemyManager.enemies.Add(new Enemy(5, 42, 22));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 57, 19));
            EnemyManager.enemies.Add(new StrongEnemy(3, 53, 19));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 57, 19));
            EnemyManager.enemies.Add(new Enemy(5, 66, 19));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 47, 6));
            EnemyManager.enemies.Add(new Enemy(5, 47, 0));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 58, 4));
            EnemyManager.enemies.Add(new StrongEnemy(5, 58, 5));
            EnemyManager.enemies.Add(new Enemy(5, 58, 6));
            EnemyManager.enemies.Add(new StrongEnemy(5, 43, 2));
            EnemyManager.enemies.Add(new LostEnemy(3, 58, 14));
            EnemyManager.enemies.Add(new StrongEnemy(5, 56, 12));
            EnemyManager.enemies.Add(new StrongEnemy(5, 59, 11));
            EnemyManager.enemies.Add(new StrongEnemy(5, 80, 7));
            EnemyManager.enemies.Add(new Enemy(5, 85, 4));
            EnemyManager.enemies.Add(new Enemy(5, 79, 4));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 77, 7));
            EnemyManager.enemies.Add(new TerainImunneEnemy(3, 79, 21));
            EnemyManager.enemies.Add(new StrongEnemy(5, 79, 19));
            EnemyManager.enemies.Add(new Enemy(5, 73, 18));
            EnemyManager.enemies.Add(new Enemy(5, 73, 23));
            EnemyManager.enemies.Add(new Enemy(5, 79, 23));
        }

    }
}
