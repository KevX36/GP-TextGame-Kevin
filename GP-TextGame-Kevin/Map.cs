using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace FirstPlayable_GP2_Kevin
{
    internal class Map
    {

        private string[] _map = File.ReadAllLines(@"MapText.txt");

        public void DrawMap()
        {

            for (int i = 0; i < _map.Length; i++)
            {

                for (int j = 0; j < _map.Length; j++)
                {

                    Console.SetCursorPosition(i + 5, j + 5);
                    if (_map[j][i] == '`')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else if (_map[j][i] == '~')
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (_map[j][i] == '^')
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    Console.Write(_map[j][i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

        }
        public String CheakSpace(int x, int y)
        {


            if (y < 0)
            {
                return "fail";
            }
            else if (y >= _map.Length)
            {
                return "fail";
            }
            else if (x < 0)
            {
                return "fail";
            }
            else if (x >= _map[y].Length)
            {
                return "fail";
            }
            else if (_map[y][x] == '`')
            {
                return "clear";
            }
            else
            {
                return "fail";
            }





        }














    }
}
