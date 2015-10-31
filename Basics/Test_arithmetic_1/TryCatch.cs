using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_arithmetic_1
{
    class TryCatch
    {
        public static void Run_Tests() {
            //System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            //test_1();
            test_2();
        }

        static void test_1() {
            Func<int, int, int> divide = (x, y) => x/y;
            try {                
                Console.WriteLine(divide(10, 0));
            }
            catch (DivideByZeroException ex) {
                Console.WriteLine("Divide by zero!");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) {
                Console.WriteLine("Any exception");
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReadFile(string fileName) {
            StreamReader reader = null;
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            try {
                reader = File.OpenText(fileName);
                if (reader.EndOfStream)
                    return;
                Console.WriteLine(reader.ReadToEnd());
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Final block also executed!");
                if(reader != null)
                    reader.Dispose();
            }
        }

        //more elgant way to do the same! Dispose is called automatically!
        public static void ReadFile2(string fileName) {
            if (fileName == null)
                throw new ArgumentNullException("fileName");
            try {
                using (StreamReader reader = File.OpenText(fileName)) {
                    if (reader.EndOfStream)
                        return;
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine(ex.Message);
                //Console.WriteLine("Rethrowing FileNotFound exception!");
                //rethrowing exception!
                //throw;
                //because of rethrowing ArgumentNullException is never catched!
                
                //Also!
                //If we replaced throw with throw ex, the example would still
                //work, but the StackTrace property of the newly propagated
                //exception would no longer reflect the original error.
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void test_2() {
            try {
                ReadFile("text.txt");
                ReadFile2("text.txt");
                ReadFile2(null);
            }
            catch (ArgumentNullException ex) {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine("Catching rethrown exceptions!");
                Console.WriteLine(ex.Message);
            }
        }

    }
}
