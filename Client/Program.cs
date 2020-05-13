using System;
using System.Threading;

using GrpcDotNetNamedPipes;

using Common;

namespace Client
{
    class Program
    {
        static void Main()
        {
            var client = new Greeter.GreeterClient(GetChannel());

            Console.Write("Enter your name: ");
            var name = Console.ReadLine();

            Console.Write("Enter your number: ");
            var number = int.Parse(Console.ReadLine());

            var request = new Request
            {
                Name = name,
                Number = number
            };

            for (int i = 0; i < 5; i++)
            {
                var response = client.Double(request);

                Console.WriteLine(response.Message);
                Thread.Sleep(TimeSpan.FromSeconds(1.5));
            }
        }

        private static NamedPipeChannel GetChannel()
            => new NamedPipeChannel(".", Options.PipeName);
    }
}
