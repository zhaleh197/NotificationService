using Confluent.Kafka;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using MongoDB.Bson.IO;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Events;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Kafka;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Application.Service.WriteRepository.SMS.Queris.GetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks; 

namespace Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.GetQSMS
{

    public class CheckQueueSMSWorker : BackgroundService
    {
        private readonly ChannelQueue<SMSAddedinQueue> _checkQueueSMSModelChannel;
        private readonly ILogger<CheckQueueSMSWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
       // private readonly IDistributedCache _cacheRedis;

        private readonly ChannelQueue<OnceMessage> _channelOnce;
        private readonly ChannelQueue<OnceMessage2> _channelOnce2;
        private readonly ChannelQueue<WeeklyMessage> _channelWeekly;
        private readonly ChannelQueue<DailyMessage> _channelDaily;
        private readonly ChannelQueue<MounthlyMessage> _channelMounthly;
        private readonly ChannelQueue<AnnualMessage> _channelAnnual;
        private readonly ChannelQueue<HourlyMessage> _channelhourly;




        public CheckQueueSMSWorker(
            ChannelQueue<SMSAddedinQueue> checkQueueSMSModelChannel,
          // IDistributedCache cacheRedis,
            ILogger<CheckQueueSMSWorker> logger,
            IServiceProvider serviceProvider
            , ChannelQueue<OnceMessage> channelOnce
             , ChannelQueue<OnceMessage2> channelOnce2
            , ChannelQueue<HourlyMessage> channelhourly
            , ChannelQueue<DailyMessage> channelDaily
            , ChannelQueue<WeeklyMessage> channelWeekly
            , ChannelQueue<MounthlyMessage> channelMounthly
            , ChannelQueue<AnnualMessage> channelAnnual
            )
        {
            _checkQueueSMSModelChannel = checkQueueSMSModelChannel;
            _logger = logger;
            _serviceProvider = serviceProvider;
           // _cacheRedis = cacheRedis;
            _channelWeekly = channelWeekly;
            _channelAnnual = channelAnnual;
            _channelDaily = channelDaily;
            _channelMounthly = channelMounthly;
            _channelOnce = channelOnce;
            _channelOnce2 = channelOnce2;
            _channelhourly = channelhourly;
        }
        bool validation = false;


     
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var writeRepository = scope.ServiceProvider.GetRequiredService<IGetQ>();
                //var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
               // var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
               // var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                try
                {
                    /////////////////////////////////////////////////////
                    //فقط یک بار دیتا را از صف ارسال بخواند و در چنل قرار دهد.
                    while (!validation)
                    {
                        validation = true;
                        //1. get of DB
                        var resultall = writeRepository.GetQeueUserSMS();
                         
                        //2.Sort Data based Prtiority--- 
                        //نمیشود سورت کرد. زیرا با ورود دیتای جدید نمیتاون چنل را اپدیت کرد.
                        
                        if(resultall != null)
                         //2.Add _checkQueueSMSModelChannel
                            for (int i = 0; i < resultall.Count; i++)// 
                        {
                            await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = resultall[i].Id }, stoppingToken);
                        }

                        //3.  validation = true
                       
                    }

