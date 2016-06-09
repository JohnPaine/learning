using System;
using System.Reflection;
using LINQ_to_objects_1.Tests;
using LINQ_to_objects_1.Utility;

namespace LINQ_to_objects_1
{
    internal class Program
    {
        private static void Main(string[] args) {
//            TestRunner.Tests.Add(LinqBasicTests.QueryOverStrings);
//            TestRunner.Tests.Add(LinqBasicTests.QueryOverInts);
//            TestRunner.Tests.Add(LinqBasicTests.QueryOverArrayList);
//            TestRunner.Tests.Add(LinqBasicTests.OfTypeAsFilter);
//            TestRunner.Tests.Add(LinqQueryTests.GetNamesAndDescriptions);
//            TestRunner.Tests.Add(LinqQueryTests.TestGettingProjectedData);
//            TestRunner.Tests.Add(LinqQueryTests.ReversedData);
//            TestRunner.Tests.Add(LinqQueryTests.AlphabetizeData);
//            TestRunner.Tests.Add(LinqQueryTests.DisplayDiff);
//            TestRunner.Tests.Add(LinqQueryTests.DisplayIntersection);
//            TestRunner.Tests.Add(LinqQueryTests.DisplayUnion);
//            TestRunner.Tests.Add(LinqQueryTests.DisplayConcat);
//            TestRunner.Tests.Add(LinqQueryTests.DistinctConcatVsUnion);
//            TestRunner.Tests.Add(LinqQueryTests.AggregateOps);
//            TestRunner.Tests.Add(LinqQueryTests.QueryWithLambdas);
            TestRunner.Tests.Add(LinqQueryTests.QueryWithAnonymousMethods);

            foreach (var test in TestRunner.Tests) {
                Console.WriteLine($"Running test {test.GetMethodInfo().Name} \t-----------------------------");
                Console.WriteLine($"Test {test.GetMethodInfo().Name} result \t\t-------------------> {TestRunner.RunTest(TestRunner.Tests.IndexOf(test))}");
            }
        }
    }
}