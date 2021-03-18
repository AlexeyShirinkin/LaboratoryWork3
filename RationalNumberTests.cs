using System.Numerics;
using NUnit.Framework;

namespace LaboratoryWork3
{
    internal class RationalNumberTests
    {
        [TestCase("4", "18", "2", "12", "7", "18", TestName = "WhenSmallNumbers")]
        [TestCase("-4", "18", "-8", "12", "-8", "9", TestName = "WhenNegativeNumbersNumbers")]
        [TestCase("4", "18", "-8", "12", "-4", "9", TestName = "WhenNegativeAndPositiveNumbersNumbers")]
        [TestCase("2251954", "56591152", "6519851", "12651515", "198728254384331", "357981904197640", TestName = "WhenBigNumbers")]
        public void CorrectAddition(string numerator1, string denominator1,
            string numerator2, string denominator2,
            string expectedNumerator, string expectedDenominator)
        {
            var number1 = new RationalNumber(BigInteger.Parse(numerator1), BigInteger.Parse(denominator1));
            var number2 = new RationalNumber(BigInteger.Parse(numerator2), BigInteger.Parse(denominator2));

            var actualNumber = number1 + number2;

            Assert.AreEqual(BigInteger.Parse(expectedNumerator), actualNumber.Numerator);
            Assert.AreEqual(BigInteger.Parse(expectedDenominator), actualNumber.Denominator);
        }

        [TestCase("4", "18", "2", "12", "1", "18", TestName = "WhenSmallNumbers")]
        [TestCase("-4", "18", "-8", "12", "4", "9", TestName = "WhenNegativeNumbersNumbers")]
        [TestCase("4", "18", "-8", "12", "8", "9", TestName = "WhenNegativeAndPositiveNumbersNumbers")]
        [TestCase("2251954", "56591152", "6519851", "12651515", "-170237624574021", "357981904197640", TestName = "WhenBigNumbers")]
        public void CorrectSubtraction(string numerator1, string denominator1,
            string numerator2, string denominator2,
            string expectedNumerator, string expectedDenominator)
        {
            var number1 = new RationalNumber(BigInteger.Parse(numerator1), BigInteger.Parse(denominator1));
            var number2 = new RationalNumber(BigInteger.Parse(numerator2), BigInteger.Parse(denominator2));

            var actualNumber = number1 - number2;

            Assert.AreEqual(BigInteger.Parse(expectedNumerator), actualNumber.Numerator);
            Assert.AreEqual(BigInteger.Parse(expectedDenominator), actualNumber.Denominator);
        }
    }
}