using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.Queris.Get
{
    public interface IGetSMS
    {
        public List<ResultGetUserSMS> GetUserSMS();
        public List<ResultGetClientSMS> GetClientSMS();

        public List<ResultGetQeueUserSMS> GetQeueUserSMS();
        public List<ResultGetQeueClientSMS> GetQeueClientSMS();



    }
}
