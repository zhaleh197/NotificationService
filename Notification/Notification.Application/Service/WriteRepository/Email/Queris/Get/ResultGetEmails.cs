using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.Email.Queris.Get
{
    public class ResultGetClientEmails
    {
        public long Id { get; set; }
        public long IdClient { get; set; }
        public string Resiver { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateDelivere { get; set; }
        public string Status { get; set; }
    }
    public class ResultGetUserEmails
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Resiver { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateDelivere { get; set; }
        public string Status { get; set; }
    }
}
