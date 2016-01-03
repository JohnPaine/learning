using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_arithmetic_1
{
    internal class Iterators
    {
        public static void Run_tests () {
            test_1 ();
        }

        private static IEnumerable<int> Fibs (int fibCount) {
            for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; ++i) {
                yield return prevFib;
                int newFib = prevFib + curFib;
                prevFib = curFib;
                curFib = newFib;
            }
        }

        private static IEnumerable<int> EvenNumbersOnly (IEnumerable<int> sequence) {
            /*
            foreach (var x in sequence) {
                if (x%2 == 0) {
                    yield return x;
                }
            }
             */
            //with LINQ
            return sequence.Where (x => x%2 == 0);
        }

        private static void test_1 () {
            foreach (var fib in EvenNumbersOnly (Fibs (10))) {
                Console.WriteLine (fib);
            }
        }
    }
}