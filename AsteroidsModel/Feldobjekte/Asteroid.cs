using System;
using System.Drawing;

namespace AsteroidsModel
{
    public class Asteroid : FieldObject
    {
        private int _type;
        private int _scaleFactor;

        public int Type { get => _type; set => _type = value; }
        public int ScaleFactor { get => _scaleFactor; set => _scaleFactor = value; }
        public Asteroid()
        {
            Position = new Point(0, 0);
            Type = 0;
            ScaleFactor = 0;
        }
        public Asteroid(Point position, int type, int scaleFactor)
        {
            Position = position;
            Type = type;
            ScaleFactor = scaleFactor;
        }
        public Asteroid(int x, int y, int type, int scaleFactore)
        {
            Position = new Point(x, y);
            Type = type;
            ScaleFactor = scaleFactore;
        }
    }
}
