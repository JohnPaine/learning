using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    static class Extensions
    {
        public static void RunTests() {
            const int i = 123456;
            i.DisplayDefiningAssembly();
            var rI = i.ReverseDigits();
            Console.WriteLine("i = {0} was changed to - {1}", i, rI);

            var d = new DataSet();
            d.DisplayDefiningAssembly();

            var sp = new SoundPlayer();
            sp.DisplayDefiningAssembly();

            var list = new List<int> {1,2,3,4};
            list.PrintCollection();
        }

        // allows to display defining assembly for any object
        public static void DisplayDefiningAssembly(this object obj) {
            Console.WriteLine("{0} lives here -> {1}\n", obj.GetType().Name,
                Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        // allows to reverse order of digits for any int:
        // for exmaple, 561 is changed to 165
        public static int ReverseDigits(this int i) {
            char[] digits = i.ToString().ToCharArray();

            Array.Reverse(digits);

            var newDigits = new string(digits);

            return int.Parse(newDigits);
        }

        public static void PrintCollection(this IEnumerable iterator) {
            Console.WriteLine("Printing iterator items in extension method for type - {0}", iterator.GetType().Name);
            foreach (var item in iterator) {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
