using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class SendHourlySMSWorker : BackgroundService
    {
        private readonly ChannelQueue<HourlyMessage> _channelHourly;

        private readonly ChannelQueue<SMSAddedinQueue> _checkQueueSMSModelChannel;
        private readonly ILogger<SendHourlySMSWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        //private readonly IGetQ _getQ;
        //private readonly IPostSMS _postSMS;
        //private readonly ISMSService _iSMSService;

        public SendHourlySMSWorker(
            ChannelQueue<HourlyMessage> channelHourly,
            ILogger<SendHourlySMSWorker> logger,
            IServiceProvider serviceProvider,
            ChannelQueue<SMSAddedinQueue> checkQueueSMSModelChannel
           // ,IGetQ getQ,
           // IPostSMS postSMS,
           // ISMSService iSMSService
           )
        {
            // _postSMS = postSMS;
            //  _iSMSService = iSMSService;
            _channelHourly = channelHourly;
            _checkQueueSMSModelChannel = checkQueueSMSModelChannel;
            // _getQ = getQ;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
                //var writeRepository2 = scope.ServiceProvider.GetRequiredService<ILocalUser>();
                var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
                var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    await foreach (var item in _channelHourly.ReturnValue(stoppingToken))
                   // while(!_channelHourly)
                    {

                        var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
                        var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);
                        //////////////////////////
                        if (smsinq != null)
                        {

                            //Create Transaction by 3 work:
                            if (smsinq.dateofLimitet >= DateTime.Now) // Hanoz Ersal Shavad.
                            {
                                //var user=_localUser.GetuserbyIduser(request.userOfSMS.Iduser).PackageTariff.
                                // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser, stoppingToken);

                                if (user.Result.DeadlinePackage >= DateTime.Now)//hanooz Pachage ooo Eetabar Darad?!!
                                {

                                    if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend == DateTime.Now)
                                    {
                                        //1. send smsm by check the condition

                                        var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });

                                        //2. add in sms Table  
                                        postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = resultSend.statuse, DateDelivere = resultSend.deliverd, DateSend = resultSend.datesend });

                                        //this is better.
                                        //3. update from Gueu
                                        var d = Convert.ToDateTime(smsinq.dateOfsend);
                                        var t = Convert.ToDateTime(smsinq.timeOfsend);
                                        //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
                                        //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

                                        DateOnly newdat = new DateOnly(d.Year, d.Month, d.Day);
                                        TimeSpan newtim = new TimeSpan(t.Hour + 1, t.Minute, t.Second);
                                        var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim);
                                        //
                                        await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
                                        //

                                    }
                                    else if(smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend > DateTime.Now)//<
                                    {
                                        //add in que
                                        await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = item.IdSMSinQueu }, stoppingToken);

                                    }
                                    else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend < DateTime.Now)//< //>
                                    {
                                        //this is better.
                                        //3. update from Gueu
                                        //this is better.
                                        //3. update from Gueu
                                        var d = Convert.ToDateTime(smsinq.dateOfsend);
                                        var t = Convert.ToDateTime(smsinq.timeOfsend);
                                        //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
                                        //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

                                        DateOnly newdat = new DateOnly(d.Year, d.Month, d.Day);
                                        TimeSpan newtim = new TimeSpan(t.Hour+1, t.Minute, t.Second);
                                        var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim);


                                    //
                                    await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
                                    //
                                    }

                                }
                                else
                                {
                                    // eliminate from que in db
                                }
                            }

                            ///
                            //UPDateKaram. Digeh Delet nemikhad.

                            //this is bad.
                            //3. delete from Queu 
                            // getQ.DeleteSMSinQbyId(smsinq.Id);

                            ////4. add to channel again for Repeat that.
                            ////in ra check kon ba shahla
                            //_channelAnnual.AddToChannelAsync(item, stoppingToken);
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
