using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace DependencyInjection_book
{
    internal class Hello_DI
    {
        private static void Test_1 () {
            IMessageWriter writer = new ConsoleMessageWriter ();
            var salutation = new Salutation (writer);
            salutation.Exclaim ();
        }

        private static void Test_2 () {
            try {
                var typeName = ConfigurationManager.AppSettings["messageWriter"];
                var type = Type.GetType (typeName, true);
                var writer = (IMessageWriter) Activator.CreateInstance (type);
                var salutation = new Salutation (writer);
                salutation.Exclaim ();
            }
            catch (Exception e) {
                Console.WriteLine (e.ToString ());
            }
        }

        private static void Test_3()
        {
            try {
                IMessageWriter writer = new SecureMessageWriter(new ConsoleMessageWriter());
                var salutation = new Salutation(writer);
                salutation.Exclaim();
            }
            catch (UnauthorizedAccessException e) {
                Console.WriteLine(e);
            }
        }

        public static void RunTests () {
            Test_3 ();
        }

        internal class Salutation
        {
            private readonly IMessageWriter _writer;

            /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
            public Salutation (IMessageWriter writer) {
                if (writer == null)
                    throw new ArgumentNullException (nameof (writer));
                _writer = writer;
            }

            public void Exclaim () {
                _writer.Write ("Hello DI!");
            }
        }

        internal class ConsoleMessageWriter : IMessageWriter
        {
            /// <exception cref="IOException">Произошла ошибка ввода-вывода. </exception>
            public void Write (string message) {
                Console.WriteLine (message);
            }
        }

        internal class SecureMessageWriter : IMessageWriter
        {
            private readonly IMessageWriter _writer;

            public SecureMessageWriter(IMessageWriter writer) {
                if (writer == null)
                    throw new ArgumentNullException(nameof(writer));
                _writer = writer;
            }

            public void Write(string message) {
                if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                    _writer.Write(message);
                else
                    throw new UnauthorizedAccessException("SecureMessageWriter");
            }
        }

        internal interface IMessageWriter
        {
            void Write (string message);
        }
    }
}