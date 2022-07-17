using System;
using System.Linq;

namespace ArrayObject
{
    public static class ArrayTasks
    {
        /// <summary>
        /// Task 1
        /// </summary>
        public static void ChangeElementsInArray(int[] nums)
        {
            for(int i = 0; i < nums.Length/2; i++)
            {
                if (nums[i]%2==0 && nums[nums.Length-i-1] % 2 == 0)
                {
                    int tmp=nums[i];
                    nums[i]=nums[nums.Length - i-1];
                    nums[nums.Length - i-1 ] =tmp;
                }
            }

        }

        /// <summary>
        /// Task 2
        /// </summary>
        public static int DistanceBetweenFirstAndLastOccurrenceOfMaxValue(int[] nums)
        {
            int result = 0,lmax;
            if(nums.Length == 0) { return result; }
            int maxValue = nums.Max();
            int maxIndex = nums.ToList().IndexOf(maxValue);
            lmax = maxIndex;

            for (int i = nums.Length-1; i > maxIndex; i--)
            {
                if(nums[i] == maxValue)
                {
                    lmax = i;
                    break;
                }
            }
            result = lmax - maxIndex;
            return result;
        }

        /// <summary>
        /// Task 3 
        /// </summary>
        public static void ChangeMatrixDiagonally(int[,] matrix)
        {
            for(int i= 0; i < matrix.GetLength(0); i++)
            {
                for(int j= 0; j < matrix.GetLength(1); j++)
                {
                    if (j<i) { matrix[i,j] = 0; }
                    else if(i<j) { matrix[i,j] = 1; }
                }
            }
        }
    }
}
