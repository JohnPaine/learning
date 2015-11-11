using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal static class Events
    {
        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public static void RunTests () {
            try {
                SomeClass c = new SomeClass {SomeString = "Some string"};
                c.Changed += DisplayMessage;
                c.Cleared += DisplayMessage;
                c.SomeString = "Some changed string";
                c.SomeString = "";
            }
            catch (IOException e) {
                Console.WriteLine (e);
            }
        }


        private static void DisplayMessage (string msg) {
            DisplayMessage (msg, ConsoleColor.Yellow, 1);
        }

        private static void DisplayMessage (string msg, ConsoleColor txtColor, int printCount) {
            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;

            for (int i = 0; i < printCount; i++) {
                Console.WriteLine (msg);
            }
            Console.ForegroundColor = prevColor;
        }

        private sealed class SomeClass
        {
            private string _someString;

            /// <exception cref="Exception" accessor="set">A delegate callback throws an exception.</exception>
            public string SomeString {
                get { return _someString; }
                set {
                    _someString = value;
                    if (0 == value.Length)
                        OnCleared ();
                    else
                        OnChanged ();
                }
            }

            public delegate void SomeStringHandler (string msg);

            public event SomeStringHandler Changed;
            public event SomeStringHandler Cleared;

            /// <exception cref="Exception">A delegate callback throws an exception.</exception>
            private void OnChanged (string msg = "String was changed!") {
                Changed?.Invoke ($"{msg}\nNew string - {SomeString}");
            }

            /// <exception cref="Exception">A delegate callback throws an exception.</exception>
            private void OnCleared () {
                Cleared?.Invoke ("String was cleared!");
            }
        }
    }
}