using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GC_tests.Model;

namespace GC_tests.Tests
{
    class GCInfos
    {
        public static int CommonGcInfo() {
            Console.WriteLine($"Estimated bytes on heap - {GC.GetTotalMemory(false)}");
            Console.WriteLine($"MaxGeneration - {GC.MaxGeneration}");
            var car = new Car();
            Console.WriteLine($"Generation of local Car object - {GC.GetGeneration(car)}");

            return 0;
        }
    }
}
