namespace LoopTasks
{
    public static class LoopTasks
    {
        /// <summary>
        /// Task 1
        /// </summary>
        public static int SumOfOddDigits(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                if (n % 2 != 0)
                {
                    sum = sum + (n % 10);
                }
                n /= 10;
            }
            return sum;
        }

        /// <summary>
        /// Task 2
        /// </summary>
        public static int NumberOfUnitsInBinaryRecord(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum = sum + (n % 2);
                n /= 2;
            }
            return sum;


        }

        /// <summary>
        /// Task 3 
        /// </summary>
        public static int SumOfFirstNFibonacciNumbers(int n)
        {
            int c = 0, sum = 1, a = 0, b = 1;
            for (int i = 2; i < n; i++)
            {
                c = a + b;
                sum += c;
                a = b;
                b = c;
            }

            if (n == 1) { return a; }
            else { return sum; }


        }
    }
}