using System.Numerics;

namespace LaboratoryWork3
{
    public class RationalNumber
    {
        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }

        public RationalNumber(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public static RationalNumber operator +(RationalNumber number1, RationalNumber number2)
        {
            var leastCommonMultiple = LeastCommonMultiple(number1.Denominator, number2.Denominator);
            var numerator = number1.Numerator * leastCommonMultiple / number1.Denominator
                            + number2.Numerator * leastCommonMultiple / number2.Denominator;
            return ReduceRationalNumber(new RationalNumber(numerator, leastCommonMultiple));
        }

        public static RationalNumber operator -(RationalNumber number1, RationalNumber number2)
        {
            var leastCommonMultiple = LeastCommonMultiple(number1.Denominator, number2.Denominator);
            var numerator = number1.Numerator * leastCommonMultiple / number1.Denominator
                            - number2.Numerator * leastCommonMultiple / number2.Denominator;
            return ReduceRationalNumber(new RationalNumber(numerator, leastCommonMultiple));
        }

        public static BigInteger LeastCommonMultiple(BigInteger number1, BigInteger number2)
            => number1 * number2 / BigInteger.GreatestCommonDivisor(number1, number2);

        public static RationalNumber ReduceRationalNumber(RationalNumber number)
        {
            var greatestCommonDivisor = BigInteger.GreatestCommonDivisor(number.Numerator, number.Denominator);
            return new RationalNumber(number.Numerator / greatestCommonDivisor, number.Denominator / greatestCommonDivisor);
        }
    }
}