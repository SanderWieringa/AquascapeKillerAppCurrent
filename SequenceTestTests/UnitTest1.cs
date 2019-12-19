using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SequenceTestTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<int> sequenceOne = new List<int>
            {
                1,
                3,
                5
            };
            List<int> sequenceTwo = new List<int>
            {
                1,
                3,
                5
            };

            bool equal = sequenceOne.SequenceEqual(sequenceTwo);

            Assert.IsTrue(equal);
        }
    }
}
