using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    public class Problems11_20
    {
        public static long Problem11()
        {
            const int size = 4;
            long maxProduct = 0;

            // Horizontal left/right
            foreach (var row in ProblemHelper.TwoDGrid)
            {
                for (var index = 0; index < row.Length - size; index++)
                {
                    long product = 1;

                    var subArray = row.SubArray(index, size).ToList();
                    subArray.ForEach(x => product = product*x);

                    if (product > maxProduct)
                        maxProduct = product;
                }
            }

            // Vertical up/down
            for (var x = 0; x < ProblemHelper.TwoDGrid.Length - size; x++)
            {
                for (var y = 0; y < ProblemHelper.TwoDGrid[x].Length; y++)
                {
                    long product = 1;
                    ProblemHelper.GetVerticalValues(x, y, size).ToList().ForEach(value => product = product * value);

                    if (product > maxProduct)
                        maxProduct = product;
                }
            }
            
            // Diagonal right
            for (var x = 0; x < ProblemHelper.TwoDGrid.Length - size; x++)
            {
                for (var y = 0; y < ProblemHelper.TwoDGrid[x].Length - size; y++)
                {
                    long product = 1;
                    ProblemHelper.GetDiagonalRightValues(x, y, size).ToList().ForEach(value => product = product * value);

                    if (product > maxProduct)
                        maxProduct = product;
                }
            }

            // Diagonal left
            for (var x = ProblemHelper.TwoDGrid.Length - 1; x >= size; x--)
            {
                for (var y = 0; y < ProblemHelper.TwoDGrid[x].Length - size; y++)
                {
                    long product = 1;
                    ProblemHelper.GetDiagonalLeftValues(x, y, size).ToList().ForEach(value => product = product * value);

                    if (product > maxProduct)
                        maxProduct = product;
                }
            }

            return maxProduct;
        }

        public static long Problem12()
        {
            long number = 0;
            var index = 1;

            while (ProblemHelper.NumberOfDivisors(number) < 500)
            {
                number = ProblemHelper.GetTriangleNumber(index);
                index++;
            }

            return number;
        }

        public static long Problem13()
        {
            var result = new BigInteger();

            result = ProblemHelper.OneHundredFiftyDigitNumbers.Aggregate(result, (current, value) => current + value);

            return long.Parse(string.Concat(result.ToString().Take(10)));
        }

        public static long Problem14()
        {
            long maxLoopCount = 0;
            long maxLoopValue = 0;
            for (var index = 1; index <= 1000000; index++)
            {
                long loopCount = 0;
                long currentNumber = index;

                while (currentNumber != 1)
                {
                    if (currentNumber.IsEven())
                        currentNumber = currentNumber / 2;
                    else
                        currentNumber = 3 * currentNumber + 1;

                    loopCount++;
                }

                if (loopCount <= maxLoopCount) continue;

                maxLoopCount = loopCount;
                maxLoopValue = index;
            }

            return maxLoopValue;
        }

        public static long Problem14StoringLength()
        {
            var lengths = new List<int>() {0};
            long maxLoopCount = 0;
            long maxLoopValue = 0;
            for (var index = 1; index <= 1000000; index++)
            {
                var loopCount = 0;
                long currentNumber = index;

                while (currentNumber != 1)
                {
                    if (currentNumber.IsEven())
                        currentNumber = currentNumber / 2;
                    else
                        currentNumber = 3 * currentNumber + 1;

                    loopCount++;

                    if (currentNumber >= index) continue;

                    loopCount += lengths[(int)currentNumber];
                    break;
                }

                lengths.Add(loopCount);

                if (loopCount <= maxLoopCount) continue;

                maxLoopCount = loopCount;
                maxLoopValue = index;
            }

            return maxLoopValue;
        }
    }
}
