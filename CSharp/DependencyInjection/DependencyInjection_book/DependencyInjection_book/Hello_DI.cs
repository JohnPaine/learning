using System;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Moq;

// either we make IMessageWriter public
// or we make it internal and add this attribute for Moq
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace DependencyInjection_book
{
    public class Hello_DI
    {
        /// <exception cref="ArgumentNullException"><paramref name="writer" /> is <see langword="null" />.</exception>
        public static void Test_1 () {
            IMessageWriter writer = new ConsoleMessageWriter ();
            var salutation = new Salutation (writer);
            salutation.Exclaim ();
        }

        /// <exception cref="IOException">Произошла ошибка ввода-вывода. </exception>
        public static void Test_2 () {
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

        public static void Test_3()
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

        //[Fact]
        /// <exception cref="MockException">The invocation was not performed on the mock.</exception>
        private static void Test_HELLO_DI () {
            var writeMock = new Mock<IMessageWriter> ();
            var sut = new Salutation (writeMock.Object);

            sut.Exclaim ();

            writeMock.Verify(w => w.Write ("Hello DI!"));
        }

        public static void RunTests () {
            //Test_3 ();
            try {
                Test_HELLO_DI ();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }

        }

        private class Salutation
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

        private class ConsoleMessageWriter : IMessageWriter
        {
            /// <exception cref="IOException">Произошла ошибка ввода-вывода. </exception>
            public void Write (string message) {
                Console.WriteLine (message);
            }
        }

        private class SecureMessageWriter : IMessageWriter
        {
            private readonly IMessageWriter _writer;

            /// <exception cref="ArgumentNullException"><paramref name=""/> is <see langword="null" />.</exception>
            public SecureMessageWriter(IMessageWriter writer) {
                if (writer == null)
                    throw new ArgumentNullException(nameof(writer));
                _writer = writer;
            }

            /// <exception cref="UnauthorizedAccessException">SecureMessageWriter</exception>
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