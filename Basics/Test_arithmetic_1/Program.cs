using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArithmetic
{
    class Program
    {

        static void Main(string[] args) {
            RunTests ();
        }

        private static void RunTests () {
            TestInheritance.Run_Tests ();
            TestGenerics.Run_Tests ();
            Delegates.Run_Tests ();
            Lambdas.Run_Tests ();
            TryCatch.Run_Tests ();
            Iterators.Run_tests ();
            Overloading.Run_Tests ();
            ExtensionMethods.Run_Tests ();
            AnonymousTypes.Run_Tests ();
        }
    }
}
