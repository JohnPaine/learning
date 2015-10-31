using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArithmetic
{
    class TestInheritance
    {
        public static void Run_Tests() {
            //tstInheritance1();
            //tstHiding();
            tstFlags();
        }

        class Foo3_1
        {
            public static int X = Y; // 0
            public static int Y = 3; // 3
        }

        class Foo3_2
        {
            public static int Y = 3; // 3
            public static int X = Y; // 3
        }

        class Foo3_3
        {
            public static Foo3_3 Instance = new Foo3_3();
            public static int X = 3;
            Foo3_3() { Console.WriteLine(X); } // 0
        }

        class Foo3_4
        {
            public static int X = 3;
            public static Foo3_4 Instance = new Foo3_4();
            Foo3_4() { Console.WriteLine(X); } // 3
        }

        static class Foo3_5     //consists only of static members!!! Cannot be subclassed!!!
        {
            public static int X = 3;
            public static int Y = Foo3_4.X;

            static Foo3_5() {}    //only static constructor! no modifiers!
        }

        public class Asset
        {
            public string Name;

            public void Display()
            {
                Console.WriteLine(Name);
            }

            public virtual decimal Liability { get { return 0; } }
        }

        public class Stock : Asset // inherits from Asset
        {
            public long SharesOwned;

            public void Display()
            {
                Console.WriteLine(Name + ", SharesOwned = " + SharesOwned);
            }
        }

        public class House : Asset // inherits from Asset
        {
            public decimal Mortgage;

            public void Display()
            {
                Console.WriteLine(Name + ", Mortgage = " + Mortgage);
            }

            public override decimal Liability { get { return Mortgage; } }
        }

        static void tstInheritance1()
        {
            Stock stock = new Stock { Name = "MSFT", SharesOwned = 1500 };
            House house = new House { Name = "SAS", Mortgage = 2300 };

            stock.Display();
            house.Display();

            //Upcasting
            Stock stock2 = new Stock();
            Asset asset = stock2;

            Console.WriteLine((asset == stock2 ? "asset == stock2!" : "asset != stock2!"));
            //asset.SharesOwned;     - yet Stock fields aren't accessible!!!

            //To access Stock fields DOWNCASTING is needed!!
            Stock stock3 = (Stock) asset;

            Console.WriteLine(stock3.SharesOwned);      // <No error>
            Console.WriteLine(stock3 == asset);         // True
            Console.WriteLine(stock3 == stock2);        // True

            //AS operator
            Asset a = new Asset();
            Stock s = a as Stock; // s is null; no exception thrown

            try {
                long shares1 = ((Stock)a).SharesOwned; // Approach #1
            }
            catch (InvalidCastException ice) {
                Console.WriteLine(ice.ToString());
            }

            if (s != null) {
                Console.WriteLine(s.SharesOwned);
                long shares2 = (a as Stock).SharesOwned; // Approach #2
            }

            /*  
             *  Another way of looking at it is that with the cast operator (Approach #1), you’re
                saying to the compiler: “I’m certain of a value’s type; if I’m
                wrong, there’s a bug in my code, so throw an exception!”
                Whereas with the as operator (Approach #2), you’re uncertain of its type and
                want to branch according to the outcome at runtime.
             * */

            //IS operator
            if (a is Stock)
                Console.WriteLine(((Stock)a).SharesOwned);

            /*
             *  The is operator tests whether a reference conversion would succeed; in other words,
                whether an object derives from a specified class (or implements an interface). It is
                often used to test before downcasting. 
             * */
        }

        public abstract class Asset2
        {
            // Note empty implementation
            public abstract decimal NetValue { get; }

            public void Display() { Console.WriteLine("abstract Display");}

            public abstract void Display(string str);

            public virtual void Display(string str, int times) { }
        }
        public class Stock2 : Asset2
        {
            public long SharesOwned;
            public decimal CurrentPrice;

            // Override like a virtual method.
            public override decimal NetValue
            {
                get { return CurrentPrice * SharesOwned; }
            }

            public override void Display(string str) {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        ///  Hiding Inherited Members
        /// </summary>
        public class A { public int Counter = 1; }

        //The new modifier does nothing more than suppress the compiler warning that the duplicate member is not an accident.
        public class B : A { public new int Counter = 2; }

        public class BaseClass
        {
            public virtual void Foo() { Console.WriteLine ("BaseClass.Foo"); }
        }
        public class Overrider : BaseClass
        {
            public override void Foo() { Console.WriteLine ("Overrider.Foo"); }
        }

        public class Hider : BaseClass
        {
            public new void Foo() { Console.WriteLine("Hider.Foo"); }
        }

        static void tstHiding() {
            //The differences in behavior between Overrider and Hider are demonstrated in the following code:
            Overrider over = new Overrider();
            BaseClass b1 = over;

            over.Foo(); // Overrider.Foo
            b1.Foo(); // Overrider.Foo

            Hider h = new Hider();
            BaseClass b2 = h;

            h.Foo(); // Hider.Foo
            b2.Foo(); // BaseClass.Foo
        }

        [Flags]
        public enum BorderSides
        {
            None = 0, Left = 1, Right = 2, Top = 4, Bottom = 8,
            LeftRight = Left | Right,
            TopBottom = Top | Bottom,
            All = LeftRight | TopBottom
        }

        static bool IsFlagDefined(Enum e)
        {
            decimal d;
            return !decimal.TryParse(e.ToString(), out d);
        }

        static void tstFlags() {
            var leftRight = BorderSides.Left | BorderSides.Right;
            Console.WriteLine(leftRight.ToString());
            leftRight ^= BorderSides.Right;
            Console.WriteLine(leftRight.ToString());

            for (var i = 0; i <= 16; i++)
            {
                var side = (BorderSides)i;
                Console.WriteLine(IsFlagDefined(side) + " " + side);
            }
        }

        
    }
}
