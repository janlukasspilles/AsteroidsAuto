using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel
{
    public enum Befehl
    {
        Pause = 0x40,
        Linksdrehen = 0x50,
        Rechtsdrehen = 0x48,
        Schuss = 0x42,
        Schub = 0x44,
        Hyperspace = 0x41
    }
}
