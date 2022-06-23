using System;

namespace Condition
{
    public static class Condition
    {
        /// <summary>
        /// Implement code according to description of  task 1
        /// </summary>        
        public static int Task1(int n)
        {
            if (n > 0) {
                
                return (n*n); }
            else if(n<0) { return n*(-1); }
            return 0;

        }

        /// <summary>
        /// Implement code according to description of  task 2
        /// </summary>  
        public static int Task2(int n)
        {
            int[] arr = new int[3]; 
            arr[0] = n%10;
            
            arr[1] = (n/10)%10;
            
            arr[2] = (n / 100) % 10;
             Array.Sort(arr);
            Array.Reverse(arr);
            return arr[0] * 100 + arr[1] * 10 + arr[2];
        }
    }
}
