using Notification.Domain.Entities.SMS.QeueSend;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.SMSApplication.Commands.Add.QeueSMS
{
    public class AddSMSinQResponse
    {
        // public QeueofSMS qeueSMS  { get; set; }
        public List<long> idqeueSMS { get; set; }
    }
}
