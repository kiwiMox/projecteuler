namespace ProjectEuler
{
    public static class Extensions
    {
        public static bool IsEven(this int number)
        {
            return CheckIfEven(number);
        }

        public static bool IsEven(this long number)
        {
            return CheckIfEven(number);
        }

        private static bool CheckIfEven(long number)
        {
            return number % 2 == 0;
        }
    }
}
