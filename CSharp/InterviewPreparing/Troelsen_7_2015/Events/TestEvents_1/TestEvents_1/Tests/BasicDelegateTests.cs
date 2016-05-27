using System;
using TestEvents_1.Model;

namespace TestEvents_1.Tests
{
    internal static class BasicDelegateTests
    {
        private static int Summ(int a, int b) {
            return a + b;
        }

        private static int Substract(int a, int b) {
            return a - b;
        }

        public static int Test_1() {
            var s = new BinaryOp(Substract);
            s += Summ;
            s += Substract;
            s += Summ;
            Console.WriteLine($"s(5,7) = {s(5, 7)}");
            s -= Summ;
            Console.WriteLine($"s(5,7) = {s(5, 7)}");

            return 0;
        }

        public static void OnCarEngineEvent(object sender, CarEventArgs e) {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=>{0}", e.Message);
            Console.WriteLine("***********************************\n");
        }

        public static void OnCarEngineEvent2(object sender, CarEventArgs e) {
            Console.WriteLine("=>{0}", e.Message.ToUpper());
        }

        public static void OnCarCurrentSpeed(int speed) {
            Console.WriteLine($"Current car speed => {speed}");
        }

        public static void OnCarName(string name)
        {
            Console.WriteLine($"Car name => {name}");
        }

        public static int Test_2() {
            Console.WriteLine("***** Delegates as event enablers *****\n");

            // First, make a Car object.
            var c1 = new Car("SlugBug", 100, 10);

            // Now, tell the car which method to call
            // when it wants to send us messages.
            c1.RegisterWithCarEngine(OnCarEngineEvent);
//            c1.RegisterWithCarEngine(OnCarEngineEvent2);
            c1.RegisterCarSpeedHandler(OnCarCurrentSpeed);
            c1.RegisterCarNameHandler(OnCarName);
            c1.AboutToExplode += OnCarEngineEvent;
//            c1.AboutToExplode += OnCarEngineEvent2;
            c1.Exploded += OnCarEngineEvent;
//            c1.Exploded += OnCarEngineEvent2;

            // operator "=" is available only from within Car class
//            c1.Exploded = OnCarEngineEvent;

            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            for (var i = 0; i < 10; i++) {
                Console.WriteLine($"i ->> {i}");
//                if (i > 5) {
//                    c1.UnregisterWithCarEngine(OnCarEngineEvent2);
//                }
                c1.Accelerate(20);
            }
            Console.ReadLine();

            return 0;
        }

        private delegate int BinaryOp(int a, int b);
    }
}