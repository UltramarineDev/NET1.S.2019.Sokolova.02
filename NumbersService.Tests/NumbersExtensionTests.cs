using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace NumbersService.Tests
{
    public class NumbersExtensionTests
    {
        [TestCaseSource("TestCases")]
        public int InsertNumberTests(int numberSource, int numberin, int i, int j)
        => NumbersExtension.InsertNumber(numberSource, numberin, i, j);

        public static List <TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();
     
                using (var sourceFile = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Source.txt")))
                using (var streamReader = new StreamReader(sourceFile))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = streamReader.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ' ' });
                            int numberSource = Convert.ToInt32(split[0]);
                            int numberin = Convert.ToInt32(split[1]);
                            int i = Convert.ToInt32(split[2]);
                            int j = Convert.ToInt32(split[3]);
                            int expected = Convert.ToInt32(split[4]);

                            var testCase = new TestCaseData(numberSource, numberin, i, j).Returns(expected);
                            testCases.Add(testCase);
                        }
                    }
                }
                return testCases;
            }
        }
        [Test]
        public void InsertNumberMethod_InvalidValues_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NumbersExtension.InsertNumber(0, 7, 9, 6));
            Assert.Throws<ArgumentException>(() => NumbersExtension.InsertNumber(6, 9, 32, 33));
        }

    }
}
