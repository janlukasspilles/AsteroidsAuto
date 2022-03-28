using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel
{
    public class SpaceShip : FieldObject
    {
        private Point _direction;

        public SpaceShip(Point position, Point direction)
        {
            Position = position;
            Direction = direction;
        }
        public SpaceShip()
        {
            Position = new Point(0, 0);
            Direction = new Point(0, 0);
        }
        public Point Direction { get => _direction; set => _direction = value; }
    }
}
