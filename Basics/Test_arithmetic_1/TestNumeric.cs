using System;
using System.Collections;
using System.IO;

namespace Test_arithmetic_1
{
    internal class TestNumeric
    {
        private static void Split (string name, out string firstName, out string lastName) {
            int i = name.LastIndexOf (' ');
            firstName = name.Substring (0, i);
            lastName = name.Substring (i + 1);
        }

        private static void Tst1 () {
            int a0 = (int) 1E07;
            int a1 = (int) 1E07;
            try {
                int a3 = checked((int) (a0*a1)); //overflow checking
                int b3 = unchecked(int.MaxValue + 1);
                unchecked //wont be any exception
                {
                    int c3 = a0*a1;
                }
                float tenth = 0.1f;
                float one = 1f;
                Console.WriteLine (one - tenth*10f);
                decimal m = 1M/6M;
                double d4 = 1.0/6.0;
                Console.WriteLine ("m = {0}, d = {1}", m, d4);
                int[][] jaggedArray = new int[][] {
                    new int[] {0, 1, 2},
                    new int[] {3, 4, 5},
                    new int[] {6, 7, 8, 9},
                };
                int[,] matrix1 = new int[5, 5];
                var matrix2 = new int[,] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
                for (int i1 = 0; i1 < matrix2.GetLength (0); ++i1) {
                    for (int j1 = 0; j1 < matrix2.GetLength (1); j1++) {
                        matrix2[i1, j1] = i1*3 + j1;
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine (e);
            }
        }

        private static void Tst2 () {
            #region Test

            int k2 = 1;
            switch (k2) {
                case 0:
                case 1:
                    Console.WriteLine ("Case 1");
                    break;
                case 2:
                default:
                    Console.WriteLine ("dfvg");
                    break;
            }


            ArrayList list = new ArrayList ();
            list.Add (new object ());
            list.Add (new Exception ());
            list.Add (new Random ().Next (10));
            list.Add (new ArrayList ());

            double i5;
            int j5;
            short k5;
            i5 = j5 = k5 = 0;
            sbyte x, y = 100;
            x = 90;
            //x = x + y;
            ushort u2 = 10;
            ushort s2 = ++u2;

            byte aaa = 0x1a, bbb = 2;
            aaa += bbb;

            char aaaa = 'a', bbbb = 'b';
            //char cccc = aaaa + bbbb;


            uint u = 1;
            int i = 1;
            long l = u*i;


            int a = 0;
            decimal b = 0;
            double c = 0.0;

            Console.WriteLine ((a == b));
            Console.WriteLine (a.Equals (b));
            Console.WriteLine (a == c);
            Console.WriteLine (a.Equals (c));

            Func<int> d;
            d = () => 0;
            d += () => 1;
            d += () => 2;
            int b2 = d ();
            Console.WriteLine (b2);


            int k = 1;
            Console.WriteLine (k++ + ++k);

            #endregion
        }

        private static void Tst3 () {
            #region Outs and refs

            string firstName, lastName;
            Split ("John Michael Paine", out firstName, out lastName);
            Console.WriteLine (firstName + '\n' + lastName);

            #endregion
        }

        /// <summary>
        /// All tests run here
        /// </summary>
        /// <remarks>Remarkable</remarks>
        /// <exception cref="IOException">An I/O error occurred. </exception>
        public static void RunTests () {
            try {
                Test.Tst1 ();
                Test.Tst2 ();
                Test.Tst3();
                Test.Tst4();
            }
            catch (Exception e) {
                Console.WriteLine (e);
            }
        }

        private class Test
        {
            private static int _x;

            /// <exception cref="IOException">An I/O error occurred. </exception>
            public static void Tst1 () {
                Foo (out _x);

                int total = Sum (1, 2, 3, 4);
                int total2 = Sum (new int[] {1, 2, 3, 4});
                Console.WriteLine (total);
            }

            /// <exception cref="IOException">An I/O error occurred. </exception>
            public static void Tst2 () {
                int j = 0;
                for (int i = 0; i < 10; i++)
                    j = j++;
                Console.WriteLine (j);
            }

            /// <exception cref="IOException">An I/O error occurred. </exception>
            public static void Tst3 () {
                int end = int.MaxValue;
                int begin = end - 100;
                int counter = 0;

                Console.WriteLine (int.MaxValue);

                for (int i = begin; i < end; i++)
                    counter++;

                Console.WriteLine (counter);
            }

            public static void Tst4 () {
                Foo ();
                Foo (2);
                Foo (_x);
                Foo (out _x);

                Foo2 (x: 2, y: 5);
                Foo2 (y: 4, x: 7);

                int a = 0;
                Foo2 (y: ++a, x: --a); // ++a is evaluated first
                Foo2 (1, y: 2);
                //Foo2(x: 1, 2);        // Compile-time error

                Bar (c: 4);
            }

            /// <exception cref="NotImplementedException">Condition.</exception>
            public static void TstBunny () {
                /*      //if these fields are public!
                var b1 = new Bunny { name = "Bo1", likesCarrots = true, likesHumans = false };
                var b2 = new Bunny("Bo2") { likesCarrots = true, likesHumans = false };
                var b3 = new Bunny(name: "Bo3", likesCarrots: true);
                 * */
                throw new System.NotImplementedException ();
            }

            /// <exception cref="IOException">An I/O error occurred. </exception>
            public static void TstSentence () {
                Sentence s = new Sentence ();
                Console.WriteLine (s[3]); // fox
                s[3] = "kangaroo";
                Console.WriteLine (s[3]); // kangaroo
            }

            /// <exception cref="IOException">An I/O error occurred. </exception>
            public static void Execute () {
                TstSentence ();
            }

            private static void Foo (out int y) {
                Console.WriteLine (_x); // x is 0
                y = 1; // Mutate y
                Console.WriteLine (_x); // x is 1
            }

            private static void Foo (int x = 23) {
                Console.WriteLine (x);
            }

            private static void Foo2 (int x = 0, int y = 0) {
                Console.WriteLine (x + ", " + y);
            }

            private static void Bar (int a = 0, int b = 0, int c = 0, int d = 0) {
                Console.WriteLine (a + ", " + b + ", " + c + ", " + d);
            }

            private static int Sum (params int[] ints) {
                int sum = 0;
                for (int i = 0; i < ints.Length; i++)
                    sum += ints[i]; // Increase sum by ints[i]
                return sum;
            }

            private class A
            {
                public void Test (int n) {
                    Console.WriteLine ("A");
                }
            }

            private class B : A
            {
                public void Test (double n) {
                    Console.WriteLine ("B");
                }
            }

            private static void Tst5 () {
                B b = new B ();
                b.Test (5);
            }

            public class Bunny
            {
                private string _name;
                private bool _likesCarrots;
                private bool _likesHumans;
                private int _age;

                private int Age {
                    get { return _age; }
                    set { _age = value; }
                }

                private string _sex;

                protected string Sex {
                    get { return _sex; }
                    private set { _sex = value; }
                }

                public Bunny () {}

                public Bunny (string n) {
                    _name = n;
                }

                public Bunny (string name, bool likesCarrots = false, bool likesHumans = false) {
                    this._name = name;
                    this._likesCarrots = likesCarrots;
                    this._likesHumans = likesHumans;
                }

                protected string Name {
                    get { return _name; }
                    set { _name = value; }
                }

                public bool LikesCarrots {
                    get { return _likesCarrots; }
                    private set { _likesCarrots = value; }
                }

                public virtual bool LikesHumans {
                    get { return _likesHumans; }
                    set { _likesHumans = value; }
                }
            }

            private class Sentence
            {
                private string[] _words = "The quick brown fox".Split ();

                public string this [int wordNum] {
                    // indexer
                    get { return _words[wordNum]; }
                    set { _words[wordNum] = value; }
                }
            }
        }
    }
}