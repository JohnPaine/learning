using System.Collections.Generic;
using System.Linq;

namespace LINQ_to_objects_1.Utility
{
    static class TestRunner
    {
        public delegate int TestDelegate();

        public static List<TestDelegate> Tests { get; }

        static TestRunner() {
            Tests = new List<TestDelegate>();
        }

        public static int RunTest(int index) {
            return Tests[index]();
        }

        public static IEnumerable<int> RunTests() {
            return Tests.Select(test => test());
        }
    }
}
