using AsteroidsModel.VektorInstruktionen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel
{
    public class VektorReader
    {
        public VektorReader(byte[] bild)
        {
            Read(bild);
        }

        private void Read(byte[] bild)
        {
            Queue<Vektorinstruktion> q = new();
            int gsf = 0;
            for (int i = 0; i < bild.Length - 2; i += 2)
            {
                switch (GetOperation(bild[i]))
                {
                    case Operation.VCTR:
                        //q.Enqueue(new VCTR(bild[i], bild[i + 1], bild[i + 2], bild[i + 3], gsf));
                        i += 2;
                        break;

                    case Operation.LABS:
                        var l = new LABS(bild[i], bild[i + 1], bild[i + 2], bild[i + 3]);
                        q.Enqueue(l);
                        i += 2;
                        gsf = l.GlobalerSkalierungsFaktor;
                        break;

                    case Operation.HALT:
                        break;

                    case Operation.JSRL:
                        break;

                    case Operation.RTSL:
                        break;

                    case Operation.JMPL:
                        break;

                    case Operation.SVEC:
                        q.Enqueue(new SVEC(bild[i], bild[i + 1], gsf));
                        break;
                }
            }
        }

        private Operation GetOperation(byte b1)
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