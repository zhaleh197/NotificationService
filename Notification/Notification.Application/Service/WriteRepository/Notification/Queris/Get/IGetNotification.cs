using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.Notification.Queris.Get
{
    public interface IGetNotification
    {
        //public List<ResultGetClientNotification> GetClientNotification();
        public List<ResultGetUserNotification> GetUserNotification();

    }

}
