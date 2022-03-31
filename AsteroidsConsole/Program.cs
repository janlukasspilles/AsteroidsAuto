using AsteroidsModel;
using System;
using System.Net.Sockets;

namespace AsteroidsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UdpClient client = new UdpClient("127.0.0.1", 1979))
            {
                byte[] bytes = client.ReceiveAsync().Result.Buffer;

            }
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
