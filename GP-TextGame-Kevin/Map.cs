using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

namespace FirstPlayable_GP2_Kevin
{
    internal class Map
    {
        private Dictionary<char, ConsoleColor> backgroundColors = new Dictionary<char, ConsoleColor>()
        {
            {'`',ConsoleColor.Green },
            {'~', ConsoleColor.DarkBlue },
            {'^', ConsoleColor.DarkGray },
            {'H',ConsoleColor.DarkGreen },
            {'@',ConsoleColor.DarkMagenta },
            {'#' , ConsoleColor.White},
        };
        public string[] _map { get; } = File.ReadAllLines(@"MapText.txt");

        public void DrawMap()
        {

            for (int i = 0; i < _map.Length; i++)
            {

                for (int j = 0; j < _map[i].Length; j++)
                {
                    Console.SetCursorPosition(j + 5, i + 5);
                    Console.BackgroundColor = backgroundColors[_map[i][j]];
                    Console.Write(_map[i][j]);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

        }
        public String CheckSpace(int x, int y,int oldX, int oldY)
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
            else if (_map[y][x] == '~')
            {
                spaceResult = "water";
            }
            else if (_map[y][x] == 'H')
            {
                spaceResult = "forest";
            }
            else if (_map[y][x] == '@')
            {
                spaceResult = "swamp";
            }
            else if (_map[y][x] == '^')
            {
                spaceResult = "Mountain";
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

        public void redrawSpace(int x, int y)
        {
            Console.SetCursorPosition(x + 5, y + 5);
            Console.BackgroundColor = backgroundColors[_map[y][x]];
            Console.Write(_map[y][x]);
            Console.BackgroundColor = ConsoleColor.Black;
        }












    }
}
