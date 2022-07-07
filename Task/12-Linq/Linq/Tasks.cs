using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Objects;

namespace Linq
{
    public static class Tasks
    {
        //The implementation of your tasks should look like this:
        public static string TaskExample(IEnumerable<string> stringList)
        {
            return stringList.Aggregate<string>((x, y) => x + y);
        }

        #region Low

        public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList)
        {
            return stringList.Select(x => x.ToString())
                .Where(x=>x.Length>1&&x.StartsWith(c)&&x.EndsWith(c));
        }

        public static IEnumerable<int> Task2(IEnumerable<string> stringList)
        {
            return stringList.Select(x=>x.Length).OrderBy(x=>x);

        }

        public static IEnumerable<string> Task3(IEnumerable<string> stringList)
        {
            return stringList.Select(x => x.First()+x.Last().ToString());
        }

        public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
        {
            return stringList.Where(x => x.Length.Equals(k)&&x.SkipLast(1).Any(char.IsNumber)).OrderBy(x=>x.Last());

        }
        /// <summary>
        /// Get from stringList all strings of length K ending in a digit and sort them in ascending order.
        /// </summary>
        /// <param name="integerList"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public static IEnumerable<string> Task5(IEnumerable<int> integerList)
        {
            return integerList.Where(x => x % 2 == 1).OrderBy(x => x).Select(x => x.ToString());
        }
        //Get sequence of string representations of only odd integerList values and sort in ascending order.

        #endregion

        #region Middle

        public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }

        public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }
        
        public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }

        public static IEnumerable<string> Task9(IEnumerable<string> stringList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }

        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }

        #endregion

        #region Advance

        public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }

        public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
        {
            //TODO :Delete line below and write your own solution
            throw new NotImplementedException();
        }

        public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }

        public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList,
                IEnumerable<SupplierDiscount> supplierDiscountList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }

        public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList,
            IEnumerable<StorePrice> storePriceList)
        {
            //TODO :Delete line below and write your own solution 
            throw new NotImplementedException();
        }

        #endregion

    }
}
