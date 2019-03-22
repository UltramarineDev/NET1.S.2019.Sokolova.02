using System;
using NUnit.Framework;

namespace MaxElementSearch.Tests
{
    public class SearchAlgoritmTests
    {
        [TestCase(new int[] { 0, int.MaxValue, 80, 890000, 12, 0, 64 }, ExpectedResult = int.MaxValue)]
        [TestCase(new int[] { 65, 3, 1, 7, 432, 7563, 55, -431, -78, 0 }, ExpectedResult = 7563)]
        [TestCase(new int[] { -1000, -567, int.MinValue, -98, -6, -67, -67 }, ExpectedResult = -6)]
        [TestCase(new int[] { 9, 9, 9, 9, 9, 9, 9 }, ExpectedResult = 9)]
        public int FindMaxElementTests(int[] array)
            => SearchAlgorithm.FindMaxElement(array);

        [Test]
        public void FindMaxElement_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => SearchAlgorithm.FindMaxElement(new int[] { }), message: "Source array can not be empty");
        }

        [Test]
        public void FindMaxElement_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => SearchAlgorithm.FindMaxElement(null), message: "Source array can not be null");
        }
    }
}
