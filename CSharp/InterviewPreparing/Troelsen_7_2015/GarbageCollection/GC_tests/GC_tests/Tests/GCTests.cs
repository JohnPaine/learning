using System;
using System.Collections.Generic;
using System.Linq;
using GC_tests.Model;

namespace GC_tests.Tests
{
    public class GCTests
    {
        public static int ForceGarbageCollection() {
            var cars = new List<Car>();

            Console.WriteLine($"GC total memory BEFORE creating 50 objects - {GC.GetTotalMemory(false)}");

            for (var i = 0; i < 50; ++i) {
                cars.Add(new Car($"Car {i+1}", 50 + (i * 3), 0));
                Console.WriteLine($"{cars.Last()}");
            }

            Console.WriteLine($"GC total memory AFTER creating 50 objects but before forced collection - {GC.GetTotalMemory(false)}");

//            GC.Collect();
            // Only investigating generation 0 objects
            GC.Collect(0);
            // performing GC manually we should always call to GC.WaitForPendingFinalizers() !!!
            GC.WaitForPendingFinalizers();

            Console.WriteLine($"GC total memory AFTER creating 50 objects and AFTER forced collection - {GC.GetTotalMemory(false)}");

            return 0;
        } 
    }
}