                    /////////////////////////////////////////////////////
                    await foreach (var item in _checkQueueSMSModelChannel.ReturnValue(stoppingToken))
                    {
                        var smsinq = writeRepository.GetsSMSinQbyId(item.IdSMSinQueu);
                        //var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);

                       // string topic = smsinq.periodSendly; 



                        if (smsinq != null)
                        {
                            if (smsinq.PeriodSendly == "Once")
                            {




                                //insert in channelonce
                                //the 1 approch/ this is true by chanel
                                if(smsinq.IdTypeSMS==1)
                                    await _channelOnce.AddToChannelAsync(new OnceMessage { IdSMSinQueu = smsinq.Id }, stoppingToken);
                                else
                                {
                                    await _channelOnce2.AddToChannelAsync(new OnceMessage2 { IdSMSinQueu = smsinq.Id }, stoppingToken);

                                }
                                ////Kafka

                                ////2 approch:
                                ////felan 14010614
                                ////Producer API= http://localhost:5126/api/Producer
                                ////kafka
                                //string topic = smsinq.IdTypeSMS.ToString();
                                //long idSMSinKafka = smsinq.Id;
                                ////string messagee = System.Text.Json.JsonSerializer.Serialize(new OnceMessage { IdSMSinQueu = smsinq.Id });
                                //HttpClient _client   = new HttpClient();
                                //string jasonuser = JsonConvert.SerializeObject(new OrderRequest {topic=topic,Id=idSMSinKafka });
                                //StringContent content = new StringContent(jasonuser, Encoding.UTF8, "application/json");
                                //var usernew = _client.PostAsync("http://localhost:5126/api/Producer", content).Result;


                            }
                            if (smsinq.PeriodSendly == "Hourly")
                            {

                                //kafka
                                // string topic = smsinq.periodSendly;
                                //string messagee = JsonSerializer.Serialize(new OnceMessage { IdSMSinQueu = smsinq.Id });
                                // await SendOrderRequest(topic, messagee);




                                //insert in channelonce

                                await _channelhourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = smsinq.Id }, stoppingToken);


                                /*
                                //var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);
                                //////////////////////////
                               // if (smsinq != null)
                                //{

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
                                                // DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 1);
                                                // var up = writeRepository.UpdateSMSinQbyIdF(smsinq.Id, newdat, smsinq.timeOfsend.TimeOfDay);

                                                //
                                                // await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
                                                //
                                            }
                                            else if (smsinq.dateOfsend < DateTime.Now.Date && smsinq.timeOfsend < DateTime.Now)
                                            {
                                                //3. delete from Queu 
                                                writeRepository.DeleteSMSinQbyId(smsinq.Id);
                                            }
                                        }
                                    }


                                    await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                                */

                            }
                            else if (smsinq.PeriodSendly == "Daily")
                            {
                                //insert in channeldaily

                                 await _channelDaily.AddToChannelAsync(new DailyMessage { IdSMSinQueu = smsinq.Id }, stoppingToken);
                                /*
                              //  var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
                               // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);
                                //////////////////////////
                               // if (smsinq != null)
                               // {

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
                                               // DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 1);
                                               // var up = writeRepository.UpdateSMSinQbyIdF(smsinq.Id, newdat, smsinq.timeOfsend.TimeOfDay);

                                                //
                                               // await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
                                                //
                                            }
                                           else if (smsinq.dateOfsend < DateTime.Now.Date && smsinq.timeOfsend < DateTime.Now)
                                            {
                                                //3. delete from Queu 
                                                writeRepository.DeleteSMSinQbyId(smsinq.Id);
                                            }
                                        }
                                    }

                                    //

                                    await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
                                */
                            }
                            else if (smsinq.PeriodSendly == "Weekly")
                            {
                                //insert in channeldaily

                                await _channelWeekly.AddToChannelAsync(new WeeklyMessage { IdSMSinQueu = smsinq.Id }, stoppingToken);
                                /*
                                await Task.Delay(TimeSpan.FromDays(7), stoppingToken);
                                */
                            }
                            else if (smsinq.PeriodSendly == "Mounthly")
                            {
                                //insert in channeloMounthlu

                                await _channelMounthly.AddToChannelAsync(new MounthlyMessage { IdSMSinQueu = smsinq.Id }, stoppingToken);
                               /*
                                await Task.Delay(TimeSpan.FromDays(30), stoppingToken);
                               */
                            }
                            else if (smsinq.PeriodSendly == "Annoual")
                            {
                                //insert in channelAnnual

                                
                                await _channelAnnual.AddToChannelAsync(new AnnualMessage { IdSMSinQueu = smsinq.Id }, stoppingToken);
                                /*
                                await Task.Delay(TimeSpan.FromDays(356), stoppingToken);
                                */
                            }
                        }
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