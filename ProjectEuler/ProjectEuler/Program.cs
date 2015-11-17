using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var problem = 1;
            var answers = new List<long>();
            #region Problems1-10

            answers.Add(Problems.Problems1_10.Problem1());
            Console.WriteLine("Problem " + problem + " Answer: " + answers[problem - 1]);
            problem++;

            answers.Add(Problems.Problems1_10.Problem2());
            Console.WriteLine("Problem " + problem + " Answer: " + answers[problem - 1]);
            problem++;

            answers.Add(Problems.Problems1_10.Problem3());
            Console.WriteLine("Problem " + problem + " Answer: " + answers[problem - 1]);
            problem++;

            answers.Add(Problems.Problems1_10.Problem4());
            Console.WriteLine("Problem " + problem + " Answer: " + answers[problem - 1]);
            problem++;

            answers.Add(Problems.Problems1_10.Problem5());
            Console.WriteLine("Problem " + problem + " Answer: " + answers[problem - 1]);
            problem++;

            #endregion

            Console.Read();
        }
    }
}
