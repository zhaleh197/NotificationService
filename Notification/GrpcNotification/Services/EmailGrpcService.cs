using GrpcNotification;
using Grpc.Core;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Interface.Context;
using Notification.Application.Service.SMS.Queris.Get;
using AutoMapper;

namespace GrpcNotification.Services
{
    public class EmailGrpcService : EmailGrpc.EmailGrpcBase
    { 
        private readonly ILogger<EmailGrpcService> _logger;
        private readonly ISMSService _sMSService;
        //private readonly IGetSMS _getSMS;

        //public IDatabaseContext _dbContext;
        public EmailGrpcService(ISMSService sMSService,
            ILogger<EmailGrpcService> logger,
             //IDatabaseContext dbContext,
             IGetSMS getSMS)
        {
            _logger = logger;
            _sMSService = sMSService;
            //_dbContext = dbContext;
            //_getSMS = getSMS;
        }
        public override Task<EmailResponce> SendEmailGrpc(EmailRequest request, ServerCallContext context)
        {
            try
            {
               // var f = "";
                //_sMSService.SMSF(new SMSSendRequest2 { to = request.To, txt = request.Txt });

                return Task.FromResult(
                    new EmailResponce
                    {
                        Res = true
                    });
            }
            catch (RpcException e)
            {
                Console.WriteLine("Remote procedure call failed: " + e);
                throw;
            }
        }

    }
}
