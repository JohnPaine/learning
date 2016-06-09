using System;
using System.Collections.Generic;

namespace LINQ_to_objects_1.Utility
{
    public static class MyExtensions
    {
        public static int WordCount(this string src) {
            return src.Split(new[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
        
        public static void PrintEnumerable<T>(this IEnumerable<T> array) {
            foreach (var element in array) {
                Console.WriteLine($"{element}");
            }
        }

        public static void PrintArray(this Array array) {
            foreach (var data in array) {
                Console.WriteLine($"{data}");
            }
        }
    }
}