using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal static class Delegates
    {
        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="FormatException">Заданная в параметре <paramref name="format" /> спецификация формата недопустима. </exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="format" /> имеет значение null. </exception>
        public static void RunTests () {
            try {
                //SimpleExample ();
                //SimpleDelegates ();

                Car car1 = new Car ();
                car1.AboutToBlow += OnCarEngineEvent;
                car1.Exploded += OnCarEngineEvent;
                car1.AboutToBlow +=
                    delegate { Console.WriteLine ("Anonymous method says - you are going too fast!!!"); };
                car1.AboutToBlow +=
                    delegate (object sender, CarEventArgs eventArgs) {
                        Console.WriteLine ("Anonymous method from sender {0} says - {1}", sender.GetType ().Name,
                                           eventArgs.msg);
                    };
                car1.Exploded += (sender, e) => { Console.WriteLine ("Exploded slot with lambda says - " + e.msg); };

                for (int i = 0; i < 11; i++) {
                    car1.Accelerate (10);
                }
            }
            catch (IOException e) {
                Console.WriteLine (e);
            }
        }

        private static void OnCarEngineEvent (object sender, CarEventArgs e) {
            Console.WriteLine ("***** Message from car *****");
            Console.WriteLine ("\t{0} says => {1}", sender.GetType ().Name, e.msg);
            Console.WriteLine ("****************************\n");
        }

        private static void SimpleDelegates () {
            Car car1 = new Car ();
            car1.RegisterWithCarEngine (OnCarEngineEvent);
            car1.UnRegisterWithCarEngine (OnCarEngineEvent);
            car1.RegisterWithCarEngine (OnCarEngineEvent);
            for (int i = 0; i < 11; i++) {
                car1.Accelerate (10);
            }
        }

        private static void SimpleExample () {
            BinaryOp b = new BinaryOp (SimpleMath.Add);
            Console.WriteLine ("{0} + {1} = {2}", 10, 15, b (10, 15));
            b = new BinaryOp (SimpleMath.Substract);
            Console.WriteLine ("{0} - {1} = {2}", 25, 15, b (25, 15));
        }

        private delegate int BinaryOp (int x, int y);

        private class SimpleMath
        {
            public static int Add (int x, int y) {
                return x + y;
            }

            public static int Substract (int x, int y) {
                return x - y;
            }
        }
    }
}