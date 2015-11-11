using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal class Point : ICloneable
    {
        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="ArgumentNullException">Значение параметра <paramref name="source" /> или <paramref name="func" /> — null.</exception>
        public static void RunTests () {
            try {
                Point p1 = new Point {X = 1, Y = 2, Z = 3};

                // there are now overloads for ++operator as in c++, BUT!
                // p1++ returns unmodified p1 and apply ++ operation after that,
                // when ++p1 returns already modified p1 with ++ operation
                Console.WriteLine ("\tp1++ = \t{0},\n\tp1 = \t{1}", p1++, p1);
                Console.WriteLine ("\t++p1 = \t{0},\n\tp1 = \t{1}", ++p1, p1);
            }
            catch (IOException e) {
                Console.WriteLine (e);
            }
        }

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
            Console.WriteLine ("Point destructor for points - {0}", ToString ());
        }

        public object Clone () {
            // if class doesn't contain reference type members (other class objects)
            // than it can be cloned by MemberwiseClone() method,
            // which clones ValueType objects
            return MemberwiseClone ();
        }

        public Point (int x, int y, int z) {
            Console.WriteLine ($"Point ctor with x = {x}, y = {y} and z = {z}");
            X = x;
            Y = y;
            Z = z;
            Pi2 = 3.142;
        }

        public static Point operator + (Point p1, Point p2) {
            return new Point {X = p1.X + p2.X, Y = p1.Y + p2.Y, Z = p1.Z + p2.Z};
        }

        public static Point operator + (Point p1, int change) {
            return new Point {X = p1.X + change, Y = p1.Y + change, Z = p1.Z + change};
        }

        public static Point operator + (int change, Point p1) {
            return new Point {X = p1.X + change, Y = p1.Y + change, Z = p1.Z + change};
        }

        public static Point operator - (Point p1, Point p2) {
            return new Point {X = p1.X - p2.X, Y = p1.Y - p2.Y, Z = p1.Z - p2.Z};
        }

        public static Point operator - (Point p1, int change) {
            return new Point {X = p1.X - change, Y = p1.Y - change, Z = p1.Z - change};
        }

        public static Point operator - (int change, Point p1) {
            return new Point {X = p1.X - change, Y = p1.Y - change, Z = p1.Z - change};
        }

        // there are now overloads for ++operator as in c++, BUT!
        // p1++ returns unmodified p1 and apply ++ operation after that,
        // when ++p1 returns already modified p1 with ++ operation
        public static Point operator ++ (Point p1) {
            return new Point {X = p1.X + 1, Y = p1.Y + 1, Z = p1.Z + 1};
        }
    }
}