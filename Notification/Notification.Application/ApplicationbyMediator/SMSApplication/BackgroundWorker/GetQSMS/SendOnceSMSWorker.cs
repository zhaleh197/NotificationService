 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Application.Service.WriteRepository.SMS.Queris.GetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.GetQSMS
{
    public class SendOnceSMSWorker : BackgroundService
    {
        private readonly ChannelQueue<OnceMessage> _channeloncesendSMS;
        private readonly ILogger<SendOnceSMSWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        //private readonly IGetQ _getQ;
        // readonly IPostSMS _postSMS;
        
        //private readonly ISMSService _iSMSService;

        public SendOnceSMSWorker(
            ChannelQueue<OnceMessage> channeloncesendSMS,
            ILogger<SendOnceSMSWorker> logger,
            IServiceProvider serviceProvider
            //IGetQ getQ,
            //ISMSService iSMSService
            //,IPostSMS postSMS
            )
        {
            //_postSMS = postSMS;
           // _iSMSService = iSMSService;
            _channeloncesendSMS = channeloncesendSMS;
            //_getQ = getQ;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var getQ= scope.ServiceProvider.GetRequiredService<IGetQ>();

                var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
                var iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    await foreach (var item in _channeloncesendSMS.ReturnValue(stoppingToken))
                    {
                        var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
                        var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);
                        //////////////////////////
                        if (smsinq != null)
                        {

                            //Create Transaction by 3 work: 

                            //1. send smsm by check the condition

                            //in SMS kar nemikonad
                          // var resultSend= iSMSService.SMSFinal(new SMSSendRequest3 { sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });

                            var resultSend = iSMSService.SMSFF(new SMSSendRequest{ sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });


                            //2. add in sms Table  
                            postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body= smsinq.txt ,Resiver= smsinq.to ,IdUser=smsinq.IdUser,Status= resultSend.statuse, DateDelivere= resultSend.deliverd, DateSend= resultSend .datesend});
                            

                            ///

                            //this is bad.
                            //3. delete from Queu 
                            getQ.DeleteSMSinQbyId(smsinq.Id);

                             
                            ////

                        }
                        ////////////////////////
                        ///

                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }

            }
        }
    }

}
