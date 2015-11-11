using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal class Rectangle : ICloneable
    {
        public Point TopLeft { get; set; } /* = new Point ();*/
        public Point BotRight { get; set; } /* = new Point ();*/

        public int Height { get; set; }
        public int Width { get; set; }

        public override string ToString () {
            // using string interpolation!!!
            return $"Top left point -  {TopLeft.ToString ()}\n" +
                   $"Bottom right point - {BotRight.ToString ()}\n" +
                   $"Height - {Height}\n" +
                   $"Width - {Width}\n";
        }

        public object Clone () {
            var rectangle = (Rectangle) MemberwiseClone ();

            rectangle.TopLeft = (Point) TopLeft.Clone ();
            rectangle.BotRight = (Point) BotRight.Clone ();

            return rectangle;
        }
    }
}