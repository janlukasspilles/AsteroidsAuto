﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsControllers
{
    public static class BitArrayExtensions
    {
        public static BitArray Reverse(this BitArray array)
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
    }
}