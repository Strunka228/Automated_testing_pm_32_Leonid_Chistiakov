using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnalaizerClassLibrary;

namespace AnalaizerClassLibrary.Tests
{
    [TestClass]
    public class AnalaizerClassTests
    {
        [TestMethod]
        public void InsertSymbol_AddSymbolAtPosition_ReturnsCorrectString()
        {
            // Arrange
            string input = "12345";
            char symbol = 'X';
            int position = 2;
            string expected = "12X45";

            // Act
            string result = AnalaizerClass.InsertSymbol(input, symbol, position);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsOperator_ValidOperator_ReturnsTrue()
        {
            // Arrange
            string input = "+";

            // Act
            bool result = AnalaizerClass.IsOperator(input);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOperator_InvalidOperator_ReturnsFalse()
        {
            // Arrange
            string input = "A";

            // Act
            bool result = AnalaizerClass.IsOperator(input);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
