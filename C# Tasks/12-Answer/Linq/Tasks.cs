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
            return stringList.
                Where(x => x.Length.Equals(k)).Where(x => char.IsDigit(x.Last())).OrderBy(x => x);
        }
        public static IEnumerable<string> Task5(IEnumerable<int> integerList)
        {
            return integerList.Where(x => x % 2 == 1).OrderBy(x => x).Select(x => x.ToString());
        }

        #endregion

        #region Middle

        public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
        {
            return numbers.Select(n => stringList.
            FirstOrDefault(y => y.Length == n && y.Length > 0 && char.IsDigit(y[0])) ?? "Not found");
        }


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
            return stringList.GroupBy(x => x.First()).Select(x => new { firstletter = x.Key, word = x.Sum(xx => xx.Length), defis = "-" }).
                OrderByDescending(x => x.word).ThenBy(x => x.firstletter)
                .Select(x => String.Concat(x.word, x.defis, x.firstletter));

        }

        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {

            return stringList.OrderBy(x => x).GroupBy(x => x.Length)
                .Select(x => new { lenght = x.Key, last = String.Concat(x.Select(xx => xx.ToUpper().Last())) })
                .Select(x => x.last)
                .OrderByDescending(x => x.Length)
                ;

        }

        #endregion

        #region Advance

        public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
        {
            return nameList.GroupBy(x => x.Year).Select(x =>
            new YearSchoolStat { Year = x.Key, NumberOfSchools = x.Select(x => x.SchoolNumber).Distinct().Count() })
                .OrderBy(x => x.NumberOfSchools).ThenBy(x => x.Year);
        }

        public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
        {
            return integerList1.Join(integerList2, c => c % 10, b => b % 10, (c, b) => (c, b))
                .Select(x => new NumberPair { Item1 = x.c, Item2 = x.b })
                .OrderBy(x => x.Item1).ThenBy(x => x.Item2);
        }

        public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            return yearList.Join(nameList.GroupBy(x => x.Year), y => y, n => n.Key, (y, n) => (y, n))
                .Select(x => new YearSchoolStat
                {
                    NumberOfSchools = x.n.Select(x => x.SchoolNumber)
                .Distinct().Count(),
                    Year = x.y
                })
            .Concat(yearList.Select(x => x).Except(nameList.Select(x => x.Year).Distinct())
                .Select(x => new YearSchoolStat { NumberOfSchools = 0, Year = x }))
            .OrderBy(x => x.NumberOfSchools).ThenBy(x => x.Year);
        }

        public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList,
                IEnumerable<SupplierDiscount> supplierDiscountList)
        {
            return supplierDiscountList.GroupBy(x => x.ShopName).Select(x => new
            {
                shopname = x.Key,
                max = x.Select(xx => xx.Discount).Max(),
                owner = x.
                Where(xx => xx.Discount == x.Select(xx => xx.Discount).Max()).Select(x => x.SupplierId).Min()
            }).Select(x => new MaxDiscountOwner
            {
                Discount = x.max,
                ShopName = x.shopname,
                Owner = supplierList.First(xx => xx.Id == x.owner)
            })
            .OrderBy(x => x.ShopName);
        }

        public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList,
            IEnumerable<StorePrice> storePriceList)
        {
            return storePriceList.Join(goodList, si => si.GoodId, gi => gi.Id,
                (si, gi) => (si, gi)).GroupBy(x => x.gi.Country).Select(x => new CountryStat
                {
                    Country = x.Key,
                    StoresNumber = x.Select(xx => xx.si.Shop).Distinct().Count(),
                    MinPrice = x.Select(xx => xx.si.Price).Min()

                }).Concat(goodList.Where(x => !storePriceList.Any(y => y.GoodId == x.Id))
                .Select(xx => xx.Country).Distinct()
                .Select(x => new CountryStat { Country = x, MinPrice = 0, StoresNumber = 0 }))
                .OrderBy(x => x.Country);
        }

        #endregion

    }
}
