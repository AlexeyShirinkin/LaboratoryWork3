using System.Numerics;
using NUnit.Framework;

namespace LaboratoryWork3
{
    internal class RationalNumberTests
    {
        [TestCase("4", "18", "2", "12", "7", "18", TestName = "WhenSmallNumbers")]
        [TestCase("-4", "18", "-8", "12", "-8", "9", TestName = "WhenNegativeNumbers")]
        [TestCase("4", "18", "-8", "12", "-4", "9", TestName = "WhenNegativeAndPositiveNumber")]
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
        [TestCase("-4", "18", "-8", "12", "4", "9", TestName = "WhenNegativeNumbers")]
        [TestCase("4", "18", "-8", "12", "8", "9", TestName = "WhenNegativeAndPositiveNumbers")]
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

        [TestCase("4", "18", "2", "12", "1", "27", TestName = "WhenSmallNumbers")]
        [TestCase("-4", "18", "-8", "12", "4", "27", TestName = "WhenNegativeNumbers")]
        [TestCase("4", "18", "-8", "12", "-4", "27", TestName = "WhenNegativeAndPositiveNumbers")]
        [TestCase("2251954", "56591152", "6519851", "12651515", "7341202269427", "357981904197640", TestName = "WhenBigNumbers")]
        public void CorrectMultiplication(string numerator1, string denominator1,
            string numerator2, string denominator2,
            string expectedNumerator, string expectedDenominator)
        {
            var number1 = new RationalNumber(BigInteger.Parse(numerator1), BigInteger.Parse(denominator1));
            var number2 = new RationalNumber(BigInteger.Parse(numerator2), BigInteger.Parse(denominator2));

            var actualNumber = number1 * number2;

            Assert.AreEqual(BigInteger.Parse(expectedNumerator), actualNumber.Numerator);
            Assert.AreEqual(BigInteger.Parse(expectedDenominator), actualNumber.Denominator);
        }

        [TestCase("4", "18", "2", "12", "4", "3", TestName = "WhenSmallNumbers")]
        [TestCase("-4", "18", "-8", "12", "1", "3", TestName = "WhenNegativeNumbers")]
        [TestCase("4", "18", "-8", "12", "-1", "3", TestName = "WhenNegativeAndPositiveNumbers")]
        [TestCase("2251954", "56591152", "6519851", "12651515", "14245314905155", "184482939479176", TestName = "WhenBigNumbers")]
        public void CorrectDivision(string numerator1, string denominator1,
            string numerator2, string denominator2,
            string expectedNumerator, string expectedDenominator)
        {
            var number1 = new RationalNumber(BigInteger.Parse(numerator1), BigInteger.Parse(denominator1));
            var number2 = new RationalNumber(BigInteger.Parse(numerator2), BigInteger.Parse(denominator2));

            var actualNumber = number1 / number2;

            Assert.AreEqual(BigInteger.Parse(expectedNumerator), actualNumber.Numerator);
            Assert.AreEqual(BigInteger.Parse(expectedDenominator), actualNumber.Denominator);
        }
    }
}