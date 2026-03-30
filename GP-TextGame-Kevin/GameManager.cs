using FirstPlayable_GP2_Kevin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class GameManager
    {
        private GameManager()
        {

        }
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
            
            
        }
        public static void RemoveUsedOrDead()
        {
            List<int> enemiesToRemove = new List<int>();
            List<int> itemsToRemove = new List<int>();
            //removes dead enemies
            if (EnemyManager.enemies.Any())
            {
                for (int i = 0; i < EnemyManager.enemies.Count; i++)
                {
                    if (!EnemyManager.enemies[i]._health.CheakIfAlive())
                    {
                        GameManager.map.redrawSpace(EnemyManager.enemies[i]._xPos, EnemyManager.enemies[i]._yPos);
                        enemiesToRemove.Add(i);
                    }
                }
                if (enemiesToRemove.Any())
                {
                    for (int i = 0; i < enemiesToRemove.Count; i++)
                    {

                        GameManager.player._lastEnemy = 0;
                        EnemyManager.enemies.Remove(EnemyManager.enemies[enemiesToRemove[i]]);
                        GameManager.Score += 10;
                    }
                    enemiesToRemove.Clear();
                }
            }

            //removes used items
            if (Item_manager.items.Any())
            {
                for (int i = 0; i < Item_manager.items.Count; i++)
                {
                    if (Item_manager.items[i].hasBeenUsed)
                    {
                        GameManager.map.redrawSpace(Item_manager.items[i]._xPos, Item_manager.items[i]._yPos);
                        itemsToRemove.Add(i);
                    }
                }
                if (itemsToRemove.Any())
                {
                    for (int i = 0; i < itemsToRemove.Count; i++)
                    {




                        Item_manager.items.Remove(Item_manager.items[itemsToRemove[i]]);

                    }
                    itemsToRemove.Clear();
                }
            }
        }
        public static void Draw()
        {
            GameManager.player.DrawPlayer();
            EnemyManager.boss.DrawEnemy();
            if (Item_manager.items.Any())
            {
                for (int i = 0; i < Item_manager.items.Count; i++)
                {

                    Item_manager.items[i].Draw();

                }
            }

            if (EnemyManager.enemies.Any())
            {
                for (int i = 0; i < EnemyManager.enemies.Count; i++)
                {

                    EnemyManager.enemies[i].DrawEnemy();
                }
            }
        }
        public static void Move()
        {
            GameManager.player.MoveInput();
            if (EnemyManager.enemies.Any())
            {
                for (int i = 0; i < EnemyManager.enemies.Count; i++)
                {


                    EnemyManager.enemies[i].MoveDirection();

                }
            }


            EnemyManager.boss.MoveDirection();
        }
        public static int forestHeal = 3;
        public static int swampDamage = 3;
        public static int Score = 0;
        
        public static Map map = new Map();
        
        public static  Player player = new Player(100, 0, 0);
        
    }
}
