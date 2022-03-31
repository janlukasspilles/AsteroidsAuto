using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsModel.VektorInstruktions
{
    public class Vektor
    {
        private byte _b1;
        private byte _b2;
        private byte _b3;
        private byte _b4;
        public byte B1 { get => _b1; set => _b1 = value; }
        public byte B2 { get => _b2; set => _b2 = value; }
        public byte B3 { get => _b3; set => _b3 = value; }
        public byte B4 { get => _b4; set => _b4 = value; }
        public Vektor(byte b1, byte b2, byte b3, byte b4)
        {
            B1 = b1;
            B2 = b2;
            B3 = b3;
            B4 = b4;
        }
        public int GetXs()
        {
            BitArray ba = new BitArray(new byte[] { B3 });
            if (ba.Get(5))
                return -1;
            else
                return 1;
        }
        public int GetYs()
        {
            BitArray ba = new BitArray(new byte[] { B1 });
            if (ba.Get(5))
                return -1;
            else
                return 1;
        }
        public int GetHelligkeit()
        {
            BitArray ba = new BitArray(new byte[] { B3, B4 });
            //Shift 12 nach rechts, um ersten 4 Bits zu erhalten
            ba.RightShift(12);
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            return res[0];
        }
        public int GetX()
        {
            BitArray ba = new BitArray(new byte[] { B3, B4 });
            //Und mit 0000 0011 1111 1111, um nur die letzten 12 Stelle
            ba.And(new BitArray(new byte[] { 0, 3, 15, 15 }));
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            return res[0];
        }
        public int GetY()
        {
            BitArray ba = new BitArray(new byte[] { B1, B2 });
            //Und mit 0000 0011 1111 1111, um nur die letzten 12 Stelle
            ba.And(new BitArray(new byte[] { 0, 3, 15, 15 }));
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            return res[0];
        }
        public int GetOpCode()
        {
            BitArray ba = new BitArray(new byte[] { B1, B2 });
            //Shift 12 nach rechts, um ersten 4 Bits zu erhalten
            ba.RightShift(12);
            int[] res = new int[1];
            ba.CopyTo(res, 0);
            return res[0];
        }
        public int GetDivisor(int globalerSkalierungsfaktor)
        {
            int sum = GetOpCode() + globalerSkalierungsfaktor;
            return Convert.ToInt32(Math.Pow(2, Math.Abs(sum - 9)));
        }
    }
}
