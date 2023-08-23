using NUnit.Framework;
using Text;

namespace Text.Tests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void CamelCase_EmptyString_ReturnsZero()
        {
            int result = Str.CamelCase("");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CamelCase_MultipleCapitalLetters_ReturnsCorrectCount()
        {
            int result = Str.CamelCase("countWordsInThisString");
            Assert.AreEqual(5, result);
        }

        // Add more test cases as needed
    }
}
