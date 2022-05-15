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
            BitArray tmp = new BitArray(b1);
            tmp.And(new BitArray(new bool[] { true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false }));
            int[] res = new int[1];
            tmp.CopyTo(res, 0);
            Y = res[0];

            tmp = new BitArray(b2);
            tmp.And(new BitArray(new bool[] { true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false }));
            res = new int[1];
            tmp.CopyTo(res, 0);
            X = res[0];

            tmp = new BitArray(b2);
            tmp.RightShift(12);
            res = new int[1];
            tmp.CopyTo(res, 0);
            GlobalerSkalierungsFaktor = res[0];
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