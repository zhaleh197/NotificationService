using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.Notification.Queris.Get
{
    public class ResultGetClientNotification
    {
        public long Id { get; set; }
        public long IdClient { get; set; }
        public string Resiver { get; set; }
        public string Icon { get; set; }
        public string Body { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateDelivere { get; set; }
        public string Status { get; set; }
    }
    public class ResultGetUserNotification
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Resiver { get; set; }
        public string Icon { get; set; }
        public string Body { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateDelivere { get; set; }
        public string Status { get; set; }
    }
}
