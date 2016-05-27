using System;
using TestEvents_1.Tests;
using TestEvents_1.Utility;

namespace TestEvents_1
{
    internal static class Program
    {
        private static void Main(string[] args) {
            TestRunner.Tests.Add(BasicDelegateTests.Test_1);
            TestRunner.Tests.Add(BasicDelegateTests.Test_2);


            var results = TestRunner.RunTests();

            foreach (var result in results) {
                Console.WriteLine($"Test result ---> {result}");
            }
        }
    }
}