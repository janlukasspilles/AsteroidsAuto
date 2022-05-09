using AsteroidsControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidsPlayerUI
{
    public partial class Form1 : Form
    {
        private AsteroidsController _asteroidsController;
        public Form1()
        {
            InitializeComponent();
            _asteroidsController = new AsteroidsController(1979, "127.0.0.1");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            _asteroidsController.SendToServer(AsteroidsModel.Befehl.Linksdrehen);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            _asteroidsController.SendToServer(AsteroidsModel.Befehl.Rechtsdrehen);
        }

        private void btnSchub_Click(object sender, EventArgs e)
        {
            _asteroidsController.SendToServer(AsteroidsModel.Befehl.Schub);
        }

        private void btnShot_Click(object sender, EventArgs e)
        {
            _asteroidsController.SendToServer(AsteroidsModel.Befehl.Schuss);
        }

        private void btnHyperspace_Click(object sender, EventArgs e)
        {
            _asteroidsController.SendToServer(AsteroidsModel.Befehl.Hyperspace);
        }
    }
}
