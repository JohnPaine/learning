using System;

namespace GC_tests.Model
{
    public class CarEventArgs : EventArgs
    {
        public readonly string Message;

        public CarEventArgs(string message) {
            Message = message;
        }

    }
}