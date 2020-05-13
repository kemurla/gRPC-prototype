using System;

using GrpcDotNetNamedPipes;

using Common;

namespace Server
{
    class Program
    {
        static void Main()
        {
            var server = new NamedPipeServer(Options.PipeName);

            Greeter.BindService(server.ServiceBinder, new GreeterService());

            server.Start();

            Console.WriteLine("Server started.");
            Console.ReadLine();
        }
    }
}
