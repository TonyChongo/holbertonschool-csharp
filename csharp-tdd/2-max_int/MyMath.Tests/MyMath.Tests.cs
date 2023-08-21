using System;
using System.Collections.Generic;
using NUnit.Framework;
using MyMath;

namespace MyMathTests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Max_EmptyList_ReturnsZero()
        {
            List<int> emptyList = new List<int>();
            int result = Operations.Max(emptyList);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Max_ListWithPositiveNumbers_ReturnsMax()
        {
            List<int> numbers = new List<int> { 10, 5, 8, 20, 3 };
            int result = Operations.Max(numbers);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Max_ListWithNegativeNumbers_ReturnsMax()
        {
            List<int> numbers = new List<int> { -10, -5, -8, -20, -3 };
            int result = Operations.Max(numbers);
            Assert.AreEqual(-3, result);
        }

        [Test]
        public void Max_ListWithSingleElement_ReturnsElement()
        {
            List<int> numbers = new List<int> { 42 };
            int result = Operations.Max(numbers);
            Assert.AreEqual(42, result);
        }
    }
}
