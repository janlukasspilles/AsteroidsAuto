using AsteroidsControllers;
using System;
using System.Collections;

namespace AsteroidsModel.VektorInstruktionen
{
    public class VCTR : Vektorinstruktion
    {
        private int _helligkeit;
        private int _x;
        private int _y;
        private int _divisor;

        public int Helligkeit { get => _helligkeit; set => _helligkeit = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Divisor { get => _divisor; set => _divisor = value; }

        public VCTR(BitArray b1, BitArray b2, int gsf)
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
            Helligkeit = res[0];

            tmp = new BitArray(b1);
            tmp.RightShift(12);
            res = new int[1];
            tmp.CopyTo(res, 0);
            Opcode = res[0];

            Y = b1.Get(10) ? Y * -1 : Y;
            X = b2.Get(10) ? X * -1 : X;

            switch (Opcode + gsf)
            {
                case 0:
                    Y = Y / 512;
                    X = X / 512;
                    break;

                case 1:
                    Y = Y / 256;
                    X = X / 256;
                    break;

                case 2:
                    Y = Y / 128;
                    X = X / 128;
                    break;

                case 3:
                    Y = Y / 64;
                    X = X / 64;
                    break;

                case 4:
                    Y = Y / 32;
                    X = X / 32;
                    break;

                case 5:
                    Y = Y / 16;
                    X = X / 16;
                    break;

                case 6:
                    Y = Y / 8;
                    X = X / 8;
                    break;

                case 7:
                    Y = Y / 4;
                    X = X / 4;
                    break;

                case 8:
                    Y = Y / 2;
                    X = X / 2;
                    break;

                case 9:
                    Y = Y / 1;
                    X = X / 1;
                    break;
            }
        }

        public bool IsShot()
        {
            return X == 0 && Y == 0 && Helligkeit == 15;
        }

        public bool IsShip()
        {
            return Opcode == 6 && Helligkeit == 12 && X != 0 && Y != 0;
        }
    }
}