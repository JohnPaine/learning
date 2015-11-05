using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    // static classes cannot be instantiated!
    // internal classes are accessible only in current build
    internal static class Classes
    {

        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        public static void RunTests () {
            try {
                //SomeFun ();
                //FunWithPoints ();

                Rectangle r = new Rectangle {
                    TopLeft = new Point {X = 1, Y = 2, Z = 3},
                    BotRight = new Point { X = 4, Y = 5, Z = 6}
                };
                Console.WriteLine("Rectangle r = {0}", r.ToString ());
            }
            catch (IOException e) {
                Console.WriteLine (e);
            }
        }

        private static void FunWithPoints () {
            // object initialization
            // sort of std::initializer_list
            Point point1 = new Point {Y = 2, X = 1, Z = 3};
            Console.WriteLine ("\t point1 coordinates - {0}", point1.ToString ());

            // here we call defined ctor! but point will be initialized with 10,11,12 values!!!
            Point point2 = new Point (4, 5, 6) {X = 10, Y = 11, Z = 12};
            Console.WriteLine ("\t point2 coordinates - {0}", point2.ToString ());
        }

        private static void SomeFun () {
            Console.WriteLine ("** c1 var ***");
            FunWithConstructors c1 = new FunWithConstructors ("param pam pam");
            Console.WriteLine (FunWithConstructors.SomeStaticInt);

            Console.WriteLine ("** c2 var (int) ***");
            FunWithConstructors c2 = new FunWithConstructors (16);
            Console.WriteLine (FunWithConstructors.SomeStaticInt);

            Console.WriteLine (c2.Name);
            c2.Name = "Booba";
            Console.WriteLine (c2.Name);
            c2.Name = "Booba mazza fucka' bitch yobana nahuy bleat'!!1! !1";

            var c3 = new FunWithConstructors ("Bazooka", 27);
        }

        private class Rectangle
        {
            public Point TopLeft { get; set; }/* = new Point ();*/
            public Point BotRight { get; set; }/* = new Point ();*/
            public override string ToString () {
                // using string interpolation!!!
                return $"Top left point -  {TopLeft.ToString ()},\n" +
                       $"Bottom right point - {BotRight.ToString ()}";
            }
        }

        private class Point
        {
            // const fields can only be initialized at declaration. Const fields are implicitly static!!!
            public const double Pi = 3.14;
            // readonly fields can be initialized later, but only in class ctor!!! readonly fields are not implicitly static!!!
            public readonly double Pi2;
            // but they can be static
            public static readonly double Pi3 = 3.14159;
            // and also static readonly fields can be initialized later too, but only in static ctor!!
            public static readonly double Pi4;

            public int X { get; set; } = 0;
            public int Y { get; set; } = 0;
            public int Z { get; set; } = 0;

            public override string ToString () {
                // using string interpolation!!!
                return $"X = {X}, Y = {Y}, Z = {Z}";
            }

            static Point () {
                // static readonly field can be initialized later only in static ctor!!
                Pi4 = 3.14159265;
            }

            public Point () {
                Pi2 = 3.142;
                Console.WriteLine ("Point Standard ctor!");
            }

            ~Point () {
                Console.WriteLine("Point destructor for points - {0}", ToString ());
            }

            public Point (int x, int y, int z) {
                Console.WriteLine ($"Point ctor with x = {x}, y = {y} and z = {z}");
                X = x; 
                Y = y;
                Z = z;
                Pi2 = 3.142;
            }
        }

        private class FunWithConstructors
        {
            private string _name;
            public static int SomeStaticInt { get; private set; }


            /// <exception cref="IOException" accessor="set">I/O exception occured. </exception>
            public string Name {
                get { return _name; }
                set {
                    if (value.Length > 20)
                        Console.WriteLine ("Name must be less than 21 characters!");
                    else
                        _name = value;
                }
            }

            /// <exception cref="IOException">I/O exception occured.  </exception>
            public FunWithConstructors () {
                Console.WriteLine ("FunWithConstructors()");
            }

            /// <exception cref="IOException">I/O exception occured. </exception>
            public FunWithConstructors (string name)
                : this (name, 0) {
                Console.WriteLine ("FunWithConstructors(string name)");
            }

            /// <exception cref="IOException">I/O exception occured. </exception>
            public FunWithConstructors (int someInt)
                : this ("", someInt) {
                Console.WriteLine ("FunWithConstructors(int someInt)");
            }

            /// <exception cref="IOException">I/O exception occured. </exception>
            public FunWithConstructors (string name, int someInt) {
                Console.WriteLine ("FunWithConstructors(string name, int someInt)");
                Name = name;
                SomeStaticInt = someInt;
            }

            // static constructor is called only once at first address to class
            static FunWithConstructors () {
                Console.WriteLine ("static FunWithConstructors ()");
                SomeStaticInt = 15;
            }
        }
    }
}