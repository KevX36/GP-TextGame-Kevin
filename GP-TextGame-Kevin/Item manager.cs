using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class Item_manager
    {

        public static List<Item> items = new List<Item>();
        public static void spawnItems()
        {
            Item_manager.items.Clear();
            Item_manager.items.Add(new ExtraLife(18, 9, 1));
            Item_manager.items.Add(new ExtraLife(55, 21, 1));
            Item_manager.items.Add(new ScoreBoost(99, 17, 20));
            Item_manager.items.Add(new ScoreBoost(99, 23, 20));
            Item_manager.items.Add(new ScoreBoost(91, 17, 20));
            Item_manager.items.Add(new ScoreBoost(91, 23, 20));
            Item_manager.items.Add(new ScoreBoost(77, 6, 20));
            Item_manager.items.Add(new ScoreBoost(85, 6, 20));
            Item_manager.items.Add(new ScoreBoost(4, 16, 20));
            Item_manager.items.Add(new ScoreBoost(13, 17, 20));
            Item_manager.items.Add(new ScoreBoost(20, 8, 20));
            Item_manager.items.Add(new ScoreBoost(2, 8, 20));
            Item_manager.items.Add(new ScoreBoost(17, 0, 20));
            Item_manager.items.Add(new ScoreBoost(22, 23, 20));
            Item_manager.items.Add(new ScoreBoost(25, 13, 20));
            Item_manager.items.Add(new ScoreBoost(55, 10, 20));
            Item_manager.items.Add(new ScoreBoost(29, 1, 20));
            Item_manager.items.Add(new ScoreBoost(29, 8, 20));
            Item_manager.items.Add(new ScoreBoost(43, 0, 20));
            Item_manager.items.Add(new ScoreBoost(53, 1, 20));
            Item_manager.items.Add(new ScoreBoost(41, 23, 20));
            Item_manager.items.Add(new ScoreBoost(64, 21, 20));
            Item_manager.items.Add(new ScoreBoost(55, 14, 20));
            Item_manager.items.Add(new ScoreBoost(73, 20, 20));
            Item_manager.items.Add(new ScoreBoost(90, 17, 20));
            Item_manager.items.Add(new ScoreBoost(90, 23, 20));
            Item_manager.items.Add(new ScoreBoost(98, 17, 20));
            Item_manager.items.Add(new ScoreBoost(98, 23, 20));
            Item_manager.items.Add(new ScoreBoost(0, 18, 20));
            Item_manager.items.Add(new ScoreBoost(34, 17, 20));
            Item_manager.items.Add(new Heal(23, 20, 20));
            Item_manager.items.Add(new Heal(56, 1, 20));
            Item_manager.items.Add(new Heal(55, 12, 20));
            Item_manager.items.Add(new Heal(0, 21, 40));
            Item_manager.items.Add(new Heal(24, 0, 20));
        }
    }
}
