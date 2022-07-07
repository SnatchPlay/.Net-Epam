using Linq.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

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
                .Where(x => x.Length > 1 && x.StartsWith(c) && x.EndsWith(c));
        }

        public static IEnumerable<int> Task2(IEnumerable<string> stringList)
        {
            return stringList.Select(x => x.Length).OrderBy(x => x);

        }

        public static IEnumerable<string> Task3(IEnumerable<string> stringList)
        {
            return stringList.Select(x => x.First() + x.Last().ToString());
        }

        public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
        {
            IEnumerable<string> result = stringList.
                Where(x => x.Length.Equals(k));
            result = result.Where(x => char.IsDigit(x.Last()));
            result = result.OrderBy(x => x);
            return result;


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
            int k = 0;
            IEnumerable<string> strings = Enumerable.Empty<string>();
            foreach (int n in numbers)
            {

                foreach (string s in stringList)
                {
                    k = 0;
                    if (s.Length.Equals(n) && char.IsDigit(s.First()))
                    {

                        strings = strings.Append(s);
                        k++;
                        break;

                    }
                }
                if (k == 0)
                {
                    strings = strings.Append("Not found");
                }
            }




            return numbers.Select(n => stringList.
            FirstOrDefault(y => y.Length == n && y.Length > 0 && char.IsDigit(y[0])) ?? "Not found");
            //return strings;

        }
        //A sequence of positive integers numbers and a sequence of strings stringList are given.
        //    Get a new sequence of strings according to the following rule: for each value n from sequence numbers,
        //    select a string from sequence stringList that starts with a digit and has length n.
        //    If there are several required strings in the stringList sequence, return the first;
        //if there are none, then return the string "Not found" 
        //    (To handle the situation related to the absence of required strings, use the ?? operation)

        public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
        {
            return integerList.Where(x => x % 2 == 0).Except(integerList.Where((x, index) => index > k - 1)).Reverse();
        }

        public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
        {
            return integerList.TakeWhile(x => x <= d).Union(integerList.Skip(k).Take(integerList.Count() - k)).OrderByDescending(x => x);
        }

        public static IEnumerable<string> Task9(IEnumerable<string> stringList)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {
            IEnumerable<string> result = stringList.OrderBy(x => x);
            IEnumerable<string> result2 =  Enumerable.Empty<string>();
            var group= result.GroupBy(x => x.Length);
            foreach (var s in group)
            {
                string ss = string.Empty;
                foreach (var v in s)
                {
                    ss += v.ToUpper().Last();
                }
                result2 = result2.Append(ss);
            }
            return result2.OrderByDescending(x=>x.Length);
            

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
