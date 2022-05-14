using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel.VektorInstruktionen
{
    public abstract class Vektorinstruktion
    {
        private int _opcode;
        public int Opcode { get => _opcode; set => _opcode = value; }

        public Vektorinstruktion()
        {

        }
        public Vektorinstruktion(byte b1, byte b2)
        {
            SetOpcode(b1, b2);
        }
        private void SetOpcode(byte b1, byte b2)
        {
            BitArray ba = new BitArray(new byte[] { b1, b2 });
            //Shift 12 nach rechts, um ersten 4 Bits zu erhalten
            ba.RightShift(12);
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            Opcode = res[0];
        }
    }
}
