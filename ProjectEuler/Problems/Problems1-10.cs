using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public static class Problems1_10
    {
        public static long Problem1()
        {
            var sum = 0;

            for (var x = 0; x < 1000; x++)
            {
                if (x%3 == 0 || x % 5 == 0)
                    sum += x;
            }

            return sum;
        }

        public static long Problem2()
        {
            var sum = 0;

            var lastNumber = 1;
            var currentNumber = 2;

            while (currentNumber < 4000000)
            {
                if (currentNumber.IsEven())
                    sum += currentNumber;

                var nextNumber = currentNumber + lastNumber;
                lastNumber = currentNumber;
                currentNumber = nextNumber;
            }

            return sum;
        }

        public static long Problem3()
        {
            long value = 600851475143;
            long maxFactor = 0;

            while (!ProblemHelper.IsPrime(value))
            {
                var factor = ProblemHelper.FindFactor(value);

                if (factor == 0)
                    return maxFactor;

                if (factor > maxFactor)
                    maxFactor = factor;

                value = value / factor;
            }

            if (value > maxFactor)
                maxFactor = value;

            return maxFactor;
        }

        public static long Problem4()
        {
            var palindromes = new List<int>();

            for (var factor1 = 999; factor1 >= 100; factor1--)
            {
                for (var factor2 = 999; factor2 >= 100; factor2--)
                {
                    var value = factor1*factor2;
                    if (ProblemHelper.IsPalindrome(value))
                        palindromes.Add(value);
                }
            }

            return palindromes.Max(x => x);
        }

        public static long Problem5()
        {
            var numbersUnderTest = ProblemHelper.NumbersOneToTwenty;
            var testValue = numbersUnderTest.Max();

            while (numbersUnderTest.Any(number => testValue % number != 0))
            {
                testValue += 2; //can't be an odd number with even numbers in the list
            }

            return testValue;
        }

        public static long Problem5PrimeFactors()
        {
            //https://projecteuler.net/overview=005

            var numbersUnderTest = ProblemHelper.NumbersOneToTwenty;
            var k = numbersUnderTest.Max();
            var index = 0;
            long N = 1;
            var a = new List<double>();
            var limit = Math.Sqrt(k);
            var check = true;

            while (ProblemHelper.GetPrimeAtIndex(index) <= k)
            {
                a.Add(1);
                if (check)
                {
                    if (ProblemHelper.GetPrimeAtIndex(index) <= limit)
                    {
                        a[index] = Math.Floor(Math.Log(k) / Math.Log(ProblemHelper.GetPrimeAtIndex(index)));
                    }
                    else
                    {
                        check = false;
                    }
                }
                N = N * (long)Math.Pow(ProblemHelper.GetPrimeAtIndex(index), a[index]);
                index++;
            }

            return N;
        }

        public static long Problem6()
        {
            var numbers = new List<int>();

            for (var x = 1; x <= 100; x++)
            {
                numbers.Add(x);
            }

            //sum of the squares
            long sumOfSquares = 0;
            numbers.ForEach(x => sumOfSquares += x*x);

            //square of the sum
            long squareOfTheSum = 0;
            numbers.ForEach(x => squareOfTheSum += x);
            squareOfTheSum = squareOfTheSum * squareOfTheSum;

            return squareOfTheSum - sumOfSquares;
        }

        public static long Problem7()
        {
            return ProblemHelper.GetPrimeAtIndex(10000);
        }

        public static long Problem8()
        {
            const int adjacentCount = 13;
            long maxProduct = 1;

            for (var index = 0; index < ProblemHelper.ThousandDigitNumberText.Count() - adjacentCount; index++)
            {
                var digitsToTest = ProblemHelper.ThousandDigitNumberText.Substring(index, adjacentCount);

                // skip the 0 values
                if (digitsToTest.Contains("0"))
                    continue;

                var product = digitsToTest.Aggregate<char, long>(1, (current, c) => current*long.Parse(c.ToString()));

                if (product > maxProduct)
                    maxProduct = product;
            }

            return maxProduct;
        }

        public static long Problem8ZeroSplitStrings()
        {
            const int adjacentCount = 13;
            long maxProduct = 1;

            var splitStrings = ProblemHelper.ThousandDigitNumberText.Split('0').Where(x => x.Count() >= adjacentCount);

            foreach (var toCheck in splitStrings)
            {
                for (var index = 0; index <= toCheck.Count() - adjacentCount; index++)
                {
                    var digitsToTest = toCheck.Substring(index, adjacentCount);
                    
                    var product = digitsToTest.Aggregate<char, long>(1, (current, c) => current * long.Parse(c.ToString()));

                    if (product > maxProduct)
                        maxProduct = product;
                }
            }

            return maxProduct;
        }

        public static long Problem9()
        {
            for (var a = 1; a < 1000; a++)
            {
                for (var b = 1; b < 1000; b++)
                {
                    for (var c = 1; c < 1000; c++)
                    {
                        if (a + b + c != 1000) continue;

                        if (ProblemHelper.IsPythagoreanTriplet(a, b, c))
                            return a*b*c;
                    }
                }
            }

            return 0;
        }

        public static long Problem10()
        {
            long primeSum = 0;

            for (var x = 2; x < 2000000; x++)
            {
                if (ProblemHelper.IsPrime(x))
                    primeSum += x;
            }

            return primeSum;
        }
    }
}
