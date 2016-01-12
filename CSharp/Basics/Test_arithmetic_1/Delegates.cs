using System;
using System.Globalization;

namespace Test_arithmetic_1
{
    internal class Delegates
    {
        public static void Run_Tests () {
            //test_1();
            //test_2();
            //test_3();
            test_4 ();
        }

        private delegate int Transformer (int x);

        private delegate void Printer (string toPrint);

        private delegate void ProgressReporter (int percentComplete);

        private static int Square (int x) {
            return x*x;
        }

        private static int Cube (int x) {
            return x*x*x;
        }

        private static void printSmth_1 (string str) {
            Console.WriteLine (str + " And here goes something about method 1!");
        }

        private static void printSmth_2 (string str) {
            Console.WriteLine (str + " And here goes something about method 2!");
        }

        private static void HardToil (ProgressReporter pr) {
            for (var i = 0; i < 10; ++i) {
                pr (i*10); //Invoke delegate
                System.Threading.Thread.Sleep (100); //Simulate hard work
            }
        }

        private static void WriteProgressToConsole (int percent) {
            Console.WriteLine ("Work completion - {0}", percent);
        }

        private static void WriteProgressToFile (int percent) {
            System.IO.File.AppendAllText ("progress.txt",
                                          "Work completion - " + percent.ToString (CultureInfo.InvariantCulture) + "\n");
        }

        private class X
        {
            public void InstanceProgress (int percentComplete) {
                Console.WriteLine (percentComplete);
            }
        }

        public delegate T Transformer2<T> (T arg);

        public delegate TResult Func<in T, out TResult> (T arg);

        public delegate TResult Func<out TResult> ();

        public delegate void Action<in T> (T arg);

        public class Util
        {
            public static void Transform<T> (T[] values, Transformer2<T> tr) {
                for (var i = 0; i < values.Length; ++i) {
                    values[i] = tr (values[i]);
                }
            }

            public static void Transform_func<T> (T[] values, Func<T, T> transformer) {
                for (var i = 0; i < values.Length; ++i) {
                    values[i] = transformer (values[i]);
                }
            }
        }

        private static void test_1 () {
            Transformer t = Square;
            Console.WriteLine ("{0}^2 = {1}", 4, t (4));
            t = Cube;
            Console.WriteLine ("{0}^3 = {1}", 4, t (4));

            Printer p = printSmth_1;
            p += printSmth_2;
            //            Delegate[] delegates = p.GetInvocationList();
            p ("Here goes printing string!\n");

            ProgressReporter pr = WriteProgressToConsole;
            pr += WriteProgressToFile;
            System.IO.File.WriteAllText ("progress.txt", ""); //cleaning progress.txt
            HardToil (pr);

            X x = new X ();
            ProgressReporter pr2 = x.InstanceProgress;
            pr2 (99); // 99
            Console.WriteLine (pr2.Target == x); // True
            Console.WriteLine (pr2.Method); // Void InstanceProgress(Int32)
        }

        public static string StringRevealer () {
            return "some string";
        }

        public static void StringPrinter (object o) {
            Console.WriteLine (o);
        }

        private static void test_2 () {
            int[] values = {1, 2, 3};
            Util.Transform (values, Square);
            Console.WriteLine ("Squares:");
            foreach (var i in values)
                Console.WriteLine (i + " ");
            Util.Transform_func (values, Cube);
            Console.WriteLine ("Cubes:");
            foreach (var i in values)
                Console.WriteLine (i + " ");
        }

        private static void test_3 () {
            System.Func<string> x = StringRevealer;
            System.Func<object> y = x; //covariance
            Console.WriteLine (y ());

            System.Action<object> x2 = StringPrinter;
            System.Action<string> y2 = x2; //contravariance
            y2 ("hello!");
        }

        public delegate void PriceChangedHandler (decimal oldPrice, decimal newPrice);

        /*
        public event PriceChangedHandler PriceChanged;
        
        protected virtual void OnPriceChanged(decimal oldprice, decimal newprice) {
            PriceChangedHandler handler = PriceChanged;
            if (handler != null) {
                handler(oldprice, newprice);
            }
        }
         * */

        public class PriceChangedEventArgs : System.EventArgs
        {
            public readonly decimal LastPrice;
            public readonly decimal NewPrice;

            public PriceChangedEventArgs (decimal lastPrice, decimal newPrice) {
                LastPrice = lastPrice;
                NewPrice = newPrice;
            }
        }

        public delegate void EventHandler<in TEventArgs> (object source, TEventArgs e) where TEventArgs : EventArgs;

        public class Stock
        {
            private string _symbol;
            private decimal _price;

            public Stock (string symbol) {
                this._symbol = symbol;
            }

            /*
            public event PriceChangedHandler PriceChanged;
            */

            public decimal Price {
                get { return _price; }
                set {
                    if (value == _price) //exit if nothing has changed
                        return;
                    decimal oldPrice = _price;
                    _price = value;
                    /*
                    if (PriceChanged != null)           //if invocation list not empty, fire event!
                        PriceChanged(oldPrice, _price);
                     * */
                    OnPriceChanged (this, new PriceChangedEventArgs (oldPrice, _price));
                }
            }

            //another way!
            public event EventHandler<PriceChangedEventArgs> PriceChanged;

            protected virtual void OnPriceChanged (object source, PriceChangedEventArgs e) {
                EventHandler<PriceChangedEventArgs> handler = PriceChanged;
                //                if (handler != null) {
                //                    handler(source, e);
                //                }
                //                the same as
                try {
                    handler?.Invoke (source, e);
                }
                catch (Exception exception) {
                    // ignored
                }
            }
        }

        private static void stock_PriceChanged (object sender, PriceChangedEventArgs e) {
            if ((e.NewPrice - e.LastPrice)/e.LastPrice > 0.1M) {
                Console.WriteLine ("Alert! 10% stock price increase!");
            }
        }

        private static void test_4 () {
            var stock = new Stock ("THPW") {Price = 27.10M};
            //register with PriceChanged event
            stock.PriceChanged += stock_PriceChanged;
            stock.Price = 31.59M;
        }
    }
}