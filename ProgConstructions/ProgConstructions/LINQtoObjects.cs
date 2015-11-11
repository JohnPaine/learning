using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal static class LinqToObjects
    {
        public static void RunTests() {
            //SimpleQueries();

            //SimpleQueries2();

            MSDNExample1();
        }

        private static void MSDNExample1() {
            string sentence = "the quick brown fox jumps over the lazy dog";
            // Split the string into individual words to create a collection.
            string[] words = sentence.Split(' ');

            // Using query expression syntax.
            var query = from word in words
                group word.ToUpper() by word.Length
                into gr
                orderby gr.Key
                select new {Length = gr.Key, Words = gr};

            // Using method-based query syntax.
            var query2 = words.
                GroupBy(w => w.Length, w => w.ToUpper()).
                Select(g => new {Length = g.Key, Words = g}).
                OrderBy(o => o.Length);

            foreach (var obj in query) {
                Console.WriteLine("Words of length {0}:", obj.Length);
                foreach (string word in obj.Words) {
                    Console.WriteLine(word);
                }
            }
        }

        private static void SimpleQueries2() {
            var cars = new List<Car> {
                new Car {CarName = "Opel", MaxSpeed = 240},
                new Car {CarName = "BMW", MaxSpeed = 260},
                new Car {CarName = "BMW", MaxSpeed = 220},
                new Car {CarName = "Audi", MaxSpeed = 250}
            };
            Console.WriteLine("*** Whole cars:***");
            cars.PrintCollection();
            Console.WriteLine("*** Fast cars:***");
            GetFastCars(cars).PrintCollection();
            Console.WriteLine("*** Fast BMWs:***");
            GetFastBMWs(cars).PrintCollection();

            // BUT!!!
            // Non-generic collections (such as ArrayList) are not compatible with IEnumerable interface
            // that is needed for LINQ queries!
            // so we need to transform them!!!
            // that also because such containers can contain any type of data!!!
            var carList = new ArrayList {
                new Car {CarName = "Opel", MaxSpeed = 240},
                new Car {CarName = "BMW", MaxSpeed = 260},
                new Car {CarName = "BMW", MaxSpeed = 220},
                new Car {CarName = "Audi", MaxSpeed = 250},
                // non-Car objects wont appear in casted list
                new object(),
                new Point {X = 2, Y = 3},
                false,
                42
            };

            Console.WriteLine("*** ArrayList collection:***");
            // casting (filtering) to IEnumerable<Car>
            GetFastCars(carList.OfType<Car>()).PrintCollection();
        }

        private static List<Car> GetFastCars(IEnumerable<Car> cars) {
            return (from car in cars where car.MaxSpeed > 240 select car).ToList();
        }

        private static List<Car> GetFastBMWs(IEnumerable<Car> cars)
        {
            return (from car in cars where car.MaxSpeed > 240 && car.CarName == "BMW" select car).ToList();
        }

        private static void SimpleQueries() {
            string[] games = {"GTA V", "DOTA 2", "Mortal Kombat X", "Skyrim", "Bioshock"};

            IEnumerable<string> subset = from game in games where game.Contains(" ") orderby game select game;

            subset.PrintCollection();

            int[] numbers = {1, 2, 3, 4, 5, 6, 64, 56};

            var subInts = from number in numbers where number < 10 select number;

            // ALSO! Linq is performed only when array is beeing addressed!!!
            // This means that we can perform any? operation with that array after query itself
            // and query will be performed again!

            // BUT this code will prevent subInts array from changes!!!! :
            //var enumerable = subInts as int[] ?? subInts.ToArray();
            //enumerable.PrintCollection();

            subInts.PrintCollection();

            // changing original array will change the resulting array
            // because linq query is performed when array is addressed!
            numbers[0] = 12;
            numbers[1] = 7;

            // resulting array is changed!!!!
            subInts.PrintCollection();

            //enumerable.PrintCollection();


            // BECAUSE!!! If we call any IEnumerable method on array IN linq query
            // query operation will be performed immediately!!

            int[] numbers2 = {12, 13, 14, 15, 64, 5, 67, 8, 9, 789, 78};
            var subInts2 = (from number in numbers2 where number < 20 select number).ToArray(); // or ToList() ...

            subInts2.PrintCollection();

            // NOW changes in original array doesn't affect resulting array!!!
            numbers2[0] = 25;

            // resulting array is the same!
            subInts2.PrintCollection();
        }
    }
}
