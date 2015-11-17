using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public static class ProblemHelper
    {
        public static List<int> NumbersOneToTen = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public static List<int> NumbersOneToTwenty = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        public static long FindFactor(long value)
        {
            for (var factor = 2; factor < value; factor++)
            {
                if (!IsPrime(factor)) continue;

                if (value % factor != 0) continue;

                return factor;
            }

            return 0;
        }

        public static bool IsPrime(long number)
        {
            var boundary = Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (var i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static bool IsPalindrome(long value)
        {
            var forward = value.ToString();
            var reverse = string.Concat(value.ToString().Reverse());

            return string.Compare(forward, reverse) == 0;
        }
    }
}
