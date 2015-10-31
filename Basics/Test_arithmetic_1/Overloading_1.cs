using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_arithmetic_1
{
    class Overloading_1
    {
        public static void Run_Tests() {
            test_1();
        }

        public struct Note
        {
            private readonly int value;

            public Note(int semitonesFromA) {
                value = semitonesFromA;
            }

            public int Value { get { return value; } }

            public static Note operator +(Note x, int semitones) {
                return new Note(x.value + semitones);
            }

            //convert to Hertz
            public static implicit operator double(Note x) {
                return 440 * Math.Pow(2, (double) x.value / 12);
            }

            //convert from Hertz (accurate to the nearest semitone)
            public static explicit operator Note(double x) {
                return new Note((int) (0.5 + 12 * (Math.Log(x / 440) / Math.Log(2))));
            }
        }

        static void test_1() {
            Note n = (Note) 554.37; //explicit conversion
            double x = n;           //implicit conversion
            Console.WriteLine("n = {0}", n);
            Console.WriteLine("x = {0}", x);
        }
    }
}
