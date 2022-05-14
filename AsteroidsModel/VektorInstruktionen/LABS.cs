using AsteroidsControllers;
using System;
using System.Collections;

namespace AsteroidsModel.VektorInstruktionen
{
    public class LABS : Vektorinstruktion
    {
        private int _x;
        private int _y;
        private int globalerSkalierungsFaktor;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int GlobalerSkalierungsFaktor { get => globalerSkalierungsFaktor; set => globalerSkalierungsFaktor = value; }

        public LABS(BitArray b1, BitArray b2)
        {
            Console.WriteLine(b1.AsString());
            int[] res = new int[1];
            b1.CopyTo(res, 0);
            var tmp = 0b1001;
        }

        public LABS(byte b1, byte b2, byte b3, byte b4) : base(b1, b2)
        {
            SetX(b3, b4);
            SetY(b1, b2);
            SetGlobalerSkalierungsfaktor(b3, b4);
        }
        private void SetX(byte b1, byte b2)
        {
            BitArray ba = new BitArray(new byte[] { b1, b2 });
            ba.And(new BitArray(new byte[] { 0, 3, 15, 15 }));
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            X = res[0];
        }
        private void SetY(byte b1, byte b2)
        {
            BitArray ba = new BitArray(new byte[] { b1, b2 });
            ba.And(new BitArray(new byte[] { 0, 3, 15, 15 }));
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            X = res[0];
        }
        private void SetGlobalerSkalierungsfaktor(byte b1, byte b2)
        {
            BitArray ba = new BitArray(new byte[] { b1, b2 });
            //Shift 12 nach rechts, um ersten 4 Bits zu erhalten
            ba.RightShift(12);
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            GlobalerSkalierungsFaktor = res[0];
        }
    }
}
