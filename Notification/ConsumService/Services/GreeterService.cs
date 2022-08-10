using ConsumService;
using Grpc.Core;
using Grpc.Net.Client;
using ServerGRPCNotification;
namespace ConsumService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7218");
            var client = new SMSGrpcs.SMSGrpcsClient(channel);
            var reply2 = client.SendSMSGrpc(new SMSRequest { To = "sdfsdf" ,Txt=""});
            return Task.FromResult(new HelloReply
            {
                Message = "Hello from other Services" + request.Name
            });
        }
    }
}