using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal struct Square
    {
        public static void RunTests() {
            ExplicitCasts();
        }

        private static void ExplicitCasts() {
            var r = new Rectangle(5, 7);
            Console.WriteLine(r.ToString());
            r.Draw();
            Console.WriteLine();
            var s = (Square) r;
            Console.WriteLine(s.ToString());
            s.Draw();
            Console.WriteLine();
            s = (Square) 3;
            Console.WriteLine(s.ToString());
            s.Draw();
            Console.WriteLine();
        }

        public int Length { get; set; }

        public Square(int length) : this() {
            Length = length;
        }

        public void Draw() {
            for (var i = 0; i < Length; ++i) {
                for (var j = 0; j < Length; ++j) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString() {
            return $"[Length = {Length}]";
        }

        public static explicit operator Square(Rectangle r) {
            return new Square { Length = r.Height };
        }
        public static explicit operator Square(int length)
        {
            return new Square { Length = length };
        }
    }
}