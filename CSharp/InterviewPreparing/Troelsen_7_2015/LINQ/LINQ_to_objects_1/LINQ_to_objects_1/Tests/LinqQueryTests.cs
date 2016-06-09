using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LINQ_to_objects_1.Model;
using LINQ_to_objects_1.Utility;

namespace LINQ_to_objects_1.Tests
{
    internal class LinqQueryTests
    {
        private static readonly ProductInfo[] ProductInfos = {
            new ProductInfo {
                Name = "Mac’s Coffee",
                Description = "Coffee with TEETH",
                NumberInStock = 24
            },
            new ProductInfo {
                Name = "Milk Maid Milk",
                Description = "Milk cow’s love",
                NumberInStock = 63
            },
            new ProductInfo {
                Name = "Pure Silk Tofu",
                Description = "Bland as Possible",
                NumberInStock = 120
            },
            new ProductInfo {
                Name = "Cruchy Pops",
                Description = "Cheezy, peppery goodness",
                NumberInStock = 6
            },
            new ProductInfo {
                Name = "RipOff Water",
                Description = "From the tap to your wallet",
                NumberInStock = 100
            },
            new ProductInfo {
                Name = "Classic Valpo Pizza",
                Description = "Everyone loves pizza!",
                NumberInStock = 37
            },
            new ProductInfo {
                Name = "Pepperoni Pizza",
                Description = "Everyone loves pepperoni pizza!",
                NumberInStock = 16
            }
        };

        private static readonly List<string> MyCarList = new List<string> { "Yugo", "Aztec", "BMW" };
        private static readonly List<string> YourCarList = new List<string> { "BMW", "Saab", "Aztec" };
        private static readonly object Assert;

        public static int GetNamesAndDescriptions() {
            var prodInfos = from product in ProductInfos select new {product.Name, product.Description};

            prodInfos.PrintEnumerable();

            return 0;
        }

        // projection underlying type is not known until compilation, so it cannot be returned as specific type
        private static Array GetNamesAndDescriptionsAsArray() {
            return (from product in ProductInfos select new { product.Name, product.Description }).ToArray();
        }

        public static int TestGettingProjectedData() {
            var projectedData = GetNamesAndDescriptionsAsArray();

            projectedData.PrintArray();

            return 0;
        }

        public static int ReversedData() {
//            var reversedData = (from p in ProductInfos select p).Reverse();

            var reversedData = ProductInfos.Reverse();
            reversedData.PrintEnumerable();

            return 0;
        }

        public static int AlphabetizeData() {
            // ascending order is default
            var ordered = from p in ProductInfos orderby p.Name ascending select p;

            ordered.PrintEnumerable();

            ordered = from p in ProductInfos orderby p.Name descending select p;

            ordered.PrintEnumerable();

            return 0;
        }

        public static int DisplayDiff() {
//            var diff = (from c in myCars select c).Except(from c2 in yourCars select c2);
            var diff = MyCarList.Except(YourCarList);
            diff.PrintEnumerable();

            diff = YourCarList.Except(MyCarList);
            diff.PrintEnumerable();

            return 0;
        }

        public static int DisplayIntersection() {
            var intersect = MyCarList.Intersect(YourCarList);
            intersect.PrintEnumerable();

            intersect = YourCarList.Intersect(MyCarList);
            intersect.PrintEnumerable();

            intersect = MyCarList.Intersect(MyCarList);
            intersect.PrintEnumerable();

            return 0;
        }

        public static int DisplayUnion() {
            var union = MyCarList.Union(YourCarList);
            union.PrintEnumerable();

            return 0;
        }

        public static int DisplayConcat() {
            var concat = MyCarList.Concat(YourCarList);
            concat.PrintEnumerable();

            return 0;
        }

        public static int DistinctConcatVsUnion() {
            var distinctConcat = MyCarList.Concat(YourCarList).Distinct();
            var union = MyCarList.Union(YourCarList);

//            distinctConcat.PrintEnumerable();
//            union.PrintEnumerable();

            var diff = distinctConcat.Except(union);
            Debug.Assert(!diff.Any(), "Diff should've been empty, but it's NOT!");

            return 0;
        }

        public static int AggregateOps() {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
            Console.WriteLine($"Max - {winterTemps.Max()}");
            Console.WriteLine($"Min - {winterTemps.Min()}");
            Console.WriteLine($"Average - {winterTemps.Average()}");
            Console.WriteLine($"Sum - {winterTemps.Sum()}");

            return 0;
        }

        public static int QueryWithLambdas() {
            var subset1 = from p in ProductInfos where p.NumberInStock > 30 orderby p.Name select p;
            var subset2 = ProductInfos.Where(p => p.NumberInStock > 30).OrderBy(p => p.Name).Select(p => p);

            var diff = subset1.Except(subset2);

            Debug.Assert(!diff.Any(), "Diff should've been empty, but it's NOT!");

            return 0;
        }

        public static int QueryWithAnonymousMethods() {
            var prodNames = from p in ProductInfos select p.Name;
            // Func<string, bool> searchFilter = delegate(string name) { return name.Contains("Pizza"); };
            // the same as:
            Func<string, bool> searchFilter = name => name.Contains("Pizza");
            Func<string, string> itemToProcess = name => name;
            var subset = prodNames.Where(searchFilter).OrderBy(itemToProcess).Select(itemToProcess);

            subset.PrintEnumerable();

            return 0;
        }

    }
}