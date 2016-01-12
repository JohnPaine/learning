using System;

namespace ProgConstructions
{
    internal class AnonymousTypes
    {
        public static void RunTests() {
            var myCar = new {Color = "Bright red", Make = "Opel", CurrentSpeed = 240};

            Console.WriteLine("My car is a {0} {1}.", myCar.Color, myCar.Make);

            BuildAnonType("BMW", "Black", 90);

            ReflectOverAnonType(myCar);
        }

        public static void BuildAnonType(string make, string color, int currSp) {
            var car = new {Make = make, Color = color, Speed = currSp};

            Console.WriteLine("You have a {0} {1} going {2} MPH", car.Color, car.Make, car.Speed);

            Console.WriteLine("ToString() = {0}", car);
        }

        public static void ReflectOverAnonType(object obj) {
            Console.WriteLine();
            Console.WriteLine("Obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() = {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() = {0}", obj.GetHashCode());
            Console.WriteLine();
        }
    }
}