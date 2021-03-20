using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml;

namespace LaboratoryWork3
{
    internal class Program
    {
        internal static void Main()
        {
            var xDoc = new XmlDocument();
            xDoc.Load("Data.xml");
            var xmlRoot = xDoc.DocumentElement;

            var periodicFraction = string.Empty;
            var rationalNumbers = new List<RationalNumber>();

            foreach (XmlNode xmlNode in xmlRoot)
            {
                var numerator = new BigInteger();
                var denominator = new BigInteger();
                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    if (childNode.Name == "numerator")
                        numerator = BigInteger.Parse(childNode.InnerText);
                    if (childNode.Name == "denominator")
                        denominator = BigInteger.Parse(childNode.InnerText);
                    if (childNode.Name == "periodic")
                        periodicFraction = childNode.InnerText;
                }
                rationalNumbers.Add(new RationalNumber(numerator, denominator));
            }

            foreach (var number in rationalNumbers.Take(2))
            {
                Console.WriteLine(number.Numerator + "/" + number.Denominator);
                Console.WriteLine(RationalNumber.GetPeriodicFraction(number));
                Console.WriteLine();
            }

            var addition = rationalNumbers[0] + rationalNumbers[1];
            Console.WriteLine("Addition: " + addition.Numerator + "/" + addition.Denominator);
            Console.WriteLine(RationalNumber.GetPeriodicFraction(addition) + "\n");

            var subtraction = rationalNumbers[0] - rationalNumbers[1];
            Console.WriteLine("Subtraction: " + subtraction.Numerator + "/" + subtraction.Denominator);
            Console.WriteLine(RationalNumber.GetPeriodicFraction(subtraction) + "\n");

            var multiplication = rationalNumbers[0] * rationalNumbers[1];
            Console.WriteLine("Multiplication:" + multiplication.Numerator + "/" + multiplication.Denominator);
            Console.WriteLine(RationalNumber.GetPeriodicFraction(multiplication) + "\n");

            var division = rationalNumbers[0] / rationalNumbers[1];
            Console.WriteLine("Division: " + division.Numerator + "/" + division.Denominator);
            Console.WriteLine(RationalNumber.GetPeriodicFraction(division) + "\n");

            Console.WriteLine("Periodic Fraction: " + periodicFraction);
            var ordinaryFraction = RationalNumber.GetOrdinaryFraction(periodicFraction);
            Console.WriteLine("Ordinary Fraction: " + ordinaryFraction.Numerator + "/" + ordinaryFraction.Denominator);
        }
    }
}