using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsControllers
{
    public static class BitArrayExtensions
    {
        public static BitArray ReverseByteweise(this BitArray array)
        {
            for (int i = 0; i < array.Length; i += 8)
            {
                for (int j = 0; j < 4; j++)
                {
                    bool bit = array[i + j];
                    array[i + j] = array[i + 8 - j - 1];
                    array[i + 8 - j - 1] = bit;
                }
            }
            return array;
        }

        public static BitArray Reverse(this BitArray array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool bit = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = bit;
            }
            return array;
        }

        public static string AsString(this BitArray array)
        {
            string res = "";
            for (int i = 0; i < array.Length; i++)
            {
                res += array.Get(i) ? "1" : "0";
            }
            return res;
        }

        //public static int GetIntValue(this BitArray array, int index, int length)
        //{
        //    BitArray tmp = new BitArray(array);

        //}
    }
}