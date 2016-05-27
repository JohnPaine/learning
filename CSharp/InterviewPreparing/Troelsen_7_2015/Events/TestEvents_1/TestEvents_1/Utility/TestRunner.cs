using System.Collections.Generic;
using System.Linq;

namespace TestEvents_1.Utility
{
    static class TestRunner
    {
        public delegate int TestDelegate();

        public static List<TestDelegate> Tests { get; }

        static TestRunner() {
            Tests = new List<TestDelegate>();
        }

        public static IEnumerable<int> RunTests() {
            return Tests.Select(test => test());
        }
    }
}
