using Grpc.Core;

namespace ServerGRPCNotification.Services
{
    public class EmailGrpcsService : EmailGrpcs.EmailGrpcsBase
    {
     
        private readonly ILogger<EmailGrpcsService> _logger;
        public EmailGrpcsService(ILogger<EmailGrpcsService> logger)
        {
            _logger = logger;
        }
         
        public override Task<EmailResponce> SendEmailGrpc(EmailRequest request, ServerCallContext context)
        {
            return Task.FromResult(new EmailResponce
            {
                Res = true
            });
        }

    }
}
