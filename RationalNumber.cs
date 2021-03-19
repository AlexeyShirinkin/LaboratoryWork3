using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LaboratoryWork3
{
    public class RationalNumber
    {
        public BigInteger Numerator { get; }
        public BigInteger Denominator { get; }

        public RationalNumber(BigInteger numerator, BigInteger denominator)
        {
            if (denominator.Sign == -1)
            {
                numerator = BigInteger.Negate(numerator);
                denominator = BigInteger.Negate(denominator);
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public static RationalNumber operator +(RationalNumber number1, RationalNumber number2)
        {
            var leastCommonMultiple = LeastCommonMultiple(number1.Denominator, number2.Denominator);
            var numerator = number1.Numerator * leastCommonMultiple / number1.Denominator
                            + number2.Numerator * leastCommonMultiple / number2.Denominator;
            return GetReducedRationalNumber(new RationalNumber(numerator, leastCommonMultiple));
        }

        public static RationalNumber operator -(RationalNumber number1, RationalNumber number2)
        {
            var leastCommonMultiple = LeastCommonMultiple(number1.Denominator, number2.Denominator);
            var numerator = number1.Numerator * leastCommonMultiple / number1.Denominator
                            - number2.Numerator * leastCommonMultiple / number2.Denominator;
            return GetReducedRationalNumber(new RationalNumber(numerator, leastCommonMultiple));
        }

        public static RationalNumber operator *(RationalNumber number1, RationalNumber number2)
        {
            return GetReducedRationalNumber(
                new RationalNumber(
                    number1.Numerator * number2.Numerator,
                    number1.Denominator * number2.Denominator));
        }

        public static RationalNumber operator /(RationalNumber number1, RationalNumber number2)
        {
            return GetReducedRationalNumber(
                new RationalNumber(
                    number1.Numerator * number2.Denominator,
                    number1.Denominator * number2.Numerator));
        }

        public static BigInteger LeastCommonMultiple(BigInteger number1, BigInteger number2)
            => number1 * number2 / BigInteger.GreatestCommonDivisor(number1, number2);

        public static RationalNumber GetReducedRationalNumber(RationalNumber number)
        {
            var greatestCommonDivisor = BigInteger.GreatestCommonDivisor(number.Numerator, number.Denominator);
            return new RationalNumber(number.Numerator / greatestCommonDivisor, number.Denominator / greatestCommonDivisor);
        }

        public static string GetPeriodicFraction(RationalNumber number)
        {
            var remainders = new Dictionary<BigInteger, int>();
            var resultDigits = new List<BigInteger>();
            var currentRemainder = number.Numerator % number.Denominator;

            while (true)
            {
                var temp = currentRemainder * 10;
                currentRemainder = temp % number.Denominator;
                resultDigits.Add(BigInteger.Abs(temp / number.Denominator));

                if (currentRemainder == 0)
                    break;

                if (remainders.ContainsKey(currentRemainder))
                {
                    if (resultDigits.Last() == resultDigits.First())
                        resultDigits.RemoveAt(resultDigits.Count - 1);
                    break;
                }
                remainders[currentRemainder] = resultDigits.Count;
            }

            var integerPart = $"{number.Numerator / number.Denominator}.";
            var periodicFraction = new StringBuilder(integerPart + string.Concat(resultDigits));

            if (currentRemainder == 0)
                return periodicFraction.ToString();

            var index = integerPart.Length + remainders[currentRemainder] - (remainders.Count == resultDigits.Count ? 1 : 0);
            return periodicFraction.Insert(index, '(').Append(")").ToString();
        }

        public static RationalNumber GetOrdinaryFraction(string number)
        {
            var sign = number[0] == '-' ? "-" : "+";
            var split = number.Split('.');
            if (split.Length == 1)
                return new RationalNumber(BigInteger.Parse(number), BigInteger.One);

            var digitsInFloatPart = split[1];
            split = digitsInFloatPart.Split('(');

            if (split.Length < 2)
                return GetReducedRationalNumber(new RationalNumber(
                    BigInteger.Parse(number.Replace(".", "")), 
                    BigInteger.Pow(10, digitsInFloatPart.Length)));

            var periodicPart = split[1].TrimEnd(')');
            var notPeriodicPart = split[0].Length > 0 ? split[0] : "";

            var numeratorValue = BigInteger.Parse(digitsInFloatPart.Replace("(", "").Replace(")", "")) -
                                 BigInteger.Parse(notPeriodicPart.Length > 0 ? notPeriodicPart : "0");
            var numerator = BigInteger.Parse(sign + numeratorValue);
            var denominator = BigInteger.Parse(
                string.Join("", Enumerable.Repeat(9, periodicPart.Length).Concat(Enumerable.Repeat(0, notPeriodicPart.Length))));

            return GetReducedRationalNumber(
                new RationalNumber(numerator + BigInteger.Parse(number.Split('.')[0]) * denominator, denominator));
        }
    }
}