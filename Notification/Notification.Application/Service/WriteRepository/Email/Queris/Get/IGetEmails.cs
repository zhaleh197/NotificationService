using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.Email.Queris.Get
{
    public interface IGetEmails
    {
        //public List<ResultGetClientEmails> GetClientEmail();
        public List<ResultGetUserEmails> GetUserEmail();

    }

}
