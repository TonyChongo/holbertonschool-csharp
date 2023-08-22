using NUnit.Framework;
using Text;

namespace TextTests
{
    [TestFixture]
    public class StrTests
    {
        [TestCase("Racecar", ExpectedResult = true)]
        [TestCase("level", ExpectedResult = true)]
        [TestCase("A man, a plan, a canal: Panama.", ExpectedResult = true)]
        [TestCase("hello", ExpectedResult = false)]
        [TestCase("", ExpectedResult = true)]
        [TestCase("Was it a car or a cat I saw?", ExpectedResult = true)]
        public bool IsPalindrome_ValidInput_ReturnsExpectedResult(string input)
        {
            return Str.IsPalindrome(input);
        }
    }
}
