using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_arithmetic_1
{
    public class SomeClass
    {
        private int SomeField { get; set; }
        private static int SomeConstant { get; set; } = 1;

        public SomeClass () {
            throw new System.NotImplementedException ();
        }

        ~SomeClass () {
            throw new System.NotImplementedException ();
        }

        /// <exception cref="NotImplementedException" accessor="get">Another bad condition.</exception>
        public int SomeProperty {
            get { throw new System.NotImplementedException (); }

            set { }
        }

        /// <summary>
        /// This is some method of SomeClass =)
        /// </summary>
        /// <remarks>Use carefully!</remarks>
        /// <param name="param1">Some ref parameter 1</param>
        /// <param name="param2">Some out parameter 2</param>
        /// <param name="param3">Some params parameter 3</param>
        /// <returns>double trouble</returns>
        /// <exception cref="NotImplementedException">Some bad condition.</exception>
        public double SomeMethod (ref double param1, out string param2, params int[] param3) {
            throw new System.NotImplementedException ();
        }
    }
}