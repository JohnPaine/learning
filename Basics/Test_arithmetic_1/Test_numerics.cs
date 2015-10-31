using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_arithmetic_1
{
    class Test_numerics
    {
        static void split(string name, out string firstName, out string lastName)
        {
            int i = name.LastIndexOf(' ');
            firstName = name.Substring(0, i);
            lastName = name.Substring(i + 1);
        }

        static void tst1()
        {
            int a0 = (int)1E07;
            int a1 = (int)1E07;
            try
            {
                int a3 = checked((int)(a0 * a1));      //overflow checking
                int b3 = unchecked(int.MaxValue + 1);
                unchecked                           //wont be any exception
                {
                    int c3 = a0 * a1;
                }
                float tenth = 0.1f;
                float one = 1f;
                Console.WriteLine(one - tenth * 10f);
                decimal m = 1M / 6M;
                double d4 = 1.0 / 6.0;
                Console.WriteLine("m = {0}, d = {1}", m, d4);
                int[][] jaggedArray = new int[][] {
                    new int[] {0,1,2},
                    new int[] {3,4,5},
                    new int[] {6,7,8,9},
                };
                int[,] matrix1 = new int[5, 5];
                var matrix2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
                for (int i1 = 0; i1 < matrix2.GetLength(0); ++i1)
                {
                    for (int j1 = 0; j1 < matrix2.GetLength(1); j1++)
                    {
                        matrix2[i1, j1] = i1 * 3 + j1;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void tst2()
        {
            #region Test
            int k2 = 1;
            switch (k2)
            {
                case 0:
                case 1: Console.WriteLine("Case 1");
                    break;
                case 2:
                default:
                    Console.WriteLine("dfvg");
                    break;
            }


            ArrayList list = new ArrayList();
            list.Add(new object());
            list.Add(new Exception());
            list.Add(new Random().Next(10));
            list.Add(new ArrayList());

            double i5; int j5;
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
            long l = u * i;


            int a = 0;
            decimal b = 0;
            double c = 0.0;

            Console.WriteLine((a == b));
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a == c);
            Console.WriteLine(a.Equals(c));

            Func<int> d;
            d = () => 0;
            d += () => 1;
            d += () => 2;
            int b2 = d();
            Console.WriteLine(b2);


            int k = 1;
            Console.WriteLine(k++ + ++k);
            #endregion
        }

        static void tst3()
        {
            #region Outs and refs

            string firstName, lastName;
            split("John Michael Paine", out firstName, out lastName);
            Console.WriteLine(firstName + '\n' + lastName);

            #endregion
        }

        class Test
        {
            static int x;

            static void tst1()
            {
                Foo(out x);

                int total = Sum(1, 2, 3, 4);
                int total2 = Sum(new int[] { 1, 2, 3, 4 });
                Console.WriteLine(total);
            }

            static void tst2()
            {
                int j = 0;
                for (int i = 0; i < 10; i++)
                    j = j++;
                Console.WriteLine(j);
            }

            static void tst3()
            {
                int end = int.MaxValue;
                int begin = end - 100;
                int counter = 0;

                Console.WriteLine(int.MaxValue);

                for (int i = begin; i <= end; i++)
                    counter++;

                Console.WriteLine(counter);
            }

            static void tst4()
            {
                Foo();
                Foo(2);
                Foo(x);
                Foo(out x);

                Foo2(x: 2, y: 5);
                Foo2(y: 4, x: 7);

                int a = 0;
                Foo2(y: ++a, x: --a);   // ++a is evaluated first
                Foo2(1, y: 2);
                //Foo2(x: 1, 2);        // Compile-time error

                Bar(c: 4);
            }

            static void tstBunny()
            {
                /*      //if these fields are public!
                var b1 = new Bunny { name = "Bo1", likesCarrots = true, likesHumans = false };
                var b2 = new Bunny("Bo2") { likesCarrots = true, likesHumans = false };
                var b3 = new Bunny(name: "Bo3", likesCarrots: true);
                 * */
            }

            static void tstSentence()
            {
                Sentence s = new Sentence();
                Console.WriteLine(s[3]); // fox
                s[3] = "kangaroo";
                Console.WriteLine(s[3]); // kangaroo
            }

            public static void Execute()
            {
                tstSentence();
            }
            static void Foo(out int y)
            {
                Console.WriteLine(x); // x is 0
                y = 1; // Mutate y
                Console.WriteLine(x); // x is 1
            }

            static void Foo(int x = 23)
            {
                Console.WriteLine(x);
            }

            static void Foo2(int x = 0, int y = 0)
            {
                Console.WriteLine(x + ", " + y);
            }

            static void Bar(int a = 0, int b = 0, int c = 0, int d = 0)
            {
                Console.WriteLine(a + ", " + b + ", " + c + ", " + d);
            }

            static int Sum(params int[] ints)
            {
                int sum = 0;
                for (int i = 0; i < ints.Length; i++)
                    sum += ints[i]; // Increase sum by ints[i]
                return sum;
            }

            class A { public void Test(int n) { Console.WriteLine("A"); } }
            class B : A { public void Test(double n) { Console.WriteLine("B"); } }
            static void tst5()
            {
                B b = new B();
                b.Test(5);
            }

            public class Bunny
            {
                private string name;
                private bool likesCarrots;
                private bool likesHumans;
                private int age;

                private int Age
                {
                    get { return age; }
                    set { age = value; }
                }

                private string sex;

                protected string Sex
                {
                    get { return sex; }
                    private set { sex = value; }
                }

                public Bunny() { }
                public Bunny(string n) { name = n; }
                public Bunny(string name, bool likesCarrots = false, bool likesHumans = false)
                {
                    this.name = name;
                    this.likesCarrots = likesCarrots;
                    this.likesHumans = likesHumans;
                }

                protected string Name
                {
                    get { return name; }
                    set { name = value; }
                }

                public bool LikesCarrots
                {
                    get { return likesCarrots; }
                    private set { likesCarrots = value; }
                }

                public virtual bool LikesHumans
                {
                    get { return likesHumans; }
                    set { likesHumans = value; }
                }
            }

            class Sentence
            {
                string[] words = "The quick brown fox".Split();
                public string this[int wordNum]
                {      // indexer
                    get { return words[wordNum]; }
                    set { words[wordNum] = value; }
                }
            }
        }
    }
}
