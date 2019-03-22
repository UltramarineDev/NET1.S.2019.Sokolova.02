using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array));
            }

            int maxElement = array[array.Length - 1];
            int index = array.Length - 1;      
            return FindMaxElementHelp(maxElement, array, index);
        }

        private static int FindMaxElementHelp(int maxElement, int[] array, int index)
        {
            if (index < 1)
            {
                return maxElement;
            }

            if (maxElement < array[index - 1])
            {
                maxElement = array[index - 1];  
            }    
            
            return FindMaxElementHelp(maxElement, array, index - 1);         
        }
    }
}
