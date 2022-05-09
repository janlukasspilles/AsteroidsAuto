using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel
{
    public abstract class FieldObject
    {
        private Point _position;

        public Point Position { get => _position; set => _position = value; }
    }
}
