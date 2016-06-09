using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LINQ_to_objects_1.Utility;
using TestEvents_1.Model;

namespace LINQ_to_objects_1.Tests
{
    public static class LinqBasicTests
    {
        private static readonly string[] Games = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};

        public static int QueryOverStrings() {
            IEnumerable<string> subset1 = from game in Games where game.Contains(" ") orderby game select game;

            subset1.PrintEnumerable();

            return 0;
        }

        public static int QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

            // Get numbers less than ten.
            var subset = from i in numbers where i < 10 select i;

            // LINQ statement evaluated here!
            foreach (var i in subset)
                Console.WriteLine("{0} < 10", i);
            Console.WriteLine();
            // Change some data in the array.
            numbers[0] = 4;

            // Evaluated again!
            foreach (var j in subset)
                Console.WriteLine("{0} < 10", j);

            return 0;
        }

        public static int QueryOverArrayList() {
            var myCars = new ArrayList() {
                 new Car{ PetName = "Henry", Color = "Silver", MaxSpeed = 100, Make = "BMW"},
                 new Car{ PetName = "Daisy", Color = "Tan", MaxSpeed = 90, Make = "BMW"},
                 new Car{ PetName = "Mary", Color = "Black", MaxSpeed = 55, Make = "VW"},
                 new Car{ PetName = "Clunker", Color = "Rust", MaxSpeed = 5, Make = "Yugo"},
                 new Car{ PetName = "Melvin", Color = "White", MaxSpeed = 43, Make = "Ford"}
                 };

            var myCarsEnum = myCars.OfType<Car>();
            var fastCars = from c in myCarsEnum where c.MaxSpeed > 55 select c;

            fastCars.PrintEnumerable();


            return 0;
        }

        public static int OfTypeAsFilter() {
            var myStuff = new ArrayList();
            myStuff.AddRange(new object[] {15, false, new Car {PetName = "BMW", MaxSpeed = 260}, "str1", 559.3, 255, 42.0f, true, new Car("Toyouta", 230, 50) });

            var myInts = myStuff.OfType<int>();
            var myCars = myStuff.OfType<Car>();
            var myDoubles = myStuff.OfType<double>();
            var myFloats = myStuff.OfType<float>();
            var myBools = myStuff.OfType<bool>();

            myInts.PrintEnumerable();
            myCars.PrintEnumerable();
            myDoubles.PrintEnumerable();
            myBools.PrintEnumerable();
            myFloats.PrintEnumerable();


            return 0;
        }
    }
}