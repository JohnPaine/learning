using System;

namespace TestEvents_1.Model
{
    public class CarEventArgs : EventArgs
    {
        public readonly string Message;

        public CarEventArgs(string message) {
            Message = message;
        }

    }
}