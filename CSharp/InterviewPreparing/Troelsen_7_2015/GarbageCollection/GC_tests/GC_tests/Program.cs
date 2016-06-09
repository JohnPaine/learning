using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GC_tests.Tests;
using LINQ_to_objects_1.Utility;

namespace GC_tests
{
    class Program
    {
        static void Main(string[] args)
        {
//            TestRunner.Tests.Add(GCInfos.CommonGcInfo);
            TestRunner.Tests.Add(GCTests.ForceGarbageCollection);

            foreach (var test in TestRunner.Tests)
            {
                Console.WriteLine($"Running test {test.GetMethodInfo().Name} \t-----------------------------");
                Console.WriteLine($"Test {test.GetMethodInfo().Name} result \t\t-------------------> {TestRunner.RunTest(TestRunner.Tests.IndexOf(test))}");
            }
        }
    }
}
