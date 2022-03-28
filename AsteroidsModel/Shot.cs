using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel
{
    public class Shot : FieldObject
    {
        public Shot()
        {
            Position = new Point(0, 0);
        }
        public Shot(Point position)
        {
            Position = position;
        }
        public Shot(int x, int y)
        {
            Position = new Point(x, y);
        }
    }
}
