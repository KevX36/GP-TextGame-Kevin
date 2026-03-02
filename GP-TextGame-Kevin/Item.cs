using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP_TextGame_Kevin
{
    internal class Item
    {
        public int _xPos;
        public int _yPos;
        private string _icon = "T";
        private ConsoleColor color = ConsoleColor.Black;
        public Item(int x, int y)
        {
            _xPos = x;
            _yPos = y;
        }
        public virtual void use()
        {
            Console.WriteLine("you should not be reading this");
        }
        public void draw()
        {
            Console.BackgroundColor = color;
            Console.SetCursorPosition(_xPos + 5, _yPos + 5);
            Console.Write(_icon);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
        }
        


    }
}
