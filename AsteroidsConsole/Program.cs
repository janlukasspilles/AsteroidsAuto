using AsteroidsControllers;
using AsteroidsModel;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AsteroidsController ac = new(1979, "127.0.0.1");
            ac.Start();
        }
        static Operation GetBefehl(byte b1)
        {
            //Ersten 4 Bits holen. Dazu Shift nach rechts um 4, dadurch wird vorne mit 0 aufgefüllt.
            int intVal = b1 >> 4;
            if (intVal >= 0 && intVal <= 9)
                return Operation.VCTR;
            else if (intVal == 10)
                return Operation.LABS;
            else if (intVal == 11)
                return Operation.HALT;
            else if (intVal == 12)
                return Operation.JSRL;
            else if (intVal == 13)
                return Operation.RTSL;
            else if (intVal == 14)
                return Operation.JMPL;
            else if (intVal == 15)
                return Operation.SVEC;
            else
                throw new ArgumentException($"Ungültige Operation {intVal:X}");
        }
    }
}
