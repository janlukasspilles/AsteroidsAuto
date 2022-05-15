using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel
{
    public class GameField
    {
        private List<Asteroid> _asteroids;
        private List<Shot> _shots;
        private Ufo _ufo;
        private SpaceShip _spaceShip;

        public List<Asteroid> Asteroids { get => _asteroids; set => _asteroids = value; }
        public List<Shot> Shots { get => _shots; set => _shots = value; }
        public Ufo Ufo { get => _ufo; set => _ufo = value; }
        public SpaceShip SpaceShip { get => _spaceShip; set => _spaceShip = value; }

        public GameField()
        {
            Asteroids = new List<Asteroid>();
            Shots = new List<Shot>();
            Ufo = null;
            SpaceShip = null;
        }
    }
}