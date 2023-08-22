using NUnit.Framework;
using Text;

namespace TextTests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void TestUniqueChar()
        {
            // Test cases
            Assert.AreEqual(0, Str.UniqueChar("leetcode"));
            Assert.AreEqual(-1, Str.UniqueChar("aabbccdd"));

            // Edge case: empty string
            Assert.AreEqual(-1, Str.UniqueChar(""));

            // Edge case: single character string
            Assert.AreEqual(0, Str.UniqueChar("a"));
        }
    }
}
