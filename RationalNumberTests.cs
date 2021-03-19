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

        [TestCase("4", "18", "0.(2)", TestName = "WhenSmallNumbers")]
        [TestCase("-4444", "984", "-4.5(16260)", TestName = "WhenNegativeNumbers")]
        [TestCase("9", "4", "2.25", TestName = "WhenNotPeriodicFraction")]
        [TestCase("225", "565",
            "0.(3982300884955752212389380530973451327433628318584070796460176991150442477876106194690265486725663716814159292035)",
            TestName = "WhenBigPeriodicFraction")]
        public void CorrectPeriodicFraction(string numerator, string denominator, string expectedFraction)
        {
            var number = new RationalNumber(BigInteger.Parse(numerator), BigInteger.Parse(denominator));

            var actualNumber = RationalNumber.GetPeriodicFraction(number);

            Assert.AreEqual(expectedFraction, actualNumber);
        }

        [TestCase("4", "4", "1", TestName = "WhenNoFloatPart")]
        [TestCase("0.(3)", "1", "3", TestName = "WhenSmallPeriodicPart")]
        [TestCase("-4.5(16260)", "-1111", "246", TestName = "WhenNegativeNumber")]
        [TestCase("-4.5", "-9", "2", TestName = "WhenNoPeriodicPart")]
        [TestCase("0.(3982300884955752212389380530973451327433628318584070796460176991150442477876106194690265486725663716814159292035)",
            "45", "113",
            TestName = "WhenBigPeriodicFraction")]
        public void CorrectOrdinaryFraction(string number, string expectedNumerator, string expectedDenominator)
        {
            var actualNumber = RationalNumber.GetOrdinaryFraction(number);

            Assert.AreEqual(BigInteger.Parse(expectedNumerator), actualNumber.Numerator);
            Assert.AreEqual(BigInteger.Parse(expectedDenominator), actualNumber.Denominator);
        }
    }
}