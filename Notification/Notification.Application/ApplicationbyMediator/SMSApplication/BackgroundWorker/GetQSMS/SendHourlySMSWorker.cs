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
using System.Globalization;
using System.Threading.Tasks.Dataflow;
using Confluent.Kafka;
using System.Text.Json;
using System.Net;
using Notification.Application.Service.WriteRepository.User.Kat;

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
            IServiceProvider serviceProvider
           , ChannelQueue<SMSAddedinQueue> checkQueueSMSModelChannel
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

        //private async Task<bool> SendOrderRequest(string topic, string message)
        //{
        //    ProducerConfig config = new ProducerConfig
        //    {
        //        BootstrapServers = "localhost:9092",
        //        ClientId = Dns.GetHostName()
        //    };

        //    try
        //    {
        //        using (var producer = new ProducerBuilder
        //        <Null, string>(config).Build())
        //        {
        //            var result = await producer.ProduceAsync
        //            (topic, new Message<Null, string>
        //            {
        //                Value = message
        //            });

        //            //Debug.WriteLine($"Delivery Timestamp:{ result.Timestamp.UtcDateTime} ");
        //            return await Task.FromResult(true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error occured: {ex.Message}");
        //    }

        //    return await Task.FromResult(false);
        //}

        //kafka
        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    string topic = "Hourly";
        //    var config = new ConsumerConfig
        //    {
        //        GroupId = "hourly_group",
        //        BootstrapServers = "localhost:9092",
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
        //                    var orderRequest = JsonSerializer.Deserialize<OnceMessage>(consumer.Message.Value);

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
        /////////

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //     StartAsync(stoppingToken);
        //    string messagee = JsonSerializer.Serialize(new OnceMessage { IdSMSinQueu = smsinq.Id });
        //    await SendOrderRequest("Hourly", messagee);
        //}

        //felan comment.

        /// ////
        /// 
        //back up final doreii- bedon olaviat.
        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        using var scope = _serviceProvider.CreateScope();

        //        var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
        //        //var writeRepository2 = scope.ServiceProvider.GetRequiredService<ILocalUser>();
        //        var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
        //        var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
        //        var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();


        //        try
        //        {
        //            while (true)
        //            {

        //                await foreach (var item in _channelHourly.ReturnValue(stoppingToken))
        //                {

        //                    var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
        //                    var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);

        //                    //////////////////////////
        //                    DateTime dt = DateTime.Now;
        //                    string day = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        //                    string tim = dt.ToString("hh:mm tt");
        //                    // output   "02/20/2016 12:00:00 AM"
        //                    ////////////////////////////
        //                    ///
        //                    int result = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.dateofLimitet).Date);
        //                    ///
        //                    if (smsinq != null)
        //                    {

        //                        //Create Transaction by 3 work:
        //                        if (result < 0)// if (smsinq.dateofLimitet >= d) // Hanoz Ersal Shavad.
        //                        {
        //                            //var user=_localUser.GetuserbyIduser(request.userOfSMS.Iduser).PackageTariff.
        //                            // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser, stoppingToken);

        //                            if (user.Result.DeadlinePackage >= DateTime.Now)//hanooz Pachage ooo Eetabar Darad?!!
        //                            {
        //                                int resultdaghighDay = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.dateOfsend).Date);
        //                                TimeSpan t1 = Convert.ToDateTime(tim).TimeOfDay;
        //                                TimeSpan t2 = Convert.ToDateTime(smsinq.timeOfsend).TimeOfDay;
        //                                int resultdaghighTim = TimeSpan.Compare(t1, t2);
        //                                ///
        //                                if (resultdaghighDay == 0 && resultdaghighTim == 0)
        //                                // if (smsinq.dateOfsend == DateTime.Now.Date.GetDateTimeFormats() && smsinq.timeOfsend == DateTime.Now)
        //                                {
        //                                    //1. send smsm by check the condition

        //                                    var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });

        //                                    //2. add in sms Table  
        //                                    postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = resultSend.statuse, DateDelivere = resultSend.datesend, Delivered = resultSend.deliverd, DateSend = DateTime.Now });

        //                                    //this is better.
        //                                    //3. update from Gueu
        //                                    var d = Convert.ToDateTime(smsinq.dateOfsend);
        //                                    var t = Convert.ToDateTime(smsinq.timeOfsend);
        //                                    //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
        //                                    //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

        //                                    DateOnly newdat = new DateOnly(d.Year, d.Month, d.Day);
        //                                    TimeSpan newtim = new TimeSpan(t.Hour + 1, t.Minute, t.Second);
        //                                    var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim.ToString());
        //                                    //
        //                                    // await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
        //                                    await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = up.Id }, stoppingToken);

        //                                    //kafka
        //                                    //StartAsync(stoppingToken);
        //                                    //string messagee = JsonSerializer.Serialize(new OnceMessage { IdSMSinQueu = smsinq.Id });
        //                                    //await SendOrderRequest("Hourly", messagee);
        //                                    //

        //                                }
        //                                else if (resultdaghighDay == 0 && resultdaghighTim < 0)//<

        //                                // else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend > DateTime.Now)//<
        //                                {
        //                                    //add in que
        //                                    // await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = item.IdSMSinQueu }, stoppingToken);
        //                                    await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = item.IdSMSinQueu }, stoppingToken);

        //                                }
        //                                else if (resultdaghighDay == 0 && resultdaghighTim > 0)//< //>
        //                                //else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend < DateTime.Now)//< //>
        //                                {
        //                                    //this is better.
        //                                    //3. update from Gueu
        //                                    //this is better.
        //                                    //3. update from Gueu
        //                                    var d = Convert.ToDateTime(smsinq.dateOfsend);
        //                                    var t = Convert.ToDateTime(smsinq.timeOfsend);
        //                                    //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
        //                                    //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

        //                                    DateOnly newdat = new DateOnly(d.Year, d.Month, d.Day);
        //                                    TimeSpan newtim = new TimeSpan(t.Hour + 1, t.Minute, t.Second);
        //                                    var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim.ToString());


        //                                    //
        //                                    //await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);

        //                                    await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = up.Id }, stoppingToken);
        //                                    //

        //                                }
        //                                //notific
        //                                if (user.Result.DeadlinePackage.Hour <= DateTime.Now.Hour + 1)
        //                                {

        //                                    // eliminate from que in db
        //                                    //this as  a Dastan 
        //                                    //):
        //                                    var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = "10000900900300", to = user.Result.Phone, txt = "کاربر گرامی پکیج خود را شارژ کنید.  در غیر این صورت پیام های صف ارسالتان حذف خواهد شد" });

        //                                    //1. send SMS to user (sharge the account / Tmdid the oachage)
        //                                    //2. add sms to que. for 5 days(for example) else delet this messag. 
        //                                    //3. if(dedlinpackede.day+5>now.day
        //                                    //delet shavad az saf.

        //                                    // کاربر گرامی پکیج خود را شارژ کنید.  در غیر این صورت پیام های صف ارسالتان حذف خواهد شد.


        //                                    //user desActiive.
        //                                    //API FOR Disactive user// فعلا نیاز نیست. با همین ددلاین پکیج فعال یا غیر فعال یودن کاربر مشخص است.



        //                                }

        //                            }
        //                        }

        //                        ///
        //                        //UPDateKaram. Digeh Delet nemikhad.

        //                        //this is bad.
        //                        //3. delete from Queu 
        //                        // getQ.DeleteSMSinQbyId(smsinq.Id);

        //                        ////4. add to channel again for Repeat that.
        //                        ////in ra check kon ba shahla
        //                        //_channelAnnual.AddToChannelAsync(item, stoppingToken);
        //                        ////

        //                    }
        //                    ////////////////////////
        //                    ///

        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogError(e, e.Message);
        //        }

        //    }
        //}


        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        using var scope = _serviceProvider.CreateScope();

        //        var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
        //        //var writeRepository2 = scope.ServiceProvider.GetRequiredService<ILocalUser>();
        //        var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
        //        var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
        //        var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();


        //        try
        //        {
        //            while (true)
        //            {

        //                await foreach (var item in _channelHourly.ReturnValue(stoppingToken))
        //                {

        //                    var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
        //                    var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);

        //                    //////////////////////////
        //                    DateTime dt = DateTime.Now;
        //                    string day = dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        //                    string tim = dt.ToString("hh:mm tt");
        //                    // output   "02/20/2016 12:00:00 AM"
        //                    ////////////////////////////
        //                    ///
        //                    int result = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.dateofLimitet).Date);
        //                    ///
        //                    if (smsinq != null)
        //                    {

        //                        //Create Transaction by 3 work:
        //                        if (result < 0)// if (smsinq.dateofLimitet >= d) // Hanoz Ersal Shavad.
        //                        {
        //                            //var user=_localUser.GetuserbyIduser(request.userOfSMS.Iduser).PackageTariff.
        //                            // var user = readRepository.GetByUSerIdAsync(smsinq.IdUser, stoppingToken);

        //                            if (user.Result.DeadlinePackage >= DateTime.Now)//hanooz Pachage ooo Eetabar Darad?!!
        //                            {
        //                                int resultdaghighDay = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.dateOfsend).Date);
        //                                TimeSpan t1 = Convert.ToDateTime(tim).TimeOfDay;
        //                                TimeSpan t2 = Convert.ToDateTime(smsinq.timeOfsend).TimeOfDay;
        //                                int resultdaghighTim = TimeSpan.Compare(t1, t2);
        //                                ///
        //                                if (resultdaghighDay == 0 && resultdaghighTim == 0)
        //                                // if (smsinq.dateOfsend == DateTime.Now.Date.GetDateTimeFormats() && smsinq.timeOfsend == DateTime.Now)
        //                                {
        //                                    //1. send smsm by check the condition

        //                                    var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });

        //                                    //2. add in sms Table  
        //                                    postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = resultSend.statuse, DateDelivere = resultSend.datesend, Delivered = resultSend.deliverd, DateSend = DateTime.Now });

        //                                    //this is better.
        //                                    //3. update from Gueu
        //                                    var d = Convert.ToDateTime(smsinq.dateOfsend);
        //                                    var t = Convert.ToDateTime(smsinq.timeOfsend);
        //                                    //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
        //                                    //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

        //                                    DateOnly newdat = new DateOnly(d.Year, d.Month, d.Day);
        //                                    TimeSpan newtim = new TimeSpan(t.Hour + 1, t.Minute, t.Second);
        //                                    var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim.ToString());
        //                                    //
        //                                    // await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
        //                                    await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = up.Id }, stoppingToken);

        //                                    //kafka
        //                                    //StartAsync(stoppingToken);
        //                                    //string messagee = JsonSerializer.Serialize(new OnceMessage { IdSMSinQueu = smsinq.Id });
        //                                    //await SendOrderRequest("Hourly", messagee);
        //                                    //

        //                                }
        //                                else if (resultdaghighDay == 0 && resultdaghighTim < 0)//<

        //                                // else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend > DateTime.Now)//<
        //                                {
        //                                    //add in que
        //                                    // await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = item.IdSMSinQueu }, stoppingToken);
        //                                    await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = item.IdSMSinQueu }, stoppingToken);

        //                                }
        //                                else if (resultdaghighDay == 0 && resultdaghighTim > 0)//< //>
        //                                //else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend < DateTime.Now)//< //>
        //                                {
        //                                    //this is better.
        //                                    //3. update from Gueu
        //                                    //this is better.
        //                                    //3. update from Gueu
        //                                    var d = Convert.ToDateTime(smsinq.dateOfsend);
        //                                    var t = Convert.ToDateTime(smsinq.timeOfsend);
        //                                    //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
        //                                    //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

        //                                    DateOnly newdat = new DateOnly(d.Year, d.Month, d.Day);
        //                                    TimeSpan newtim = new TimeSpan(t.Hour + 1, t.Minute, t.Second);
        //                                    var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim.ToString());


        //                                    //
        //                                    //await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);

        //                                    await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = up.Id }, stoppingToken);
        //                                    //

        //                                }
        //                                //notific
        //                                if (user.Result.DeadlinePackage.Hour <= DateTime.Now.Hour + 1)
        //                                {

        //                                    // eliminate from que in db
        //                                    //this as  a Dastan 
        //                                    //):
        //                                    var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = "10000900900300", to = user.Result.Phone, txt = "کاربر گرامی پکیج خود را شارژ کنید.  در غیر این صورت پیام های صف ارسالتان حذف خواهد شد" });

        //                                    //1. send SMS to user (sharge the account / Tmdid the oachage)
        //                                    //2. add sms to que. for 5 days(for example) else delet this messag. 
        //                                    //3. if(dedlinpackede.day+5>now.day
        //                                    //delet shavad az saf.

        //                                    // کاربر گرامی پکیج خود را شارژ کنید.  در غیر این صورت پیام های صف ارسالتان حذف خواهد شد.


        //                                    //user desActiive.
        //                                    //API FOR Disactive user// فعلا نیاز نیست. با همین ددلاین پکیج فعال یا غیر فعال یودن کاربر مشخص است.



        //                                }

        //                            }
        //                        }

        //                        ///
        //                        //UPDateKaram. Digeh Delet nemikhad.

        //                        //this is bad.
        //                        //3. delete from Queu 
        //                        // getQ.DeleteSMSinQbyId(smsinq.Id);

        //                        ////4. add to channel again for Repeat that.
        //                        ////in ra check kon ba shahla
        //                        //_channelAnnual.AddToChannelAsync(item, stoppingToken);
        //                        ////

        //                    }
        //                    ////////////////////////
        //                    ///

        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogError(e, e.Message);
        //        }

        //    }
        //}



        //// old
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using var scope = _serviceProvider.CreateScope();
                var Katf = scope.ServiceProvider.GetRequiredService<IKhat>();

                var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
                //var writeRepository2 = scope.ServiceProvider.GetRequiredService<ILocalUser>();
                var postSMS = scope.ServiceProvider.GetRequiredService<IPostSMS>();
                var _iSMSService = scope.ServiceProvider.GetRequiredService<ISMSService>();
                var readRepository = scope.ServiceProvider.GetRequiredService<ReadSMSUser>();

                PriorityQueue<long, int> priorityQueueSMSSend = new PriorityQueue<long, int>();
                // priorityQueueSMSSend.Enqueue(1, 1);

                //try
                //{
                //while (true)
                //{


                //Order in PrioprityQueu by Priority
                /*
                ex(priorityQueueSMSSend, stoppingToken);
                AsyncQueue<long> q = new AsyncQueue<long>();
                while (priorityQueueSMSSend.TryDequeue(out long item, out int priority))
                {
                    q.Enqueue(item);
                }
                var alld = q.GetAsyncEnumerator(stoppingToken);
                await foreach (var item in (IAsyncEnumerable<long>)alld)
                */

                ex(priorityQueueSMSSend, stoppingToken);

                //1.
                var r = ex2(priorityQueueSMSSend, stoppingToken = default);
                await foreach (var item in r)
                {

                    //2
                    //while (true)
                    //{

                    // //3.
                    // for (int f=0;f<priorityQueueSMSSend.Count;f++) { 
                    //if (priorityQueueSMSSend.TryDequeue(out long item, out int priority))
                    //{
                    var smsinq = getQ.GetsSMSinQbyId(item);
                    var user = readRepository.GetByUSerIdAsync(smsinq.IdUser);

                    //string khatSendUser = Katf.GetKhatbyId(smsinq.IdKhatSend).LineNumber.ToString();
                    string khatSendUser = smsinq.KhatSend.ToString();

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

                            if (user.Result.CridetMeaasage >=1)//hanooz Pachage ooo Eetabar Darad?!!
                            {
                                int resultdaghighDay = DateTime.Compare(Convert.ToDateTime(day).Date, Convert.ToDateTime(smsinq.DateOfsend).Date);
                                //TimeSpan t1 = Convert.ToDateTime(tim).TimeOfDay;
                                //TimeSpan t2 = Convert.ToDateTime(smsinq.timeOfsend).TimeOfDay;
                                //int resultdaghighTim = TimeSpan.Compare(t1, t2);
                                /////
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

                                        var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = khatSendUser, to = smsinq.to, txt = smsinq.txt });

                                        //2. add in sms Table  
                                        postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver =new List<string> { smsinq.to }, IdUser = smsinq.IdUser, SendStatus = resultSend.statuse, DateDelivered = resultSend.datesend, DateOfsend = resultSend.datesend.ToString(), Deliverd = resultSend.deliverd });

                                        //this is better.
                                        //3. update from Gueu
                                        var d = Convert.ToDateTime(smsinq.DateOfsend);
                                        var t = Convert.ToDateTime(smsinq.TimeOfsend);
                                        //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
                                        //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

                                        DateOnly newdat = new DateOnly(d.Year, d.Month, d.Day);
                                        TimeSpan newtim = new TimeSpan(t.Hour + 1, t.Minute, t.Second);
                                        var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim.ToString());
                                        //
                                       // await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = up.Id }, stoppingToken);
                                         _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);

                                        //

                                    }
                                    else if (resultdaghighTim < 0)//<

                                    // else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend > DateTime.Now)//<
                                    {
                                        //add in que
                                        var up = item;
                                        //await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, stoppingToken);
                                        // await  _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = up }, stoppingToken);
                                         _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = item }, stoppingToken);
                                    }
                                    else if (resultdaghighTim > 0)//< //>
                                                                  //else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend < DateTime.Now)//< //>
                                    {
                                        //this is better.
                                        //3. update from Gueu
                                        //this is better.
                                        //3. update from Gueu
                                        var d = Convert.ToDateTime(smsinq.DateOfsend);
                                        var t = Convert.ToDateTime(smsinq.TimeOfsend);
                                        //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
                                        //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

                                        DateOnly newdat = new DateOnly(d.Year, d.Month, d.Day);
                                        TimeSpan newtim = new TimeSpan(t.Hour + 1, t.Minute, t.Second);
                                        var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim.ToString());


                                        //
                                      // await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = up.Id }, stoppingToken);

                                          _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
                                        //
                                    }
                                }
                                else if (resultdaghighDay < 0)// tarikh ersalash nareside
                                {
                                    var up = item;
                                     _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up }, stoppingToken);
                                    //await _channelHourly.AddToChannelAsync(new HourlyMessage { IdSMSinQueu = up }, stoppingToken);

                                }
                                else //resultdaghighDay >0
                                {
                                    postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver =new List<string> { smsinq.to }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 });

                                    getQ.DeleteSMSinQbyId(smsinq.Id);
                                }


                            }
                            else
                            {

                                // eliminate from que in db
                                //this as  a Dastan 
                                //):

                                //1. send SMS to user (sharge the account / Tmdid the oachage)
                                //2. add sms to que. for 5 days(for example) else delet this messag. 
                                //3. if(dedlinpackede.day+5>now.day
                                //delet shavad az saf.
                                // کاربر گرامی پکیج خود را شارژ کنید.  در غیر این صورت پیام های صف ارسالتان حذف خواهد شد.
                                //user desActiive.
                                //API FOR Disactive user// فعلا نیاز نیست. با همین ددلاین پکیج فعال یا غیر فعال یودن کاربر مشخص است.


                                //var user= get info user from IdentityServer
                                //var mobileuser=user.phone
                                // var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = "we", to = "mobileuser", txt = "کاربر گرامی پکیج خود را شارژ کنید.  در غیر این صورت پیام های صف ارسالتان حذف خواهد شد." });


                                _iSMSService.SMSFF(new SMSSendRequest { sender = "10000900900300", to = user.Result.Phone, txt = " .  .کاربر گرامی پکیج خود را شارژ کنید. مدت اعتبار ان به پایان رسیده است. " });


                            }
                        }
                        else
                        {
                             postSMS.PostUserSMS(new RequestPostSMS.RequestSendSMS { Body = smsinq.txt, Resiver =new List<string> { smsinq.to }, IdUser = smsinq.IdUser, SendStatus = " پیام ارسال نشد به دلیلی اینکه زمان درخواست ارسال پیام شما گذشته است", DateOfsend = DateTime.Now.ToString(), Deliverd = 0 });

                            getQ.DeleteSMSinQbyId(smsinq.Id);
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



                    // Console.WriteLine();
                    //Send From PeriorityQueue



                    // }
                }

                //}
                //catch (Exception e)
                //{
                //    _logger.LogError(e, e.Message);
                //}

            }
        }

        public async Task ex(PriorityQueue<long, int> priorityQueueSMSSend, CancellationToken stoppingToken)
        {

            using var scope = _serviceProvider.CreateScope();
            var getQ = scope.ServiceProvider.GetRequiredService<IGetQ>();
            await foreach (var item in _channelHourly.ReturnValue(stoppingToken))
            {
                var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
                priorityQueueSMSSend.Enqueue(item.IdSMSinQueu, (int)smsinq.IdTypeSMS);
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
                // q.Enqueue(item);
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
    //public class AsyncQueue<T> : IAsyncEnumerable<T>
    //{
    //    private readonly SemaphoreSlim _enumerationSemaphore = new SemaphoreSlim(1);
    //    private readonly BufferBlock<T> _bufferBlock = new BufferBlock<T>();

    //    public void Enqueue(T item) =>
    //        _bufferBlock.Post(item);

    //    public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken token = default)
    //    {
    //        // We lock this so we only ever enumerate once at a time.
    //        // That way we ensure all items are returned in a continuous
    //        // fashion with no 'holes' in the data when two foreach compete.
    //        await _enumerationSemaphore.WaitAsync();
    //        try
    //        {
    //            // Return new elements until cancellationToken is triggered.
    //            while (true)
    //            {
    //                // Make sure to throw on cancellation so the Task will transfer into a canceled state
    //                token.ThrowIfCancellationRequested();
    //                yield return await _bufferBlock.ReceiveAsync(token);
    //            }
    //        }
    //        finally
    //        {
    //            _enumerationSemaphore.Release();
    //        }

    //    }
    //}
}