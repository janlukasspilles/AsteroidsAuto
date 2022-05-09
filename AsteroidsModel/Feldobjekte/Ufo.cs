using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel
{
    public class Ufo : FieldObject
    {
        private int _size;

        public Ufo(Point position, int size)
        {
            Position = position;
            Size = size;
        }

        public Ufo()
        {
            Position = new Point(0, 0);
            Size = 14;
        }

        public Ufo(int x, int y, int size)
        {
            Position = new Point(x, y);
            Size = size;
        }

        public int Size { get => _size; set => _size = value; }
    }
}
