using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal static class ParameterTypes
    {
        private enum EmpType1
        {
            Manager1,
            Huyager1,
            Bamboo1
        }

        private enum EmpType2
        {
            Manager2 = 100,
            Huyager2,
            Bamboo2
        }

        private enum EmpType3
        {
            Manager3,
            Huyager3 = 115,
            Bamboo3
        }

        private enum EmpType4
        {
            Manager4 = 104,
            Huyager4 = 117,
            Bamboo4
        }

        /// <summary>
        /// Prints all info about passed enum
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        /// <exception cref="ArgumentNullException">Parameter <paramref name="format" /> has null value. </exception>
        /// <exception cref="FormatException">Format specification set in parameter <paramref name="format" /> is not acceptable. </exception>
        /// <exception cref="ArgumentException">Parameter value for <paramref name="enumType" /> is not Enum <see cref="T:System.Enum" />. </exception>
        /// <exception cref="InvalidOperationException">Method is called in reflection context intended only for reflection.
        /// -or-<paramref name="enumType" /> — is a build type loaded in context suited only for reflection.</exception>
        private static void EvaluateEnum (System.Enum e) {
            Console.WriteLine ("*** Info about {0} ***", e.GetType ().Name);

            Console.WriteLine ("Underlying storage type: {0}", Enum.GetUnderlyingType (e.GetType ()));

            Array enumData = Enum.GetValues (e.GetType ());
            foreach (var eData in enumData) {
                Console.WriteLine ("Name - {0}, Value - {0:D}", eData);
            }
            Console.WriteLine ();
        }

        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        public static void RunTests () {
            try {
                //FunWithParameters ();
                //RectangleArrays ();
                //JaggedArrays ();

                FunWithEnums ();
            }
            catch (IOException e) {
                Console.WriteLine (e);
            }
        }

        private static void FunWithEnums () {
            const EmpType1 e1 = EmpType1.Bamboo1;
            const EmpType2 e2 = EmpType2.Bamboo2;
            const EmpType3 e3 = EmpType3.Bamboo3;
            const EmpType4 e4 = EmpType4.Bamboo4;

            EvaluateEnum (e1);
            EvaluateEnum (e2);
            EvaluateEnum (e3);
            EvaluateEnum (e4);
        }

        private static void JaggedArrays () {
            Console.WriteLine ("*************** Jagged Multidimensional arrays ******************");
            int[][] jagArray = new int[5][];

            for (var i = 0; i < jagArray.Length; ++i)
                jagArray[i] = new int[7 + i];

            for (var i = 0; i < 5; ++i) {
                for (var j = 0; j < jagArray[i].Length; ++j)
                    Console.Write (jagArray[i][j] + " ");
                Console.WriteLine ();
            }
            Console.WriteLine ();
        }

        private static void RectangleArrays () {
            Console.WriteLine ("************* Rectangle Multidimensional arrays *************");
            int[,] matrix = new int[6, 6];

            for (var i = 0; i < 6; ++i)
                for (var j = 0; j < 6; ++j)
                    matrix[i, j] = i*j;

            for (var i = 0; i < 6; ++i) {
                for (var j = 0; j < 6; ++j)
                    Console.Write (matrix[i, j] + "\t");
                Console.WriteLine ();
            }
            Console.WriteLine ();
        }

        private static void FunWithParameters () {
            int a, a2 = 25, a3;
            string b, b2 = "Some other string", b3;
            bool c, c2 = true, c3;
            OutputParameters (out a, out b, out c);
            ReferenceParameters (ref a2, ref b2, ref c2);

            // due to params modifier we can pass array of doubles like this
            ShittyParamsModifier (1.0, 2, 3.765, 27, 15.2, 29.45);
            // instead of this:
            double[] valuesArray = {1.0, 2, 3.765, 27, 15.2, 29.45};
            ShittyParamsModifier (valuesArray);
            // Yeap, no parameters is also possible
            ShittyParamsModifier ();

            // HA!!! And what was the problem to pass array like this??!?!
            ShittyParamsModifier (new double[] {2, 6});
            ShittyParamsModifier2 (new double[] {3, 7});

            // And also we have named parameters, ugghh great!
            OutputParameters (param2: out b3, param3: out c3, param1: out a3);
        }


        /// <summary>
        /// Out variables MUST be initialized in method! But before it they may stay uninitialized
        /// </summary>
        private static void OutputParameters (out int param1, out string param2, out bool param3) {
            param1 = new Random ().Next (0, 999);
            param2 = "Some string";
            param3 = false;
            try {
                Console.WriteLine ("a1 = {0}", param1);
                Console.WriteLine ("b1 = {0}", param2);
                Console.WriteLine ("c1 = {0}", param3);
            }
            catch (IOException ex) {
                Console.WriteLine (ex.Message);
            }
            catch (ArgumentNullException ex) {
                Console.WriteLine (ex.Message);
            }
            catch (FormatException ex) {
                Console.WriteLine (ex.Message);
            }
        }

        /// <summary>
        /// Ref variables MUST be initialized BEFORE method call! But in method they may stay untouched
        /// </summary>
        private static void ReferenceParameters (ref int a, ref string b, ref bool c) {
            try {
                Console.WriteLine ("a2 = {0}", ++a);
                Console.WriteLine ("b2 = {0}", b);
                Console.WriteLine ("c2 = {0}", c);
            }
            catch (IOException ex) {
                Console.WriteLine (ex.Message);
            }
            catch (ArgumentNullException ex) {
                Console.WriteLine (ex.Message);
            }
            catch (FormatException ex) {
                Console.WriteLine (ex.Message);
            }
        }

        /// <summary>
        /// The ONLY difference between "type[] valueArray" and "params type[] valueArray" as a parameter in method is the "convenience" in method call!
        /// </summary>
        /// <remarks>WTF!!!!</remarks>
        private static void ShittyParamsModifier (params double[] valueArray) {
            foreach (var val in valueArray) {
                try {
                    Console.WriteLine ("val = {0}", val);
                }
                catch (IOException ex) {
                    Console.WriteLine (ex.Message);
                }
                catch (ArgumentNullException ex) {
                    Console.WriteLine (ex.Message);
                }
                catch (FormatException ex) {
                    Console.WriteLine (ex.Message);
                }
            }
        }

        private static void ShittyParamsModifier2 (double[] valueArray) {
            foreach (var val in valueArray) {
                try {
                    Console.WriteLine ("val = {0}", val);
                }
                catch (IOException ex) {
                    Console.WriteLine (ex.Message);
                }
                catch (ArgumentNullException ex) {
                    Console.WriteLine (ex.Message);
                }
                catch (FormatException ex) {
                    Console.WriteLine (ex.Message);
                }
            }
        }
    }
}