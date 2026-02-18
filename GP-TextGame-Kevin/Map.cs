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

        private string[] _map = File.ReadAllLines(@"C:\Kevin's unity projects\GP-TextGame-Kevin\GP-TextGame-Kevin\MapText.txt");
        //you must run this before any other map methods

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
        public bool CheakSpace(int x, int y)
        {


            if (y < 0)
            {
                return false;
            }
            else if (y >= _map.Length)
            {
                return false;
            }
            else if (x < 0)
            {
                return false;
            }
            else if (x >= _map[y].Length)
            {
                return false;
            }
            else if (_map[y][x] != '`')
            {
                return false;
            }
            else
            {
                return true;
            }





        }














    }
}
