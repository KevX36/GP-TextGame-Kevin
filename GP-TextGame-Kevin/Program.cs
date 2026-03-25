using GP_TextGame_Kevin;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
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
            bool playing = true;
            while (playing)
            {
                GameManager.map.DrawMap();
                GameManager.Score = 0;
                GameManager.player._health.FullHeal();

                Item_manager.spawnItems();
                EnemyManager.SpwanEnemies();

                while (GameManager.player._health.CheakIfAlive() && EnemyManager.boss._health.CheakIfAlive())
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine($"Health: {GameManager.player._health._health}    strength:{GameManager.player.strength}     Score: {GameManager.Score}       ExtraLives: {GameManager.player._health._revives}      Enemy Health: {GameManager.player._lastEnemyHP}      Enemy Strength: {GameManager.player._lastEnemyStrength}                 ");
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
                //end game
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                if (GameManager.player._health.CheakIfAlive() == false)
                {
                    Console.WriteLine("You Died, Game Over");
                }
                else if (GameManager.Score < 1010)
                {
                    Console.WriteLine("You Won");
                }
                else
                {
                    Console.WriteLine("You did Perfect!");
                }



                Console.ReadKey();
            }

            Console.WriteLine("would you like to play again, y or n");
            bool valadAwnser = false;
            while (!valadAwnser)
            {
                string con = Console.ReadKey().ToString();
                con = con.ToLower();
                if (con == "y")
                {
                    valadAwnser = true;
                }
                else if (con == "n")
                {
                    playing = false;
                    valadAwnser = true;
                }
                else Console.WriteLine("that is not a valad awnser");
            }

        }
        
    }
}
