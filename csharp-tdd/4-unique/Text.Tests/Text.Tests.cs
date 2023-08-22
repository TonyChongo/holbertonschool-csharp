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
            Assert.AreEqual(0, Str.UniqueChar("leetcode"));
            Assert.AreEqual(2, Str.UniqueChar("loveleetcode"));
            Assert.AreEqual(-1, Str.UniqueChar("aabbcc"));
        }

        [Test]
        public void TestUniqueChar_EmptyString()
        {
            Assert.AreEqual(-1, Str.UniqueChar(""));
        }
    }
}