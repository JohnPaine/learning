using System;
using System.Collections.Generic;
using System.Globalization;

namespace Test_arithmetic_1
{
    //Extension methods can only be declared in
    //non-generic, non-nested static class!!!
    public static class StringHelper
    {
        public static bool isCapitalized (this string s) {
            Console.WriteLine ("StringHelper.isCapitalized({0})", s);
            return !string.IsNullOrEmpty (s) && char.IsUpper (s[0]);
        }

        //Interfaces can be extended too!
        public static T First<T> (this IEnumerable<T> sequence) {
            foreach (T element in sequence) {
                return element;
            }
            throw new InvalidOperationException ("No elements!");
        }

        public static string Pluralize (this string s) {
            return s + " Pluralized! ";
        }

        public static string Capitalize (this string s) {
            return s[0].ToString (CultureInfo.InvariantCulture).ToUpper () + s.Substring (1);
        }
    }

    internal class Test
    {
        public void Foo (object x) {
            Console.WriteLine ("Test.Foo({0})", x);
        }
    }

    internal static class Extensions
    {
        public static void Foo (this Test t, int x) {
            Console.WriteLine ("Extensions.Foo({0})", x);
        }
    }

    internal static class ObjectHelper
    {
        public static bool isCapitalized (this object o) {
            if (o == null) {
                throw new ArgumentNullException ("o");
            }
            Console.WriteLine ("ObjectHelper.isCapitalized({0})", o);
            if (o is string) {
                return char.IsUpper (o.ToString ()[0]);
            }
            return false;
        }
    }

    internal class ExtensionMethods
    {
        public static void Run_Tests () {
            //test_1();
            //test_2();
            test_3 ();
        }

        private static void test_1 () {
            Console.WriteLine ("Pearl".isCapitalized ());
            Console.WriteLine ("Machumba!".First ());

            //x and y are equivalent and both evaluate to "Sausages", but x uses extension methods,
            //whereas y uses static methods:
            var x = "sausage".Pluralize ().Capitalize ();
            var y = StringHelper.Capitalize (StringHelper.Pluralize ("sausage"));
            Console.WriteLine (x == y);
            Console.WriteLine (x);
        }

        private static void test_2 () {
            //Any compatible instance method will always take precedence over an extension
            //method. In the following example, Test’o Foo method will always take precedence
            //—even when called with an argument x of type int:
            var t = new Test ();
            t.Foo (5);
            Extensions.Foo (t, 10);
        }

        private static void test_3 () {
            //If two extension methods have the same signature, the extension method must be
            //called as an ordinary static method to disambiguate the method to call. If one
            //extension method has more specific arguments, however, the more specific method
            //takes precedence.
            Console.WriteLine ("Bambooka".isCapitalized ());
            Console.WriteLine (ObjectHelper.isCapitalized ("Bambooka!"));
        }
    }
}