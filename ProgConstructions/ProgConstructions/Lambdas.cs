using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal static class Lambdas
    {
        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="func" /> — null.</exception>
        public static void RunTests()
        {
            try {
                ABitLINQ();
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }

        private static void ABitLINQ () {
            //P p = Console.WriteLine;
            //foreach (var i in new int[] { 1, 2, 3, 4 }) {
            //    p += () => Console.Write(i);
            //}
            // the same as:
            var p = new int[] {1, 2, 3, 4}.Aggregate<int, P> (Console.WriteLine,
                                                              (current, i) => current + (() => Console.Write (i + " ")));
            p ();

            List<int> list = new List<int> {
                4,
                2,
                4,
                5,
                6,
                456,
                34,
                534,
                3,
                46,
                67,
                678,
                789,
                43,
                954,
                23,
                583,
                23,
                9745,
                978,
                789,
                646459,
                795,
                652353,
                8
            };
            var evenNumbers = list.FindAll (i => (i%2 == 0));

            p = evenNumbers.Aggregate (p, (current, evenNumber) => current + (() => Console.Write (evenNumber + " ")));
            p ();
            Console.WriteLine ();
        }

        private delegate void P ();
    }
}
