using System;
using System.Collections;

namespace NumbersService
{
    /// <summary>
    /// Class for manipulations with numbers
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>
        /// Method the first (j - i + 1) bits of the second number into the first 
        /// so that the bits of the second number occupy positions from bit i to bit j.
        /// </summary>
        /// <param name="numberSource">first source number</param>
        /// <param name="numberin">second number</param>
        /// <param name="i">position bit i</param>
        /// <param name="j">position bit j</param>
        /// <returns>integer number</returns>
        public static int InsertNumber(int numberSource, int numberin, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException("Invalid input values: first bit position should be less or equal second.");
            }

            if (i < 0 || i >= 32 || j < 0 || j >= 32)
            {
                throw new ArgumentException("Values of bit position should be in the range of 0 to 31");
            }

            byte[] numberSourceArray = BitConverter.GetBytes(numberSource);
            BitArray numberSourceArrayOfBit = new BitArray(numberSourceArray);

            byte[] numberinArray = BitConverter.GetBytes(numberin);
            BitArray numberinArrayOfBit = new BitArray(numberinArray);

            for (int k = i, l = 0; k <= j; k++, l++)
            {
                numberSourceArrayOfBit.Set(k, numberinArrayOfBit.Get(l));
            }

            byte[] arrayForConvert = new byte[4];
            numberSourceArrayOfBit.CopyTo(arrayForConvert, 0);
            return arrayForConvert[0];
        }
    }
}
