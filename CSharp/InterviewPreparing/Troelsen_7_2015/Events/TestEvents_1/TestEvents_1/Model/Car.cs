using System;

namespace TestEvents_1.Model
{
    public class Car
    {
        // 1) Define a delegate type.
        public delegate void CarEngineHandler(object senader, CarEventArgs e);

        // generic delegate
        public delegate void CarInfo<in TParam>(TParam arg);

        // Is the car alive or dead?
        private bool carIsDead;

        private CarInfo<string> carNameHandlers;

        private CarInfo<int> carSpeedHandlers;

        // with Func or Action there's no need in declaring delegates
        private Func<int, string> carInfoFunc;

        // 2) Define a member variable of this delegate.
        private CarEngineHandler listOfHandlers;


        // events make callbacks even simpler
        //        public event CarEngineHandler AboutToExplode;
        // the same as without needing to define delegate!
        public event EventHandler<CarEventArgs> AboutToExplode;
        public event CarEngineHandler Exploded;


        // Class constructors.
        public Car() {}

        public Car(string name, int maxSp, int currSp) {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        public void RegisterCarSpeedHandler(CarInfo<int> handler) {
            carSpeedHandlers += handler;
        }

        public void RegisterCarNameHandler(CarInfo<string> handler) {
            carNameHandlers += handler;
        }

        // 3) Add registration function for the caller.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall) {
            listOfHandlers += methodToCall;
        }

        public void UnregisterWithCarEngine(CarEngineHandler methodToCall) {
            if (methodToCall != null) {
                listOfHandlers -= methodToCall;
            }
        }

        public void Accelerate(int delta) {
            // If this car is "dead," send dead message.
            carSpeedHandlers?.Invoke(CurrentSpeed);
            carNameHandlers?.Invoke(PetName);

            if (carIsDead) {
                listOfHandlers?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
                Exploded?.Invoke(this, new CarEventArgs("BABAH!!!"));
            }
            else {
                CurrentSpeed += delta;

                // Is this car "almost dead"?
                if (10 == (MaxSpeed - CurrentSpeed)) {
                    listOfHandlers?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                    AboutToExplode?.Invoke(this, new CarEventArgs("ABOUT TO BABAH!!!!!!"));
                }
                if (CurrentSpeed >= MaxSpeed) {
                    carIsDead = true;
                }
                else {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }
}