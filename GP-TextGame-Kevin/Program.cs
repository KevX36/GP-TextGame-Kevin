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

            GameManager.enemies.Add(new Enemy(3,4,4));
            GameManager.enemies.Add(new LostEnemy(3,2,14));
            GameManager.enemies.Add(new Enemy(3, 21, 0));
            GameManager.enemies.Add(new Enemy(3, 31, 1));
            GameManager.enemies.Add(new StrongEnemy (5,14,16));
            GameManager.enemies.Add(new TerainImunneEnemy(3,13,14));
            GameManager.enemies.Add(new TerainImunneEnemy(3,15,14));
            GameManager.enemies.Add(new TerainImunneEnemy(3,19,17));
            GameManager.enemies.Add(new TerainImunneEnemy(3,8,16));
            GameManager.enemies.Add(new Enemy(5,19,10));
            GameManager.enemies.Add(new TerainImunneEnemy(3, 20, 2));
            GameManager.enemies.Add(new TerainImunneEnemy(3, 27, 2));
            GameManager.enemies.Add(new TerainImunneEnemy(3, 25, 8));
            GameManager.enemies.Add(new TerainImunneEnemy(3, 34, 8));
            GameManager.enemies.Add(new StrongEnemy(3,33,15));
            GameManager.enemies.Add(new Enemy(5,26,16));
            GameManager.enemies.Add(new Enemy(5,19,21));
            GameManager.enemies.Add(new Enemy(5, 21, 21));
            GameManager.enemies.Add(new LostEnemy(3,29,16));
            GameManager.enemies.Add(new LostEnemy(3,23,12));
            GameManager.enemies.Add(new LostEnemy(3, 41, 20));
            GameManager.enemies.Add(new Enemy(5, 40, 22));
            GameManager.enemies.Add(new Enemy(5, 42, 22));
            GameManager.enemies.Add(new TerainImunneEnemy(3,57 , 19));
            GameManager.enemies.Add(new StrongEnemy(3, 53, 19));
            GameManager.enemies.Add(new TerainImunneEnemy(3, 57, 19));
            GameManager.enemies.Add(new Enemy(5, 66, 19));
            GameManager.enemies.Add(new TerainImunneEnemy(3, 47, 6));
            GameManager.enemies.Add(new Enemy(5,47,0));
            GameManager.enemies.Add(new TerainImunneEnemy(3, 58, 4));
            GameManager.enemies.Add(new StrongEnemy(5,58,5));
            GameManager.enemies.Add(new Enemy(5,58,6));
            GameManager.enemies.Add(new StrongEnemy(5,43,2));
            GameManager.enemies.Add(new LostEnemy(3,58,14));
            GameManager.enemies.Add(new StrongEnemy(5,56,12));
            GameManager.enemies.Add(new StrongEnemy(5,59,11));
            GameManager.enemies.Add(new StrongEnemy(5,80,7));
            GameManager.enemies.Add(new Enemy(5,85,4));
            GameManager.enemies.Add(new Enemy(5,79,4));
            GameManager.enemies.Add(new TerainImunneEnemy(3,77,6));
            GameManager.enemies.Add(new TerainImunneEnemy(3,79,21));
            GameManager.enemies.Add(new StrongEnemy(5,79,19));
            GameManager.enemies.Add(new Enemy(5,73,18));
            GameManager.enemies.Add(new Enemy(5,73,23));
            GameManager.enemies.Add(new Enemy(5,79,23));
            GameManager.items.Add(new ExtraLife(18,9,1));
            GameManager.items.Add(new ExtraLife(55, 21, 1));
            

            while (GameManager.player._health.CheakIfAlive() && GameManager.boss._health.CheakIfAlive())
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

                        GameManager.player._lastEnemy = 0;
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
                

                GameManager.player.DrawPlayer();
                GameManager.boss.DrawEnemy();
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

                GameManager.boss.MoveDirection(GameManager.player, GameManager.enemies, GameManager.map);
                








            }


            Console.WriteLine("You Died, Game Over");








        }
        
    }
}
