using Grpc.Core;
using Notification.Application.Service.SMS.Commands;
//using GrpcNotification;

namespace GrpcNotification.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
       // private readonly ISMSService _sMSService;
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(//ISMSService sMSService,
            ILogger<GreeterService> logger)
        {
            _logger = logger;
           // _sMSService = sMSService;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.ReadLine();
           // _sMSService.SMSF(new SMSSendRequest2 { to = request.To, txt = request.Txt });
            return Task.FromResult(new HelloReply
            {
                Message = "sedn smsm to  " + request.To.ToString() + " and " + request.Txt
            }) ;
        }
    }
}