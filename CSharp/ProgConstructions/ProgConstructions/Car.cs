using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal class CarEventArgs : EventArgs
    {
        public readonly string msg;

        public CarEventArgs (string message) {
            msg = message;
        }
    }

    internal class Car
    {
        public int MaxSpeed { get; set; }
        public int CurrentSpeed { get; set; }
        public string CarName { get; set; }
        public bool CarIsDead { get; set; }

        public Car () {
            MaxSpeed = 100;
        }

        //public delegate void CarEngineHandler (string msgForCaller);

        public delegate void CarEngineHandler (object sender, CarEventArgs eventArgs);

        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        private CarEngineHandler _listOfHandlers;

        public void RegisterWithCarEngine (CarEngineHandler methodToCall) {
            _listOfHandlers += methodToCall;
        }

        public void UnRegisterWithCarEngine (CarEngineHandler methodToCall) {
            Debug.Assert (_listOfHandlers != null, "_listOfHandlers != null");
            Debug.Assert (methodToCall != null, "methodToCall != null");
            _listOfHandlers -= methodToCall;
        }

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        /// <exception cref="IOException">Произошла ошибка ввода-вывода. </exception>
        /// <exception cref="ArgumentNullException">Параметр <paramref name="format" /> имеет значение null. </exception>
        /// <exception cref="FormatException">Заданная в параметре <paramref name="format" /> спецификация формата недопустима. </exception>
        public void Accelerate (int delta) {
            // send message if engine is broken
            if (CarIsDead || CurrentSpeed + delta > MaxSpeed) {
                // using null propagation
                //_listOfHandlers?.Invoke ("Car engine is broken...");
                // the same as:
                // if (_listOfHandlers != null) _listOfHandlers("Car engine is broken...");

                // the same using events:
                Exploded?.Invoke (this, new CarEventArgs ("Car engine is broken..."));
            }
            else {
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed)) {
                    //_listOfHandlers?.Invoke ("Careful buddy! Gonna blow!");
                    // the same using events:
                    AboutToBlow?.Invoke (this, new CarEventArgs ("Careful buddy! Gonna blow!"));
                }
                if (CurrentSpeed >= MaxSpeed)
                    CarIsDead = true;
                else {
                    Console.WriteLine ("Current car speed - {0}", CurrentSpeed);
                }
            }
        }

        public override string ToString() {
            return $"Car name - {CarName}, MaxSpeed - {MaxSpeed}";
        }
    }
}