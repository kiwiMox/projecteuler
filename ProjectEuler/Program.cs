using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.UtcNow;

            #region Problems1-10

            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem1, 1);

            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem2, 2);

            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem3, 3);

            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem4, 4);

            //ComputeAndDisplayAnswer(Problems.Problems1_10.Problem5, 5);
            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem5PrimeFactors, 5);

            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem6, 6);

            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem7, 7);

            //ComputeAndDisplayAnswer(Problems.Problems1_10.Problem8, 8);
            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem8ZeroSplitStrings, 8);

            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem9, 9);

            ComputeAndDisplayAnswer(Problems.Problems1_10.Problem10, 10);

            #endregion

            var timeTaken = DateTime.UtcNow - startTime;
            Console.WriteLine();
            Console.WriteLine("Problems computed in " + timeTaken.TotalSeconds + " seconds");

            Console.Read();
        }

        private static void ComputeAndDisplayAnswer(Func<long> problemToRun, int problemNumber)
        {
            var answerStatTime = DateTime.UtcNow;
            var answer = problemToRun.Invoke();
            Console.WriteLine("Problem " + problemNumber + " Answer: " + answer +
                " - Computed in " + (DateTime.UtcNow - answerStatTime).TotalMilliseconds + " milli seconds");
        }
    }
}
