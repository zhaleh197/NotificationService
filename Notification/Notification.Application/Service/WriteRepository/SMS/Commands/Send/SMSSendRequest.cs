using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.Commands
{
    public class SMSSendRequest
    {
        public string sender { get; set; }
        public string to { get; set; }
        public string txt { get; set; }
        public string apikey { get; set; }
    }
    public class SMSSendRequest2
    {
        public string to { get; set; }
        public string txt { get; set; }
    }
    public class SMSSendRequest3
    {
        public string to { get; set; }
        public string txt { get; set; }
        public string sender { get; set; }

    }

    public class SMSSendResponse
    {
        public string statuse { get; set; }
        public DateTime datesend { get; set; }
        public DateTime deliverd { get; set; }

    }

}
