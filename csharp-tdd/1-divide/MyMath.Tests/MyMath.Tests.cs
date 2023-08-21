using NUnit.Framework;
using MyMath; // Make sure to adjust the namespace if necessary

namespace MyMathTests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void Divide_ValidInput_ReturnsDividedMatrix()
        {
            // Arrange
            int[,] inputMatrix = {
                { 10, 20 },
                { 30, 40 }
            };
            int num = 2;
            int[,] expectedOutput = {
                { 5, 10 },
                { 15, 20 }
            };

            // Act
            int[,] result = Matrix.Divide(inputMatrix, num);

            // Assert
            Assert.That(result, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void Divide_NullMatrix_ReturnsNull()
        {
            // Arrange
            int[,] inputMatrix = null;
            int num = 2;

            // Act
            int[,] result = Matrix.Divide(inputMatrix, num);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Divide_DivideByZero_ReturnsNull()
        {
            // Arrange
            int[,] inputMatrix = {
                { 10, 20 },
                { 30, 40 }
            };
            int num = 0;

            // Act
            int[,] result = Matrix.Divide(inputMatrix, num);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
