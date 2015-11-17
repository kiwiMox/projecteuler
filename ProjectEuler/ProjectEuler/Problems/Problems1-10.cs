using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    public static class Problems1_10
    {
        public static int Problem1()
        {
            var sum = 0;

            for (var x = 0; x < 1000; x++)
            {
                if (x%3 == 0 || x % 5 == 0)
                    sum += x;
            }

            return sum;
        }

        public static int Problem2()
        {
            var sum = 0;

            var lastNumber = 1;
            var currentNumber = 2;

            while (currentNumber < 4000000)
            {
                if (currentNumber%2 == 0)
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

        public static int Problem4()
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

        public static int Problem5()
        {
            var numbersUnderTest = ProblemHelper.NumbersOneToTwenty;
            var testValue = numbersUnderTest.Max();

            while (numbersUnderTest.Any(number => testValue % number != 0))
            {
                testValue += 2; //can't be an odd number with even numbers in the list
            }

            return testValue;
        }
    }
}
