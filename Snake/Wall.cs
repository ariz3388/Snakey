using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Wall
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        public Wall(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }

    public class Floor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        public Floor(int x, int y, Color color)
        {
            X = x; Y = y; Color = color;
        }
    }
}
