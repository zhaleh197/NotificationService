 
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Kafka;
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
//using ApacheKafkaProducerDemo;

namespace ApacheKafkaConsumer3Demo
{
    public class ApacheKafkaConsumerService : IHostedService
    {

        private readonly string topic = "3";
        private readonly string groupId = "test_group";
        private readonly string bootstrapServers = "localhost:9092";

        private readonly ILogger<ApacheKafkaConsumerService> _logger;
        private readonly IServiceProvider _serviceProvider;


        private readonly ChannelQueue<SMSAddedinQueue> _checkQueueSMSModelChannel;


        public ApacheKafkaConsumerService(
          ILogger<ApacheKafkaConsumerService> logger,
          IServiceProvider serviceProvider
            , ChannelQueue<SMSAddedinQueue> checkQueueSMSModelChannel
           )
        {
            // _getQ = getQ;
            _logger = logger;
            _serviceProvider = serviceProvider;
            _checkQueueSMSModelChannel = checkQueueSMSModelChannel;
        }

        //protected async Task dno(CancellationToken stoppingToken)
        public Task StartAsync(CancellationToken cancellationToken)
        {
            //while (!cancellationToken.IsCancellationRequested)
            //{
            using var scope = _serviceProvider.CreateScope();
            var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
            var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
            var Katf = scope.ServiceProvider.GetRequiredService<IKhat>();
            var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
            var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();

            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = bootstrapServers,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };


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

                            var orderRequest = JsonSerializer.Deserialize<OrderRequest>(consumer.Message.Value);


                            var smsinq = getQ.GetsSMSinQbyId(orderRequest.Id);
                            var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);
                            //var khatnum = UserLocal.GetKhototUser(user.Result.IdUser);

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

                                    if (user.Result.CridetMeaasage >= 1)//hanooz Pachage ooo Eetabar Darad?!!
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

                                               // var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = Katf.GetKhatbyId(smsinq.IdKhatSend).LineNumber.ToString(), to = smsinq.to, txt = smsinq.txt });
                                                var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = smsinq.KhatSend.ToString(), to = smsinq.to, txt = smsinq.txt });


                                                //2. add in sms Table  
                                                postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = resultSend.statuse, DateDelivered = resultSend.datesend, DateOfsend = resultSend.datesend.ToString(), Deliverd = resultSend.deliverd });
                                                //3. delete from Queu 
                                                getQ.DeleteSMSinQbyId(smsinq.Id);

                                            }
                                            else if (resultdaghighTim < 0)//<
                                            {
                                                //add in que
                                                var up = orderRequest.Id;
                                                _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, cancellationToken);

                                                //  await _channeloncesendSMS.AddToChannelAsync(new OnceMessage { IdSMSinQueu = up }, stoppingToken);
                                            }
                                            else if (resultdaghighTim > 0)//>
                                            {
                                                postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 });

                                                getQ.DeleteSMSinQbyId(smsinq.Id);
                                            }
                                        }
                                        else if (resultdaghighDay < 0)// tarikh ersalash nareside
                                        {
                                            var up = orderRequest.Id;
                                            //  await _channeloncesendSMS.AddToChannelAsync(new OnceMessage { IdSMSinQueu = up }, stoppingToken);
                                            _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, cancellationToken);
                                        }
                                        else //resultdaghighDay >0 0
                                        {
                                            postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 });

                                            getQ.DeleteSMSinQbyId(smsinq.Id);
                                        }
                                    }
                                    else
                                    {
                                        _iSMSService.SMSFF(new SMSSendRequest { sender = "10000900900300", to = user.Result.Phone, txt = " .  .کاربر گرامی پکیج خود را شارژ کنید. مدت اعتبار ان به پایان رسیده است. " });

                                    }
                                }
                                else
                                {
                                    postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver = new List<string> { smsinq.to.ToString() }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 });
                                    getQ.DeleteSMSinQbyId(smsinq.Id);
                                }
                            }

                            return Task.FromResult(new OrderProcessingRequest { Id = orderRequest.Id });

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




            // }
            return Task.CompletedTask;
        }


        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    var config = new ConsumerConfig
        //    {
        //        GroupId = groupId,
        //        BootstrapServers = bootstrapServers,
        //        AutoOffsetReset = AutoOffsetReset.Earliest
        //    };


        //    using var scope = _serviceProvider.CreateScope();   
        //    var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();


        //    try
        //        {
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


        //                    // SMSFF(SMSSendRequest req);
        //                    var res= _iSMSService.SMSFF(new SMSSendRequest { apikey="",sender=orderRequest.sender,to=orderRequest.to,txt=orderRequest.txt});
        //                    //



        //                    Debug.WriteLine($"Send SMS by periority 1. zhale");

        //                    return Task.FromResult(new OrderProcessingRequest { cost = res.cost, datesend = res.datesend.ToString(), deliverd = res.deliverd, statuse = res.statuse });
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
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
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

        //                    Debug.WriteLine($"Send SMS by periority 3. zhale");
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
        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    return Task.CompletedTask;
        //}
    }
}
