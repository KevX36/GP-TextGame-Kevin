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
                    GameManager.RemoveUsedOrDead();



                    GameManager.draw();



                    GameManager.Move();

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
