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

                FunWithRectangles ();
            }
            catch (IOException e) {
                Console.WriteLine (e);
            }
        }

        private static void FunWithRectangles () {
            var r = new Rectangle {
                TopLeft = new Point {X = 1, Y = 2, Z = 3},
                BotRight = new Point {X = 4, Y = 5, Z = 6},
                Height = 15,
                Width = 17
            };
            Console.WriteLine ("\nRectangle r:\n{0}\n", r.ToString ());

            var rClone = (Rectangle) r.Clone ();
            Console.WriteLine ("\nRectangle rClone:\n{0}\n", rClone.ToString ());
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