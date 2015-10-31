using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_arithmetic_1
{
    class AnonymousTypes_1
    {
        public static void Run_Tests() {
            test_1();
        }

        static void test_1() {
            var dude = new {Name = "Petia", Age = 15};
        }
    }
}
