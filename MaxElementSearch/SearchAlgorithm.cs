using System;

namespace MaxElementSearch
{
    /// <summary>
    /// Search Algorithm class
    /// </summary>
    public static class SearchAlgorithm
    {
        /// <summary>
        /// Method finds maximum element in array of integers using recursive search algorithm.
        /// </summary>
        /// <param name="array">source array of integers</param>
        /// <returns>maximum value</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the input array is epmty.</exception>
        public static int FindMaxElement(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Source array can not be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Source array can not be empty.", nameof(array));
            }

            return FindMaxElementHelp(array);
        }

        private static int FindMaxElementHelp(int[] array, int index = 0)
        {
            if (index == array.Length)
            {
                return array[0];
            }  
            
            return Math.Max(array[index], FindMaxElementHelp(array, index + 1));         
        }
    }
}
