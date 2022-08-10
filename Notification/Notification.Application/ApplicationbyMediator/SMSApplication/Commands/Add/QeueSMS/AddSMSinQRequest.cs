using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS
{
    public class AddSMSinQRequest:IRequest<AddSMSinQResponse>//long is response.
    {
        public Message message { get; set; }
        public UserOfSMS userOfSMS { get; set; }
        public SchaduleSendSMS schaduleSendSMS { get; set; }
    }
}
