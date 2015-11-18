using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal static class Structures
    {
        // All differences between classes and structures are presented in table at page 177
        // of Andrew Troelsen book

        // Also, at page 119 there is a picture with a description about inheritance hierarchy

        // Value types cannot have null value, BUT!!!
        // If we declare value variable with '?' symbol - 
        // this variable will accept all possible values of its type + null !!!!!!!


        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        public static void RunTests()
        {
            try {
                bool? a = null; // the same as Nullable<bool> a = null;
                int? b = null;  // the same as Nullable<int> b = null;
                if (!a.HasValue)
                    Console.WriteLine("a = {0}", a);

                //if (b.HasValue)
                //    int d = b;
                //else 
                //    int d = 100;
                // is the same as:
                int d = b ?? 100;

                //int c = null;     // error!

                int?[] arrayOfNullableInts = new int?[10];  // the same as Nullable<int[]>;
                //string? str = new string ();      // Error! string is already a Reference type!!!

                int c  = new int();
                c = 4;
                Console.WriteLine(c);
                int e;
                e = 10;
                Console.WriteLine(e);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
