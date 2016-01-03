using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal struct Rectangle : ICloneable
    {

        public static void RunTests() {
            ImplicitCasts();
        }

        private static void ImplicitCasts() {
            var square = new Square(4);
            Console.WriteLine(square.ToString());
            square.Draw();
            Console.WriteLine();
            Rectangle rectangle = square;
            Console.WriteLine(rectangle.ToString());
            rectangle.Draw();
            Console.WriteLine();
            rectangle = 3;
            Console.WriteLine(rectangle.ToString());
            rectangle.Draw();
            Console.WriteLine();
        }

        // if struct uses automatic properties standard ctor must be explicitly called from all special ctors - is this wrong???
        public Rectangle(int w, int h) /*: this()*/ {
            Width = w;
            Height = h;
            TopLeft = new Point();
            BotRight = new Point();
        }

        public Point TopLeft { get; set; } /* = new Point ();*/
        public Point BotRight { get; set; } /* = new Point ();*/

        public int Height { get; set; }
        public int Width { get; set; }

        public void Draw() {
            for (var i = 0; i < Height; ++i) {
                for (var j = 0; j < Width; ++j) {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static implicit operator Rectangle(Square s) {
            return new Rectangle(s.Length, s.Length);
        }

        public static implicit operator Rectangle(int length)
        {
            return new Rectangle(length, length);
        }

        public override string ToString() {
            // using string interpolation!!!
            return $"[Top left point -  {TopLeft.ToString()}\n" +
                   $"Bottom right point - {BotRight.ToString()}\n" +
                   $"Height - {Height}\n" +
                   $"Width - {Width}]\n";
        }

        public object Clone() {
            var rectangle = (Rectangle) MemberwiseClone();

            rectangle.TopLeft = (Point) TopLeft.Clone();
            rectangle.BotRight = (Point) BotRight.Clone();

            return rectangle;
        }
    }
}