using System;

namespace Function
{
    public enum SortOrder { Ascending, Descending }
    public static class Function
    {

        public static bool IsSorted(int[] array, SortOrder order)
        {
            int[] sortarr = new int[array.Length];
            Array.Copy(array, sortarr, array.Length);
            Array.Sort(sortarr);
            if (order == SortOrder.Ascending)
            {
                bool p = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != sortarr[i])
                    {
                        p = false;
                    }
                }
                return p;
            }
            else if (order == SortOrder.Descending)
            {
                Array.Reverse(sortarr);
                bool p = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != sortarr[i])
                    {
                        p = false;
                    }
                }
                return p;
            }
            else
            {
                return false;
            }

        }
        public static void Transform(int[] array, SortOrder order)
        {
            if (IsSorted(array, order))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = array[i] + i;
                }
            }
        }

        public static double MultArithmeticElements(double a, double t, int n)
        {
            double sum = a;
            for (int i = 1; i < n; i++)
            {
                a += t;
                sum *= a;
            }
            return sum;
        }

        public static double SumGeometricElements(double a, double t, double alim)
        {
            if (a < alim) { return 0; }
            double sum = 0;
            while (a > alim)
            {
                sum += a;
                a *= t;

            }
            return sum;
        }
    }
}
