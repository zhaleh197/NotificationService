
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Events;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Kafka;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Application.Service.User.Enroll;
using Notification.Application.Service.WriteRepository.SMS.Queris.GetQ;
using Notification.Application.Service.WriteRepository.User.Kat;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.GetQSMS
{
    public class SendOnceSMSWorker : BackgroundService
    {

        private readonly ChannelQueue<SMSAddedinQueue> _checkQueueSMSModelChannel;

        private readonly ChannelQueue<OnceMessage> _channeloncesendSMS;

        private readonly ILogger<SendOnceSMSWorker> _logger;
        private readonly IServiceProvider _serviceProvider;

        PriorityQueue<long, int> priorityQueueSMSSend = new PriorityQueue<long, int>();
        public SendOnceSMSWorker(
            ChannelQueue<OnceMessage> channeloncesendSMS,
            ILogger<SendOnceSMSWorker> logger,
            IServiceProvider serviceProvider
            , ChannelQueue<SMSAddedinQueue> checkQueueSMSModelChannel
            )
        {
            _checkQueueSMSModelChannel = checkQueueSMSModelChannel;
            _channeloncesendSMS = channeloncesendSMS;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<SMSSendResponse> GOKafka(ResponceGetQeueSMSmodel smsinq)
        {
            //2 approch:
            //felan 14010614
            //Producer API= http://localhost:5126/api/Producer
            //kafka
            string topic = smsinq.IdTypeSMS.ToString();
            long idSMSinKafka = smsinq.Id;
            //string messagee = System.Text.Json.JsonSerializer.Serialize(new OnceMessage { IdSMSinQueu = smsinq.Id });
            HttpClient _client = new HttpClient();
            string jasonuser = JsonConvert.SerializeObject(
                new OrderRequestFull {
                topic = topic, Id = idSMSinKafka , 
                sender=smsinq.KhatSend.ToString(),
                to=smsinq.to,txt=smsinq.txt
                }
            );

            StringContent content = new StringContent(jasonuser, Encoding.UTF8, "application/json");
            var smssendkafka = _client.PostAsync("http://localhost:5126/api/Producer", content).Result;
            var dereult =await smssendkafka.Content.ReadAsStringAsync();
            var Item = JsonConvert.DeserializeObject<SMSSendResponse>(dereult);

            return Item;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();

                var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();

                // var UserLocal = scope.ServiceProvider.GetRequiredService<ILocalUser>();

                var Katf = scope.ServiceProvider.GetRequiredService<IKhat>();
                var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                PriorityQueue<long, int> priorityQueueSMSSend = new PriorityQueue<long, int>();
                try
                {
                    //ex(priorityQueueSMSSend, stoppingToken);

                    ////1.
                    //var r = ex2(priorityQueueSMSSend, stoppingToken = default);


                    //await foreach (var item in r)
                    //{
                        await foreach (var item in _channeloncesendSMS.ReturnValue(stoppingToken))
                        {
                        var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
                       // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);
                          var user = readRepository.GetByUSerId(smsinq.IdUser);
                        
                        //var khatnum = UserLocal.GetKhototUser(user.Result.IdUser);


                        if (smsinq.DateofLimitet == null || smsinq.DateofLimitet == String.Empty || smsinq.DateofLimitet == "string") smsinq.DateofLimitet = DateTime.Now.ToString();
                        if (smsinq.DateOfsend == null || smsinq.DateOfsend == String.Empty || smsinq.DateOfsend == "string") smsinq.DateOfsend = DateTime.Now.ToString();
                        if (smsinq.TimeOfsend == null || smsinq.TimeOfsend == String.Empty || smsinq.TimeOfsend == "string") smsinq.TimeOfsend = DateTime.Now.ToString();

                        //////////////////////////
                        DateTime dt = DateTime.Now;
                        string day = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        string tim = dt.ToString("hh:mm tt");
                        // output   "02/20/2016 12:00:00 AM"
                        ////////////////////////////
                        ///
                        int result = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.DateofLimitet).Date);
                        ///
                        if (smsinq != null)
                        {

                            //Create Transaction by 3 work:
                            if (result < 0)// if (smsinq.dateofLimitet >= d) // Hanoz Ersal Shavad.
                            {
                                //var user=_localUser.GetuserbyIduser(request.userOfSMS.Iduser).PackageTariff.
                                // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser, stoppingToken);

                                if (user.CridetMeaasage >= 1)//hanooz Pachage ooo Eetabar Darad?!!
                                {
                                    int resultdaghighDay = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.DateOfsend).Date);
                                    int t1 = Convert.ToDateTime(tim).TimeOfDay.Hours;
                                    int t2 = Convert.ToDateTime(smsinq.TimeOfsend).TimeOfDay.Hours;

                                    int resultdaghighTim = 0;//t1==t2
                                    if (t1 < t2) resultdaghighTim = -1;
                                    else if (t1 > t2) resultdaghighTim = 1;
                                    //int resultdaghighTim = t1 == t2 ? 0 : 1;
                                    if (resultdaghighDay == 0)
                                    {
                                        if (resultdaghighTim == 0)
                                        // if (smsinq.dateOfsend == DateTime.Now.Date.GetDateTimeFormats() && smsinq.timeOfsend == DateTime.Now)
                                        {
                                            //1. send smsm by check the condition

                                            //var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = Katf.GetKhatbyId(smsinq.IdKhatSend).LineNumber.ToString(), to = smsinq.to, txt = smsinq.txt });
                                            var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = smsinq.KhatSend.ToString(), to = smsinq.to, txt = smsinq.txt });

                                            //2. add in sms Table  
                                            postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { 
                                                Body = smsinq.txt,
                                                Resiver = new List<string> { smsinq.to.ToString() },
                                                IdUser = smsinq.IdUser, 
                                                SendStatus = resultSend.statuse,
                                                DateDelivered = resultSend.datesend,
                                                DateOfsend = smsinq.DateOfsend,
                                                Deliverd = resultSend.deliverd ,
                                                DateofLimitet=smsinq.DateofLimitet,
                                                DateSended = resultSend.datesend,
                                                IdTypeSMS = smsinq.IdTypeSMS,
                                                KhatSend=smsinq.KhatSend,
                                                PeriodSendly=smsinq.PeriodSendly,
                                                TimeOfsend=smsinq.TimeOfsend,
                                                TypeofResiver=smsinq.TypeofResier,
                                            });
                                            //3. delete from Queu 
                                            getQ.DeleteSMSinQbyId(smsinq.Id);

                                        }
                                        else if (resultdaghighTim < 0)//<
                                        {
                                            //add in que
                                            var up = item.IdSMSinQueu;
                                            _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, stoppingToken);

                                            //await _channeloncesendSMS.AddToChannelAsync(new OnceMessage { IdSMSinQueu = up }, stoppingToken);
                                        }
                                        else if (resultdaghighTim > 0)//< //>
                                        {
                                            postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 });

                                            getQ.DeleteSMSinQbyId(smsinq.Id);
                                        }
                                    }
                                    else if (resultdaghighDay < 0)// tarikh ersalash nareside
                                    {
                                        var up = item.IdSMSinQueu;
                                        // await _channeloncesendSMS.AddToChannelAsync(new OnceMessage { IdSMSinQueu = up }, stoppingToken);
                                        _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, stoppingToken);
                                    }
                                    else //resultdaghighDay >0 0
                                    {
                                        postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 });

                                        getQ.DeleteSMSinQbyId(smsinq.Id);
                                    }
                                }
                                else
                                {
                                    _iSMSService.SMSFF(new SMSSendRequest { sender = "10000900900300", to = user.Phone, txt = " .  .کاربر گرامی پکیج خود را شارژ کنید. مدت اعتبار ان به پایان رسیده است. " });

                                }
                            }
                            else
                            {
                                postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 });
                                getQ.DeleteSMSinQbyId(smsinq.Id);
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

        //backup
        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        using var scope = _serviceProvider.CreateScope();

        //        var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();

        //        var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
        //        var iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
        //        var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
        //        try
        //        {
        //            await foreach (var item in _channeloncesendSMS.ReturnValue(stoppingToken))
        //            {
        //                var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
        //                var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);
        //                //////////////////////////
        //                if (smsinq != null)
        //                {

        //                    //Create Transaction by 3 work: 

        //                    //1. send smsm by check the condition

        //                    //in SMS kar nemikonad
        //                    // var resultSend= iSMSService.SMSFinal(new SMSSendRequest3 { sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });

        //                    var resultSend = iSMSService.SMSFF(new SMSSendRequest { sender = smsinq.IdKhatSend, to = smsinq.to, txt = smsinq.txt });


        //                    //2. add in sms Table  
        //                    // postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body= smsinq.txt ,Resiver= smsinq.to ,IdUser=smsinq.IdUser,Status= resultSend.statuse, DateDelivere= resultSend.deliverd, DateSend= resultSend .datesend});
        //                    postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = resultSend.statuse, Delivered = resultSend.deliverd, DateSend = DateTime.Now, DateDelivere = resultSend.datesend });

        //                    ///

        //                    //this is bad.
        //                    //3. delete from Queu 
        //                    getQ.DeleteSMSinQbyId(smsinq.Id);


        //                    ////

        //                }
        //                ////////////////////////
        //                ///

        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogError(e, e.Message);
        //        }

        //    }
        //}

        //public async Task ex(PriorityQueue<long, int> priorityQueueSMSSend, CancellationToken stoppingToken)
        //{

        //    using var scope = _serviceProvider.CreateScope();
        //    var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
        //    await foreach (var item in _channeloncesendSMS.ReturnValue(stoppingToken))
        //    {
        //        var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
        //        priorityQueueSMSSend.Enqueue(item.IdSMSinQueu, (int)smsinq.IdTypeSMS);
        //    }
        //}
        //public async IAsyncEnumerable<long> ex2(PriorityQueue<long, int> priorityQueueSMSSend, CancellationToken stoppingToken = default)
        //{

        //    // Instatiate an async queue
        //    // var q = new AsyncQueue<long>();
        //    SemaphoreSlim _enumerationSemaphore = new SemaphoreSlim(1);
        //    BufferBlock<long> _bufferBlock = new BufferBlock<long>();
        //    while (priorityQueueSMSSend.TryDequeue(out long item, out int priority))
        //    {
        //        //q.Enqueue(item);
        //        _bufferBlock.Post(item);
        //    }
        //    //var alld = q.GetAsyncEnumerator(stoppingToken);

        //    await _enumerationSemaphore.WaitAsync();
        //    try
        //    {
        //        // Return new elements until cancellationToken is triggered.
        //        while (true)
        //        {
        //            // Make sure to throw on cancellation so the Task will transfer into a canceled state
        //            stoppingToken.ThrowIfCancellationRequested();
        //            yield return await _bufferBlock.ReceiveAsync(stoppingToken);
        //        }
        //    }
        //    finally
        //    {
        //        _enumerationSemaphore.Release();
        //    }
        //    //return (IAsyncEnumerable<long>)alld;
        //}



    }
}

