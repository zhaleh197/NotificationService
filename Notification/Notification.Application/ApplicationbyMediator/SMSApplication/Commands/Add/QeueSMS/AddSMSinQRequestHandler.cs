using Confluent.Kafka;
using MediatR;
using Notification.Application.ApplicationbyMediator.Common.BaseChannel;
using Notification.Application.ApplicationbyMediator.SMSApplication.BackgroundWorker.Common.Events;
using Notification.Application.Service.ReadRepository.User;
using Notification.Application.Service.SMS.Commands;
using Notification.Application.Service.User.Enroll;
using Notification.Application.Service.WriteRepository.SMS.Queris.PostQ;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS
{
    public class AddSMSinQRequestHandler : IRequestHandler<AddSMSinQRequest, AddSMSinQResponse>
    {
        private readonly IPostSMSQ _postSMSQ;
        private readonly ISMSService _iSMSService;
      //  private readonly ILocalUser _localUser;
        private readonly ReadSMSUser _readSMSUser;
        private readonly ChannelQueue<SMSAddedinQueue> _checkQueueSMSModelChannel;
        public AddSMSinQRequestHandler(IPostSMSQ postSMSQ,
            ChannelQueue<SMSAddedinQueue> checkQueueSMSModelChannel
             //,ILocalUser localUser
             , ISMSService iSMSServic
            , ReadSMSUser readSMSUser)
        {
            _checkQueueSMSModelChannel = checkQueueSMSModelChannel;
            _postSMSQ = postSMSQ;
            // _localUser = localUser;
             _iSMSService=iSMSServic;
            _readSMSUser = readSMSUser;
        }

      

        public async Task<AddSMSinQResponse> Handle(AddSMSinQRequest request, CancellationToken cancellationToken = default)
        {
            if (request.schaduleSendSMS.dateofLimitet>= DateTime.Now) // Hanoz Ersal Shavad.
            {
                //var user=_localUser.GetuserbyIduser(request.userOfSMS.Iduser).PackageTariff.
                var user = _readSMSUser.GetByUSerIdAsync(request.userOfSMS.Iduser, cancellationToken);

                if (user.Result.DeadlinePackage >= DateTime.Now)//hanooz Pachage ooo Eetabar Darad?!!
                {
                    var command = _postSMSQ.PostUserSMSinQ(new RequestQeueSMSmodel { dateofLimitet = request.schaduleSendSMS.dateofLimitet, dateOfsend = request.schaduleSendSMS.dateOfsend, IdUser = request.userOfSMS.Iduser, periodSendly = request.schaduleSendSMS.periodSendly, periority = request.schaduleSendSMS.periority, to = request.message.to, timeOfsend = request.schaduleSendSMS.timeOfsend, txt = request.message.txt, TypeofResiver = request.message.TypeofResiver });


                    //inja if ha ra benevisdam na dar channel ha.
                    //if user pachageshash zaman dashteh bashad
                    
                    //if 
                    for (int i = 0; i < command.Count; i++)//by size (to)
                    {
                        await _checkQueueSMSModelChannel.AddToChannelAsync(new SMSAddedinQueue { IdSMSinQueu = command[i] }, cancellationToken);
                    }
                    return new AddSMSinQResponse { idqeueSMS = command };

                }
                else
                {

                    _iSMSService.SMSFF(new SMSSendRequest { sender= "10000900900300", to= request.userOfSMS.PhoneUser ,txt= " .  .کاربر گرامی پکیج خود را شارژ کنید. مدت اعتبار ان به پایان رسیده است. " });
                    // کاربر گرامی پکیج خود را شارژ کنید.
                    //user desActii ve.
                    //API FOR Disactive user// فعلا نیاز نیست. با همین ددلاین پکیج فعال یا غیر فعال یودن کاربر مشخص است.

                    //؟؟
                    //ersal notification be User jahat update package. 
                    //ya ersal payami baray ooo.
                    //ya chap payami.
                    //va exit
                }
            }
            //else
            //{

            //    //زمان پایان ارسال اس ام اس گذشته است.


            //    //؟؟
            //    // ersal nashavad digar. 
            //    //Ama che etefaghi bioftad????
            //    //as in saf hazf shavad/ 
            //    //ama dar table SMS ad nashavad.
            //    //yani 1,2,4 dar bala anjam nashavad. valli 3 anjam shavad.
                 


            //    //هیچ کاری نیاز نینست. خود به خود بررسی شده . هیچ کاری نکرده است. پس کلا الس نمیخواهد
            //}
            return null;

        }
    }
}
