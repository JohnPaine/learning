using System;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Text;

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
                //FormatNumericalData();
                //DisplayFormatedMessage();
                //ParseFromStrings ();
                //FunWithBigIntegers ();
                //FunWithStringBuilder ();
                //StringAreImmutable ();
                LinqQueryOverInts ();
            }
            catch (Exception e) {
                Console.WriteLine (e);
            }


            Console.ReadLine ();
            return 0;
        }

        private static void LinqQueryOverInts () {
            int[] numbers = {1, 2, 4, 5, 6, 4, 3, 245, 389, 456, 453, 55, 345, 6, 5, 6, 32, 7, 345, 34, 6, 453};
            var subset = from i in numbers where i < 10 select i;

            Console.WriteLine ("Numbers in subset:");
            foreach (var i in subset) {
                Console.WriteLine ("{0}", i);
            }
            Console.WriteLine ();

            Console.WriteLine ("Type of subset - {0}", subset.GetType ());
            Console.WriteLine ("Type of subset defined in - {0}", subset.GetType ().Namespace);
        }

        private static void FunWithStringBuilder () {
            var sb = new StringBuilder ("*** Fun with StringBuilder: ***");
            Console.WriteLine ("sb = {0}", sb);
            sb.AppendLine ("Appended str 1");
            Console.WriteLine ("sb = {0}", sb);
            sb.Append ("\n\n");
            Console.WriteLine ("sb = {0}", sb);
            sb.Insert (sb.Length - 12, "*Here we placed another string*");
            Console.WriteLine ("sb = {0}", sb);
        }


        private static void StringAreImmutable () {
            var str1 = "Some string";
            str1 = str1.Insert (4, " other");
            Console.WriteLine ("str1 = {0}", str1);
            var str2 = str1.Replace ("other ", "newer other ");
            Console.WriteLine ("str1 = {0}", str1);
            Console.WriteLine ("str2 = {0}", str2);
            Console.WriteLine (string.Compare ("HeLLO", "hello", StringComparison.CurrentCulture));
            Console.WriteLine (string.Compare ("HellO", "hello", StringComparison.OrdinalIgnoreCase));
        }

        private static void FunWithBigIntegers () {
            //Console.WriteLine("=> Fun with big integers!");
            //var biggie = BigInteger.Parse ("999999999999999999999999999999999999999999999999999999999999999999999");
            //Console.WriteLine("Value of biggie - {0}", biggie);
            //Console.WriteLine("Is biggie even? - {0}", biggie.IsEven);
            //Console.WriteLine("Is biggie a power of two? - {0}", biggie.IsPowerOfTwo);
            //var reallyBig = BigInteger.Multiply (biggie, BigInteger.Parse ("88888888888888888888888888888888888888888888888888888888888888888888888888888888"));
            //Console.WriteLine("Value of reallyBig - {0}", reallyBig);

            var biggie = BigInteger.Parse ("1");
            for (var i = 0; i < 1000; ++i) {
                biggie *= 2;
                Console.WriteLine ("2^{0} = {1}", i + 1, biggie);
            }
        }

        private static void UseDatesAndTimes () {
            Console.WriteLine ("=> Dates and times:");

            var dt = new DateTime (2015, 9, 25);
            Console.WriteLine ("The day of {0} is {1}", dt.Date, dt.DayOfWeek);

            dt = dt.AddMonths (2);
            Console.WriteLine ("Daylight savings: {0}", dt.IsDaylightSavingTime ());
            Console.WriteLine ("Day of week: {0}", dt.DayOfWeek);
            Console.WriteLine ("Ticks: {0}", dt.Ticks);
            Console.WriteLine ("Kind: {0}", dt.Kind);
            Console.WriteLine ("To a Windows file time: {0}", dt.ToFileTime ());
            Console.WriteLine ("To a Windows file time UTC: {0}", dt.ToFileTimeUtc ());
            Console.WriteLine ("To string invariant culture: {0}", dt.ToString (CultureInfo.InvariantCulture));
            Console.WriteLine ("To string current culture: {0}", dt.ToString (CultureInfo.CurrentCulture));

            var ts = new TimeSpan (45, 17, 25, 45);
            Console.WriteLine ("Ts => {0}", ts);
            Console.WriteLine ("Ts subtracted 15 min => {0}", ts.Subtract (new TimeSpan (0, 15, 0)));
            Console.WriteLine ("Ts subtracted 12 days => {0}", ts.Subtract (new TimeSpan (12, 0, 0, 0)));
        }

        private static void ParseFromStrings () {
            Console.WriteLine ("=> Data type parsing:");

            var b = bool.Parse ("true");
            Console.WriteLine ("Value of b from Parse: {0}", b);
            if (bool.TryParse ("false", out b))
                Console.WriteLine ("But the TryParse func is more convenient " +
                                   "because doesn't throw an exception! New value for b: {0}", b);
            var d = double.Parse ("987,3333323");
            Console.WriteLine ("Value of d from Parse: {0}", d);
            var i = int.Parse ("16");
            Console.WriteLine ("Value of i from Parse: {0}", i);
            var c = char.Parse ("w");
            Console.WriteLine ("Value of c from Parse: {0}", c);
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