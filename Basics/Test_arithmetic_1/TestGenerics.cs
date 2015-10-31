using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_arithmetic_1
{
    class TestGenerics
    {
        public static void Run_Tests()
        {
            test_1();
        }

        public interface IComparable<in T>  //in means that T can only be input parameter, not output!
        {
            int CompareTo(T other);
            //const T getT() const;     - can't return type T because of in keyword!!
        }

        public interface IPoppable<out T>   //The out modifier on T indicates that T is used only 
                                            //in output positions (e.g., return types for methods).
        {
            T Pop();
        }

        public class Stack<T>
        {
            private int position;
            private T[] data = new T[100];
            public static int Count;
            public void Push(T obj) {
                data[position++] = obj;
            }

            public T pop() {
                return data[--position];
            }

            static T Max<T>(T a, T b) where T : IComparable<T> {
                return a.CompareTo(b) > 0 ? a : b;
            }

            static void Initialize<T>(T[] array) where T : new()
            {
                for (int i = 0; i < array.Length; i++)
                    array[i] = new T();
            }
        }

        /*
        private class GenericClass<T, U>    where T : SomeClass, Interface1
                                            where U : new()
        {}
        */

        class Animal { }
        class Bear : Animal { }
        class Camel : Animal { }

        /*
        public class ZooCleaner
        {
            public static void Wash(Stack<Animal> animals) {...}
        }
         */
        class ZooCleaner
        {
            public static void Wash<T>(Stack<T> animals) where T : Animal {
                Console.WriteLine("Washing " + animals.ToString());
            }
        }


        static void test_1() {
            Console.WriteLine(++Stack<int>.Count); // 1
            Console.WriteLine(++Stack<int>.Count); // 2
            Console.WriteLine(++Stack<string>.Count); // 1
            Console.WriteLine(++Stack<object>.Count); // 1
        }

        static void test_covariance() {
            Stack<Bear> bears = new Stack<Bear>();
            ZooCleaner.Wash(bears);
            //Stack<Animal> animals = bears; // Compile-time error

            Bear[] bears2 = new Bear[3];
            Animal[] animals = bears2; // OK

            animals[0] = new Camel(); // Runtime error
        }
        

        

        
    }
}
