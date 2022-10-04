using ApacheKafkaProducerDemo;
using Confluent.Kafka;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.SMS.Queris.Post;
using Notification.Application.Service.WriteRepository.SMS.Queris.GetQ;
using Notification.Application.Service.WriteRepository.User.Kat;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace ApacheKafkaConsumerDemo
{
    public class ApacheKafkaConsumerService : IHostedService
    {
        private readonly string topic = "1";
        private readonly string groupId = "test_group";
        private readonly string bootstrapServers = "localhost:9092";


         
        private readonly ILogger<ApacheKafkaConsumerService> _logger;
        private readonly IServiceProvider _serviceProvider;

        private readonly ChannelQueue<SMSAddedinQueue> _checkQueueSMSModelChannel;


        public ApacheKafkaConsumerService(
          ILogger<ApacheKafkaConsumerService> logger
          , IServiceProvider serviceProvider
           , ChannelQueue<SMSAddedinQueue> checkQueueSMSModelChannel
           )
        {
            // _getQ = getQ;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _checkQueueSMSModelChannel = checkQueueSMSModelChannel;
        }


        ///// ///////////////////////////////////////////////////
        ///// 

        ///// <summary>
        ///// thats true///
        ///// </summary>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        ////protected async Task dno(CancellationToken stoppingToken)
        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    //while (!cancellationToken.IsCancellationRequested)
        //    //{
        //    using var scope = _serviceProvider.CreateScope();
        //    var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
        //    var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
        //    var Katf = scope.ServiceProvider.GetRequiredService<IKhat>();
        //    var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
        //    var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();

        //    var config = new ConsumerConfig
        //    {
        //        GroupId = groupId,
        //        BootstrapServers = bootstrapServers,
        //        AutoOffsetReset = AutoOffsetReset.Earliest
        //    };


        //    try
        //    {
        //        using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
        //        {
        //            consumerBuilder.Subscribe(topic);
        //            var cancelToken = new CancellationTokenSource();
        //            try
        //            {
        //                while (true)
        //                {
        //                    var consumer = consumerBuilder.Consume(cancelToken.Token);

        //                    var orderRequest = JsonSerializer.Deserialize<OrderRequest>(consumer.Message.Value);

        //                    var smsinq = getQ.GetsSMSinQbyId(orderRequest.Id);
        //                    // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);
        //                    var user = readRepository.GetByUSerId(smsinq.IdUser);

        //                    //var khatnum = UserLocal.GetKhototUser(user.Result.IdUser);


        //                    if (smsinq.DateofLimitet == null || smsinq.DateofLimitet == String.Empty || smsinq.DateofLimitet == "string") smsinq.DateofLimitet = DateTime.Now.ToString();
        //                    if (smsinq.DateOfsend == null || smsinq.DateOfsend == String.Empty || smsinq.DateOfsend == "string") smsinq.DateOfsend = DateTime.Now.ToString();
        //                    if (smsinq.TimeOfsend == null || smsinq.TimeOfsend == String.Empty || smsinq.TimeOfsend == "string") smsinq.TimeOfsend = DateTime.Now.ToString();

        //                    //////////////////////////
        //                    DateTime dt = DateTime.Now;
        //                    string day = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        //                    string tim = dt.ToString("hh:mm tt");
        //                    // output   "02/20/2016 12:00:00 AM"
        //                    ////////////////////////////
        //                    ///
        //                    int result = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.DateofLimitet).Date);
        //                    ///
        //                    Debug.WriteLine("check1");
        //                    if (result < 0)// if (smsinq.dateofLimitet >= d) // Hanoz Ersal Shavad.
        //                    {
        //                        //var user=_localUser.GetuserbyIduser(request.userOfSMS.Iduser).PackageTariff.
        //                        // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser, stoppingToken);

        //                        if (user.CridetMeaasage >= 1)//hanooz Pachage ooo Eetabar Darad?!!
        //                        {
        //                            Debug.WriteLine("check1");
        //                            int resultdaghighDay = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.DateOfsend).Date);
        //                            int t1 = Convert.ToDateTime(tim).TimeOfDay.Hours;
        //                            int t2 = Convert.ToDateTime(smsinq.TimeOfsend).TimeOfDay.Hours;

        //                            int resultdaghighTim = 0;//t1==t2
        //                            if (t1 < t2) resultdaghighTim = -1;
        //                            else if (t1 > t2) resultdaghighTim = 1;
        //                            //int resultdaghighTim = t1 == t2 ? 0 : 1;
        //                            if (resultdaghighDay == 0)
        //                            {
        //                                if (resultdaghighTim == 0)
        //                                // if (smsinq.dateOfsend == DateTime.Now.Date.GetDateTimeFormats() && smsinq.timeOfsend == DateTime.Now)
        //                                {

        //                                    Debug.WriteLine("check1");


        //                                    //1. send smsm by check the condition

        //                                    //var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = Katf.GetKhatbyId(smsinq.IdKhatSend).LineNumber.ToString(), to = smsinq.to, txt = smsinq.txt });
        //                                    var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = smsinq.KhatSend.ToString(), to = smsinq.to, txt = smsinq.txt });

        //                                    //2. add in sms Table  
        //                                    postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS
        //                                    {
        //                                        Body = smsinq.txt,
        //                                        Resiver = new List<string> { smsinq.to.ToString() },
        //                                        IdUser = smsinq.IdUser,
        //                                        SendStatus = resultSend.statuse,
        //                                        DateDelivered = resultSend.datesend,
        //                                        DateOfsend = smsinq.DateOfsend,
        //                                        Deliverd = resultSend.deliverd,
        //                                        DateofLimitet = smsinq.DateofLimitet,
        //                                        DateSended = resultSend.datesend,
        //                                        IdTypeSMS = smsinq.IdTypeSMS,
        //                                        KhatSend = smsinq.KhatSend,
        //                                        PeriodSendly = smsinq.PeriodSendly,
        //                                        TimeOfsend = smsinq.TimeOfsend,
        //                                        TypeofResiver = smsinq.TypeofResier,
        //                                    });
        //                                    //3. delete from Queu 
        //                                    getQ.DeleteSMSinQbyId(smsinq.Id);
        //                                    Debug.WriteLine("check2");
        //                                }
        //                                else if (resultdaghighTim < 0)//<
        //                                {
        //                                    Debug.WriteLine("check3");
        //                                    //add in que
        //                                    var up = orderRequest.Id;
        //                                    _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, cancellationToken);

        //                                    //await _channeloncesendSMS.AddToChannelAsync(new OnceMessage { IdSMSinQueu = up }, stoppingToken);
        //                                }
        //                                else if (resultdaghighTim > 0)//< //>
        //                                {
        //                                    Debug.WriteLine("check4");
        //                                    postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0, KhatSend = smsinq.KhatSend, IdTypeSMS = smsinq.IdTypeSMS, PeriodSendly = smsinq.PeriodSendly, TimeOfsend = smsinq.TimeOfsend, TypeofResiver = smsinq.TypeofResier, DateofLimitet = smsinq.DateofLimitet });

        //                                    getQ.DeleteSMSinQbyId(smsinq.Id);
        //                                    Debug.WriteLine("check5");
        //                                }
        //                            }
        //                            else if (resultdaghighDay < 0)// tarikh ersalash nareside
        //                            {
        //                                var up = orderRequest.Id;
        //                                Debug.WriteLine("check6");
        //                                // await _channeloncesendSMS.AddToChannelAsync(new OnceMessage { IdSMSinQueu = up }, stoppingToken);
        //                                _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, cancellationToken);
        //                            }
        //                            else //resultdaghighDay >0 0
        //                            {
        //                                Debug.WriteLine("check7");
        //                                postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0, KhatSend = smsinq.KhatSend, IdTypeSMS = smsinq.IdTypeSMS, PeriodSendly = smsinq.PeriodSendly, TimeOfsend = smsinq.TimeOfsend, TypeofResiver = smsinq.TypeofResier, DateofLimitet = smsinq.DateofLimitet });

        //                                getQ.DeleteSMSinQbyId(smsinq.Id);
        //                                Debug.WriteLine("check8");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            Debug.WriteLine("check9");
        //                            _iSMSService.SMSFF(new SMSSendRequest { sender = "10000900900300", to = user.Phone, txt = " .  .کاربر گرامی پکیج خود را شارژ کنید. مدت اعتبار ان به پایان رسیده است. " });
        //                            Debug.WriteLine("check10");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Debug.WriteLine("check11");
        //                        postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 ,KhatSend=smsinq.KhatSend,IdTypeSMS=smsinq.IdTypeSMS,PeriodSendly=smsinq.PeriodSendly,TimeOfsend=smsinq.TimeOfsend,TypeofResiver=smsinq.TypeofResier,DateofLimitet=smsinq.DateofLimitet});
        //                        getQ.DeleteSMSinQbyId(smsinq.Id);
        //                    }
        //                    Debug.WriteLine("check12");
        //                    return Task.FromResult(new OrderProcessingRequest { Id = orderRequest.Id });

        //                }

        //            }
        //            catch (OperationCanceledException)
        //            {
        //                Debug.WriteLine("check13");
        //                consumerBuilder.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("check15");
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }




        //    // }
        //    return Task.CompletedTask;
        //}


        ///// ///////////////////////////////////////////////////
        ///// 



        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    var config = new ConsumerConfig
        //    {
        //        GroupId = groupId,
        //        BootstrapServers = bootstrapServers,
        //        AutoOffsetReset = AutoOffsetReset.Earliest
        //    };

        //    try
        //    {
        //        using (var consumerBuilder = new ConsumerBuilder
        //        <Ignore, string>(config).Build())
        //        {
        //            consumerBuilder.Subscribe(topic);
        //            var cancelToken = new CancellationTokenSource();

        //            try
        //            {
        //                while (true)
        //                {
        //                    var consumer = consumerBuilder.Consume
        //                       (cancelToken.Token);
        //                    var orderRequest = JsonSerializer.Deserialize
        //                        <OrderProcessingRequest>
        //                            (consumer.Message.Value);
        //                    Debug.WriteLine($"Processing Order Id: zhaleh");
        //                }
        //            }
        //            catch (OperationCanceledException)
        //            {
        //                consumerBuilder.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }

        //    return Task.CompletedTask;
        //}






        //this is worked by postman
        public Task<SMSSendResponse>  StartAsync(CancellationToken cancellationToken)
        {
            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };


            using var scope = _serviceProvider.CreateScope();
            var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();


            try
            {
                using (var consumerBuilder = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumerBuilder.Subscribe(topic);
                    var cancelToken = new CancellationTokenSource();
                    try
                    {
                        while (true)
                        {
                            var consumer = consumerBuilder.Consume(cancelToken.Token);

                            var orderRequest = JsonSerializer.Deserialize<OrderRequestFull>(consumer.Message.Value);

                            Debug.WriteLine($"Send SMS by periority 1. zhale BY " + orderRequest.topic);

                            // SMSFF(SMSSendRequest req);
                            // var res = _iSMSService.SMSFF(new SMSSendRequest { apikey = "", sender = orderRequest.sender, to = orderRequest.to, txt = orderRequest.txt });
                            //var res = _iSMSService.SMSFF(new SMSSendRequest { apikey = "", sender = "", to = "09187875167", txt = "hi" });
                            var res = _iSMSService.SMSFF(new SMSSendRequest { txt= orderRequest.txt,to=orderRequest.to,sender=orderRequest.sender});

                            // 
                            Debug.WriteLine($"Send SMS by periority 1. zhale BY " + orderRequest.topic);

                            //return Task.FromResult(new OrderProcessingRequest { cost = res.cost, datesend = res.datesend.ToString(), deliverd = res.deliverd, statuse = res.statuse });
                            return res;
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumerBuilder.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return null;
        }
        //
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
