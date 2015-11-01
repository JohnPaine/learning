namespace Test_arithmetic_1
{
    internal class AnonymousTypes
    {
        public static void Run_Tests () {
            test_1 ();
        }

        private static void test_1 () {
            var dude = new {Name = "Petia", Age = 15};
        }
    }
}