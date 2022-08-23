
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
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();

                var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();

                var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
                var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();
                PriorityQueue<long, int> priorityQueueSMSSend = new PriorityQueue<long, int>();



                try
                {
                    ex(priorityQueueSMSSend, stoppingToken);

                    //1.
                    var r = ex2(priorityQueueSMSSend, stoppingToken = default);
                    await foreach (var item in r)
                    {
                        var smsinq = getQ.GetsSMSinQbyId(item);
                        var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);

                        //////////////////////////
                        DateTime dt = DateTime.Now;
                        string day = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                        string tim = dt.ToString("hh:mm tt");
                        // output   "02/20/2016 12:00:00 AM"
                        ////////////////////////////
                        ///
                        int result = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.dateofLimitet).Date);
                        ///
                        if (smsinq != null)
                        {

                            //Create Transaction by 3 work:
                            if (result < 0)// if (smsinq.dateofLimitet >= d) // Hanoz Ersal Shavad.
                            {
                                //var user=_localUser.GetuserbyIduser(request.userOfSMS.Iduser).PackageTariff.
                                // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser, stoppingToken);

                                if (user.Result.DeadlinePackage >= DateTime.Now)//hanooz Pachage ooo Eetabar Darad?!!
                                {
                                    int resultdaghighDay = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.dateOfsend).Date);
                                    int t1 = Convert.ToDateTime(tim).TimeOfDay.Hours;
                                    int t2 = Convert.ToDateTime(smsinq.timeOfsend).TimeOfDay.Hours;

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

                                            var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });

                                            //2. add in sms Table  
                                            postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = resultSend.statuse, DateDelivere = resultSend.datesend, DateSend = resultSend.datesend, Delivered = resultSend.deliverd });
                                            //3. delete from Queu 
                                            getQ.DeleteSMSinQbyId(smsinq.Id);

                                        }
                                        else if (resultdaghighTim < 0)//<
                                        {
                                            //add in que
                                            var up = item;
                                             _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, stoppingToken);

                                            //await _channeloncesendSMS.AddToChannelAsync(new OnceMessage { IdSMSinQueu = up }, stoppingToken);
                                        }
                                        else if (resultdaghighTim > 0)//< //>
                                        {
                                            postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است",  DateSend = DateTime.Now, Delivered = 0 });

                                            getQ.DeleteSMSinQbyId(smsinq.Id);
                                        }
                                    }
                                   else if (resultdaghighDay < 0)// tarikh ersalash nareside
                                    {
                                        var up = item;
                                      // await _channeloncesendSMS.AddToChannelAsync(new OnceMessage { IdSMSinQueu = up }, stoppingToken);
                                         _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, stoppingToken);
                                    }
                                    else //resultdaghighDay >0 0
                                    {
                                        postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است",  DateSend = DateTime.Now, Delivered = 0 });

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
                                postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateSend = DateTime.Now, Delivered = 0 });
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

        //        var getQ= scope.ServiceProvider.GetRequiredService<IGetQ>();

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
        //                  // var resultSend= iSMSService.SMSFinal(new SMSSendRequest3 { sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });

        //                    var resultSend = iSMSService.SMSFF(new SMSSendRequest{ sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });


        //                    //2. add in sms Table  
        //                   // postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body= smsinq.txt ,Resiver= smsinq.to ,IdUser=smsinq.IdUser,Status= resultSend.statuse, DateDelivere= resultSend.deliverd, DateSend= resultSend .datesend});
        //                    postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = resultSend.statuse, Delivered = resultSend.deliverd, DateSend = DateTime.Now, DateDelivere = resultSend.datesend });

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

        public async Task ex(PriorityQueue<long, int> priorityQueueSMSSend, CancellationToken stoppingToken)
        {

            using var scope = _serviceProvider.CreateScope();
            var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
            await foreach (var item in _channeloncesendSMS.ReturnValue(stoppingToken))
            {
                var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
                priorityQueueSMSSend.Enqueue(item.IdSMSinQueu, smsinq.periority);
            }
        }
        public async IAsyncEnumerable<long> ex2(PriorityQueue<long, int> priorityQueueSMSSend, CancellationToken stoppingToken = default)
        {

            // Instatiate an async queue
            // var q = new AsyncQueue<long>();
            SemaphoreSlim _enumerationSemaphore = new SemaphoreSlim(1);
            BufferBlock<long> _bufferBlock = new BufferBlock<long>();
            while (priorityQueueSMSSend.TryDequeue(out long item, out int priority))
            {
                //q.Enqueue(item);
                _bufferBlock.Post(item);
            }
            //var alld = q.GetAsyncEnumerator(stoppingToken);

            await _enumerationSemaphore.WaitAsync();
            try
            {
                // Return new elements until cancellationToken is triggered.
                while (true)
                {
                    // Make sure to throw on cancellation so the Task will transfer into a canceled state
                    stoppingToken.ThrowIfCancellationRequested();
                    yield return await _bufferBlock.ReceiveAsync(stoppingToken);
                }
            }
            finally
            {
                _enumerationSemaphore.Release();
            }
            //return (IAsyncEnumerable<long>)alld;
        }



    }
}

