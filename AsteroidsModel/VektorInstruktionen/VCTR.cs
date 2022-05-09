using System;
using System.Collections;

namespace AsteroidsModel.VektorInstruktionen
{
    public class VCTR : Vektorinstruktion
    {
        private int _helligkeit;
        private int _x;
        private int _y;
        private int _xs;
        private int _ys;
        private int _divisor;

        public int Helligkeit { get => _helligkeit; set => _helligkeit = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Xs { get => _xs; set => _xs = value; }
        public int Ys { get => _ys; set => _ys = value; }
        public int Divisor { get => _divisor; set => _divisor = value; }

        public VCTR(byte b1, byte b2, byte b3, byte b4, int globalerSkalierungsfaktor) : base(b1, b2)
        {
            SetXs(b3);
            SetYs(b1);
            SetHelligkeit(b3, b4);
            SetX(b3, b4);
            SetY(b1, b2);
            SetDivisor(globalerSkalierungsfaktor);
        }
        public void SetXs(byte b)
        {
            BitArray ba = new BitArray(new byte[] { b });
            Xs = ba.Get(5) ? -1 : 1;
        }
        public void SetYs(byte b)
        {
            BitArray ba = new BitArray(new byte[] { b });
            Ys = ba.Get(5) ? -1 : 1;
        }
        public void SetHelligkeit(byte b1, byte b2)
        {
            BitArray ba = new BitArray(new byte[] { b1, b2 });
            //Shift 12 nach rechts, um ersten 4 Bits zu erhalten
            ba.RightShift(12);
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            Helligkeit = res[0];
        }
        public void SetX(byte b1, byte b2)
        {
            BitArray ba = new BitArray(new byte[] { b1, b2 });
            //Und mit 0000 0011 1111 1111, um nur die letzten 12 Stelle
            ba.And(new BitArray(new byte[] { 0, 3, 15, 15 }));
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            X = res[0];
        }
        public void SetY(byte b1, byte b2)
        {
            BitArray ba = new BitArray(new byte[] { b1, b2 });
            //Und mit 0000 0011 1111 1111, um nur die letzten 12 Stelle
            ba.And(new BitArray(new byte[] { 0, 3, 15, 15 }));
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            Y = res[0];
        }
        public void SetDivisor(int globalerSkalierungsfaktor)
        {
            int sum = Opcode + globalerSkalierungsfaktor;
            Divisor = Convert.ToInt32(Math.Pow(2, Math.Abs(sum - 9)));
        }
    }
}
