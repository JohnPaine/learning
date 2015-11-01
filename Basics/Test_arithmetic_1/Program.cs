using System;
using System.Security.Principal;

namespace Test_arithmetic_1
{
    internal class Program
    {
        private static int Main (string[] args) {
            try {
                //PrintArguments(args);
                //PrintEnvironmentDetails();
                //RunTests();
                //GetUserData ();
                FormatNumericalData();
                DisplayFormatedMessage();
            }
            catch (Exception e) {
                Console.WriteLine (e);
            }


            Console.ReadLine ();
            return 0;
        }

        private static void DisplayFormatedMessage () {
            //var userMessage = string.Format ("10000 in hex = {0:x}", 10000);
            // the same as:
            var userMessage = $"10000 in hex = {10000:x}";
            System.Windows.MessageBox.Show (userMessage);
        }

        private static void FormatNumericalData () {
            Console.WriteLine ("The value 99999 various formats:");
            Console.WriteLine ("c format: {0:c}", 99999);
            Console.WriteLine ("C format: {0:C}", 99999);
            Console.WriteLine ("d9 format: {0:d9}", 99999);
            Console.WriteLine ("f3 format: {0:f3}", 99999);
            Console.WriteLine ("n format: {0:n}", 99999);
            Console.WriteLine ("e format: {0:e}", 99999);
            Console.WriteLine ("E format: {0:E}", 99999);
            Console.WriteLine ("d format: {0:d}", 99999);
            Console.WriteLine ("D format: {0:D}", 99999);
        }

        private static void GetUserData () {
            Console.WriteLine ("Enter your name:");
            var name = Console.ReadLine ();
            Console.WriteLine ("Enter your age:");
            var age = Console.ReadLine ();

            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ("Hello, {0}! You are {1} years old.", name, age);
            Console.ForegroundColor = previousColor;
        }

        private static void PrintArguments (string[] args) {
            foreach (var s in args) {
                Console.WriteLine ("Arg {0} - {1}", Array.IndexOf ((Array) args, s), s);
            }

            var anotherArgs = Environment.GetCommandLineArgs ();
            foreach (var s in anotherArgs) {
                Console.WriteLine ("Another Arg {0} - {1}", Array.IndexOf ((Array) anotherArgs, s), s);
            }
        }

        private static void PrintEnvironmentDetails () {
            foreach (var logicalDrive in Environment.GetLogicalDrives ()) {
                Console.WriteLine ("Drive : {0} ", logicalDrive);
            }

            Console.WriteLine ("OS Version: {0}", Environment.OSVersion);
            Console.WriteLine ("Number of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine ("Is 64bit process: {0}", Environment.Is64BitProcess);
            Console.WriteLine (".NET Version: {0}", Environment.Version);
            Console.WriteLine ("System directory: {0}", Environment.SystemDirectory);
            Console.WriteLine ("System page size: {0}", Environment.SystemPageSize);
            Console.WriteLine ("System New Line: {0}", Environment.NewLine);
        }

        private static void RunTests () {
            try {
                TestInheritance.Run_Tests ();
                TestGenerics.Run_Tests ();
                TestNumeric.RunTests ();
                Delegates.Run_Tests ();
                Lambdas.Run_Tests ();
                TryCatch.Run_Tests ();
                Iterators.Run_tests ();
                Overloading.Run_Tests ();
                AnonymousTypes.Run_Tests ();
                ExtensionMethods.Run_Tests ();
            }
            catch (Exception e) {
                Console.WriteLine (e);
            }
        }
    }
}