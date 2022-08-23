 
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

namespace Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.GetQSMS
{
    public class SendMounthlySMSWorker : BackgroundService
    {
        private readonly ChannelQueue<MounthlyMessage> _channelMounthly;
        private readonly ChannelQueue<SMSAddedinQueue> _checkQueueSMSModelChannel;
        private readonly ILogger<SendMounthlySMSWorker> _logger;
        private readonly IServiceProvider _serviceProvider;
        //private readonly IGetQ _getQ;
        //private readonly IPostSMS _postSMS;
        //private readonly ISMSService _iSMSService;

        public SendMounthlySMSWorker(
            ChannelQueue<MounthlyMessage> channelMounthly,
             ChannelQueue<SMSAddedinQueue> checkQueueSMSModelChannel,
        ILogger<SendMounthlySMSWorker> logger,
            IServiceProvider serviceProvider
           // IGetQ getQ,
            //IPostSMS postSMS,
            //ISMSService iSMSService
            )
        {
            //_postSMS = postSMS;
            //_iSMSService = iSMSService;
            _channelMounthly = channelMounthly;
            _checkQueueSMSModelChannel =checkQueueSMSModelChannel;
            //_getQ = getQ;
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
                    while (true)
                    {

                        await foreach (var item in _channelMounthly.ReturnValue(stoppingToken))
                        {

                            var smsinq = getQ.GetsSMSinQbyId(item.IdSMSinQueu);
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
                                        TimeSpan t1 = Convert.ToDateTime(tim).TimeOfDay;
                                        TimeSpan t2 = Convert.ToDateTime(smsinq.timeOfsend).TimeOfDay;
                                        int resultdaghighTim = TimeSpan.Compare(t1, t2);
                                        ///
                                        if (resultdaghighDay == 0 && resultdaghighTim == 0)
                                        // if (smsinq.dateOfsend == DateTime.Now.Date.GetDateTimeFormats() && smsinq.timeOfsend == DateTime.Now)
                                        {
                                            //1. send smsm by check the condition

                                            var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = user.Result.SarKhatNumber, to = smsinq.to, txt = smsinq.txt });

                                            //2. add in sms Table  
                                            postSMS.PostUserSMS(new RequestPostSMS.RequestSMSUser { Body = smsinq.txt, Resiver = smsinq.to, IdUser = smsinq.IdUser, Status = resultSend.statuse, Delivered = resultSend.deliverd, DateSend = DateTime.Now,DateDelivere=resultSend.datesend });

                                            //this is better.
                                            //3. update from Gueu
                                            var d = Convert.ToDateTime(smsinq.dateOfsend);
                                            var t = Convert.ToDateTime(smsinq.timeOfsend);
                                            //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
                                            //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

                                            DateOnly newdat = new DateOnly(d.Year, d.Month+1, d.Day);
                                            TimeSpan newtim = new TimeSpan(t.Hour, t.Minute, t.Second);
                                            var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim.ToString());
                                            //
                                            await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
                                            //

                                        }
                                        else if (resultdaghighDay == 0 && resultdaghighTim < 0)//<

                                        // else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend > DateTime.Now)//<
                                        {
                                            //add in que
                                            await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = item.IdSMSinQueu }, stoppingToken);

                                        }
                                        else if (resultdaghighDay == 0 && resultdaghighTim > 0)//< //>
                                        //else if (smsinq.dateOfsend == DateTime.Now.Date && smsinq.timeOfsend < DateTime.Now)//< //>
                                        {
                                            //this is better.
                                            //3. update from Gueu
                                            //this is better.
                                            //3. update from Gueu
                                            var d = Convert.ToDateTime(smsinq.dateOfsend);
                                            var t = Convert.ToDateTime(smsinq.timeOfsend);
                                            //DateOnly newdat = new DateOnly(smsinq.dateOfsend.Year, smsinq.dateOfsend.Month, smsinq.dateOfsend.Day + 7);
                                            //getQ.UpdateSMSinQbyId(smsinq.Id, newdat, smsinq.timeOfsend);

                                            DateOnly newdat = new DateOnly(d.Year, d.Month+1, d.Day);
                                            TimeSpan newtim = new TimeSpan(t.Hour, t.Minute, t.Second);
                                            var up = getQ.UpdateSMSinQbyIdF(smsinq.Id, newdat, newtim.ToString());


                                            //
                                            await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = up.Id }, stoppingToken);
                                            //
                                        }

                                    }
                                    if (user.Result.DeadlinePackage.Day <= DateTime.Now.Day + 30)
                                    {

                                        // eliminate from que in db
                                        //this as  a Dastan 
                                        //):
                                        var resultSend = _iSMSService.SMSFF(new SMSSendRequest { sender = "10000900900300", to = user.Result.Phone, txt = "کاربر گرامی پکیج خود را شارژ کنید.  در غیر این صورت پیام های صف ارسالتان حذف خواهد شد" });

                                        //1. send SMS to user (sharge the account / Tmdid the oachage)
                                        //2. add sms to que. for 5 days(for example) else delet this messag. 
                                        //3. if(dedlinpackede.day+5>now.day
                                        //delet shavad az saf.

                                        // کاربر گرامی پکیج خود را شارژ کنید.  در غیر این صورت پیام های صف ارسالتان حذف خواهد شد.


                                        //user desActiive.
                                        //API FOR Disactive user// فعلا نیاز نیست. با همین ددلاین پکیج فعال یا غیر فعال یودن کاربر مشخص است.



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
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                }

            }
        }
    }

}
