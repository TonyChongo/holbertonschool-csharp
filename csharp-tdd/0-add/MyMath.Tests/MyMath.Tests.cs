using MyMath;
using NUnit.Framework;

namespace MyMath.Tests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void TestAddition()
        {
            int result = Operations.Add(5, 7);
            Assert.AreEqual(12, result);
        }
    }
}
