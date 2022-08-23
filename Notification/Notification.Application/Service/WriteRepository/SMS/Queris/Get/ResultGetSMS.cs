using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.Queris.Get
{
        public class ResultGetClientSMS
        {
            public long Id { get; set; }
            public long IdClient { get; set; }
            public string Resiver { get; set; }

            public string Body { get; set; }
            public DateTime DateSend { get; set; }
            public DateTime DateDelivere { get; set; }
            public string Status { get; set; }
        }
        public class ResultGetUserSMS
        {
            public long Id { get; set; }
            public long IdUser { get; set; }
            //public string Resiver { get; set; }
            public List<string> Resiver { get; set; } //for send Grohi
             public string Body { get; set; }
            public DateTime DateSend { get; set; }
            public DateTime DateDelivere { get; set; }
            public string Status { get; set; }
        }

        public class ResultGetQeueClientSMS
    {
        public long Id { get; set; }
        public long IdClient { get; set; }
        public string Resiver { get; set; }
        public string Body { get; set; }
        public DateTime DateSendStart { get; set; }
        public string Periority { get; set; }
        public string Type { get; set; }
    }


        public class ResultGetQeueUserSMS
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
       // public string Resiver { get; set; }
        public List<string> Resiver { get; set; }
        public string Body { get; set; }
        public DateTime DateSendStart { get; set; }
        public int Periority { get; set; }
        public string Type { get; set; }
    }



}
