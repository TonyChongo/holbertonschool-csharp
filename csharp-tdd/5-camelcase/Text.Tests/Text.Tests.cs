using NUnit.Framework;

namespace Text.Tests
{
    [TestFixture]
    public class StrTests
    {
        [Test]
        public void CamelCase_EmptyString_ReturnZero()
        {
            // Arrange
            string s = "";
            // Act
            int wordcount = Str.CamelCase(s);
            // Assert
            Assert.AreEqual(wordcount, 0);
        }

        [Test]
        public void CamelCase_OneWord_ReturnsOne()
        {
            // Arrange
            string s = "hello";
            // Act
            int wordcount = Str.CamelCase(s);
            // Assert
            Assert.AreEqual(wordcount, 1);
        }

        [Test]
        public void CamelCase_TwoWords_ReturnsTwo()
        {
            // Arrange
            string s = "helloTony";
            // Act
            int wordcount = Str.CamelCase(s);
            // Assert
            Assert.AreEqual(wordcount, 2);
        }
    }
}