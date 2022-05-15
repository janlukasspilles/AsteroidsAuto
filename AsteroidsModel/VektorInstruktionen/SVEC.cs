using System.Collections;

namespace AsteroidsModel.VektorInstruktionen
{
    public class SVEC : Vektorinstruktion
    {
        private int _helligkeit;
        private int _xs;
        private int _ys;
        private int _x;
        private int _y;
        private int _sf0;
        private int _sf1;
        private int _divisor;

        public int Helligkeit { get => _helligkeit; set => _helligkeit = value; }
        public int Xs { get => _xs; set => _xs = value; }
        public int Ys { get => _ys; set => _ys = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Sf0 { get => _sf0; set => _sf0 = value; }
        public int Sf1 { get => _sf1; set => _sf1 = value; }
        public int Divisor { get => _divisor; set => _divisor = value; }
        public SVEC(BitArray word, int gsf)
        {
            BitArray tmp = new BitArray(word);
            tmp.And(new BitArray(new bool[] { true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false }));
            tmp.LeftShift(8);
            int[] res = new int[1];
            tmp.CopyTo(res, 0);
            X = res[0];

            tmp = new BitArray(word);
            tmp.And(new BitArray(new bool[] { false, false, false, false, false, false, false, false, true, true, false, false, false, false, false, false }));            
            res = new int[1];
            tmp.CopyTo(res, 0);
            Y = res[0];

            Y = word.Get(10) ? Y * -1 : Y;
            X = word.Get(2) ? X * -1 : X;

            tmp = new BitArray(word);
            tmp.And(new BitArray(new bool[] { false, false, false, false, true, true, true, true, false, false, false, false, false, false, false, false }));
            tmp.RightShift(4);
            res = new int[1];
            tmp.CopyTo(res, 0);
            Helligkeit = res[0];

            int i = word.Get(11) ? 1 : 0;
            switch (gsf + i)
            {
                case 0:
                    Y = Y / 128;
                    break;
                case 1:
                    Y = Y / 64;
                    break;
                case 2:
                    Y = Y / 32;
                    break;
                case 3:
                    Y = Y / 16;
                    break;
            }
            i = word.Get(3) ? 1 : 0;
            switch (gsf + i)
            {
                case 0:
                    X = X / 128;
                    break;
                case 1:
                    X = X / 64;
                    break;
                case 2:
                    X = X / 32;
                    break;
                case 3:
                    X = X / 16;
                    break;
            }
        }
        public SVEC(byte b1, byte b2, int globalerSkalierungsfaktor) : base(b1, b2)
        {
            SetHelligkeit(b2);
            SetSf0(b1);
            SetSf1(b2);
            SetXs(b2);
            SetYs(b1);
            SetX(b2);
            SetY(b1);
        }
        private void SetHelligkeit(byte b1)
        {
            BitArray ba = new BitArray(new byte[] { b1 });
            ba.RightShift(4);
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            Helligkeit = res[0];
        }
        private void SetSf0(byte b1)
        {
            BitArray ba = new BitArray(new byte[] { b1 });
            Sf0 = ba.Get(4) ? -1 : 1;
        }
        private void SetSf1(byte b1)
        {
            BitArray ba = new BitArray(new byte[] { b1 });
            Sf1 = ba.Get(4) ? -1 : 1;
        }
        private void SetYs(byte b1)
        {
            BitArray ba = new BitArray(new byte[] { b1 });
            Ys = ba.Get(5) ? -1 : 1;
        }
        private void SetXs(byte b1)
        {
            BitArray ba = new BitArray(new byte[] { b1 });
            Xs = ba.Get(5) ? -1 : 1;
        }
        private void SetX(byte b1)
        {
            BitArray ba = new BitArray(new byte[] { b1 });
            BitArray bb = new BitArray(new bool[] { false, false, false, false, false, false, ba.Get(6), ba.Get(7), false, false, false, false, false, false, false, false });
            int[] res = new int[1];
            bb.CopyTo(res, 0);
            X = res[0];
        }
        private void SetY(byte b1)
        {
            BitArray ba = new BitArray(new byte[] { b1 });
            BitArray bb = new BitArray(new bool[] { false, false, false, false, false, false, ba.Get(6), ba.Get(7), false, false, false, false, false, false, false, false });
            int[] res = new int[1];
            bb.CopyTo(res, 0);
            Y = res[0];
        }
    }
}
