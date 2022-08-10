using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Notification.Application.Service.SMS.Queris.Post.RequestPostSMS;

namespace Notification.Application.Service.SMS.Queris.Post
{
    public interface IPostSMS
    {
       // public int PostUserSMS(RequestSMSUser request);
        public long PostUserSMS(RequestSMSUser request);
        public int PostUserSMSinQu(RequestQeueSMSUser request);
    }
}
