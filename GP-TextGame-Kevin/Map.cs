using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Eventing.Reader;

namespace FirstPlayable_GP2_Kevin
{
    internal class Map
    {
        private Dictionary<char, ConsoleColor> backgroundColors = new Dictionary<char, ConsoleColor>()
        {
            {'`',ConsoleColor.Green },
            {'~', ConsoleColor.Blue },
            {'^', ConsoleColor.Gray }
        };
        private string[] _map = File.ReadAllLines(@"MapText.txt");

        public void DrawMap()
        {

            for (int i = 0; i < _map.Length; i++)
            {

                for (int j = 0; j < _map.Length; j++)
                {
                    Console.SetCursorPosition(i + 5, j + 5);
                    Console.BackgroundColor = backgroundColors[_map[j][i]];
                    Console.Write(_map[j][i]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

        }
        public String CheakSpace(int x, int y,int oldX, int oldY)
        {
            string spaceResult;

            if (y < 0)
            {
                spaceResult = "fail";
            }
            else if (y >= _map.Length)
            {
                spaceResult = "fail";
            }
            else if (x < 0)
            {
                spaceResult = "fail";
            }
            else if (x >= _map[y].Length)
            {
                spaceResult = "fail";
            }
            else if (_map[y][x] == '`')
            {
                spaceResult = "clear";
            }
            else
            {
                spaceResult = "fail";
            }

            if(spaceResult != "fail")
            {
                Console.SetCursorPosition(oldX+5, oldY+5);
                Console.BackgroundColor = backgroundColors[_map[oldY][oldX]];
                Console.Write(_map[oldY][oldX]);
                Console.BackgroundColor = ConsoleColor.Black;
            }

                return spaceResult;

        }














    }
}
