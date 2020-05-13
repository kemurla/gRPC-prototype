using System.Threading.Tasks;

using Grpc.Core;

namespace Server
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<Response> Double(Request request, ServerCallContext context)
        {
            return Task.FromResult(new Response
            {
                Message = $"Hello {request.Name}. The double of your number is {request.Number * 2}"
            });
        }
    }
}
