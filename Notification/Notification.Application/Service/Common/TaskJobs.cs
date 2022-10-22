using Notification.Application.Service.SMS.Queris.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Notification.Application.Service.SMS.Queris.Post.RequestPostSMS;

namespace Notification.Application.Service.Common
{
    public class TaskJobs: ITaskJobs
    {
        public Queue<RequestSendSMS> Qeuetask { get; set; }
    }
}
