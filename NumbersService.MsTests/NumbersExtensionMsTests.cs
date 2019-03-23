using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumbersService.MsTests
{
    [TestClass]
    public class NumbersExtensionMsTests
    {
        public TestContext TestContext { get; set; }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","Source.xml", "Number", DataAccessMethod.Sequential)]
        [TestMethod]
        public void InsertNumberTests()
        {
            string numberSource = TestContext.DataRow["numberSource"].ToString();
            string numberin = TestContext.DataRow["numberin"].ToString();
            string i = TestContext.DataRow["i"].ToString();
            string j = TestContext.DataRow["j"].ToString();
            string expected = TestContext.DataRow["resultNumber"].ToString();

            int actualResult = NumbersExtension.InsertNumber(int.Parse(numberSource), int.Parse(numberin), int.Parse(i), int.Parse(j));
            Assert.AreEqual(expected, actualResult.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberMethod_InvalidValues_ThrowArgumentException()
        {
            NumbersExtension.InsertNumber(0, 7, 9, 6);
            NumbersExtension.InsertNumber(6,9,32,33);
        }
    }
}
