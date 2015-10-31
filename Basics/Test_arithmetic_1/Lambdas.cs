using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_arithmetic_1
{
    class Lambdas
    {
        public static void Run_Tests()
        {
            //test_1();
            //test_2();
            test_3();
        }

        private delegate int Transformer(int i);

        private static void test_1() {
            Transformer sqr = x => x*x;
            Console.WriteLine(sqr(3));

            Func<int, int> f_sqr = x => x*x;
            Func<string, string, int> totalLength = (s1, s2) => s1.Length + s2.Length;

            var factor = 2;
            Func<int, int> multiplier = n => n*factor;
            Console.WriteLine(multiplier(3));
            factor = 5;
            Console.WriteLine(multiplier(3));
            Func<int> xFactor = () => factor++;
            Console.WriteLine(multiplier(3));
            xFactor();
            Console.WriteLine(multiplier(3));
        }

        static Func<int> Natural() {
            int seed = 0;
            return () => seed++;            //returns closure
        }

        static void test_2() {
            Func<int> natural = Natural();
            Console.WriteLine(natural());   //0
            Console.WriteLine(natural());   //1

            Action[] actions = new Action[3];
            for (var i = 0; i < 3; ++i) {
                actions[i] = () => Console.Write(i);
            }
            foreach (Action a in actions)
                a();                        //333
            Console.WriteLine();

            /*
            int ii = 0;
            actions[0] = () => Console.Write(ii);
            ii = 1;
            actions[1] = () => Console.Write(ii);
            ii = 2;
            actions[2] = () => Console.Write(ii);
            ii = 3;
            foreach (Action a in actions) a();      // 333
             *                                      explanation
             */
            for (int i = 0; i < 3; i++)
            {
                int loopScopedi = i;
                actions[i] = () => Console.Write(loopScopedi);
            }
            foreach (Action a in actions) 
                a();                                // 012
            Console.WriteLine();
            //This causes the closure to capture a different variable on each iteration.

            int ii = 0;
            foreach (char c in "abc")
                actions[ii++] = () => Console.Write(c);
            foreach (Action a in actions)
                a();
            Console.WriteLine();
        }

        static void test_3() {
            //testing anonymous methods!
            /*
             * An anonymous method is like a lambda expression, but it 
             * lacks the following features:
             * - Implicitly typed parameters
             * - Expression syntax (an anonymous method must always be a statement block)
             * - The ability to compile to an expression tree, by assigning to Expression<T>
             */
            Transformer sqr = delegate(int x) { return x*x; };
            Console.WriteLine(sqr(3));
            // Anonymous methods capture outer variables in the same way lambda expressions do.
        }

        /*
         * A unique feature of anonymous methods is that you can omit
         * the parameter declaration entirely—even if the delegate expects
         * them. This can be useful in declaring events with a default empty
         * handler:
         * */

        public static event EventHandler Clicked = delegate { };

        /*
         * This avoids the need for a null check before firing the event.
         * The following is also legal:
         */

        static void test_4() {
            //Note that we omit parameters!
            Clicked += delegate { Console.WriteLine("clicked"); };
        }
    }
}
