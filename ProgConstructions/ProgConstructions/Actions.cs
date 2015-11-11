using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal static class Actions
    {
        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public static void RunTests () {
            try {
                // actions may point only to methods with void return type!
                var display = new Action<string, ConsoleColor, int> (DisplayMessage);
                display ("Hello, actions!!!", ConsoleColor.DarkMagenta, 3);

                // to non-void return type functions we can use Func<...> !!!
                var sum = new Func<int, int, int> (Sum);
                display ($"{10} + {15} = {sum (10, 15)}", ConsoleColor.DarkYellow, 1);
            }
            catch (IOException e) {
                Console.WriteLine (e);
            }
        }

        private static void DisplayMessage (string msg, ConsoleColor txtColor, int printCount) {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++) {
                Console.WriteLine (msg);
            }
            Console.ForegroundColor = prevColor;
        }

        private static int Sum (int a, int b) {
            return a + b;
        }
    }
}