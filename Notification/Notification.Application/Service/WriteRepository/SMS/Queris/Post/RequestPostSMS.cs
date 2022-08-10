
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.SMS.Queris.Post
{
    public class RequestPostSMS
    {

        //OLD
        //public class RequestSMSUser
        //{
        //    public virtual long IdUser { get; set; }
        //    public List<string> Resiver { get; set; }
        //    public string Body { get; set; }
        //    public DateTime DateSend { get; set; }
        //    public DateTime DateDelivere { get; set; }
        //    public string Status { get; set; }
        //}
        //New 14010504
        public class RequestSMSUser
        {
            public virtual long IdUser { get; set; }
            public string Resiver { get; set; }
            public string Body { get; set; }
            public DateTime DateSend { get; set; }
            public DateTime DateDelivere { get; set; }
            public string Status { get; set; }
        }
        public class RequestQeueSMSUser
        {
            public virtual long IdSMS { get; set; }
            public DateTime DateSendStart { get; set; }
            public string Periority { get; set; }//high/low/mediom
            public string Type { get; set; }//??user/phone

           // public string Resiver { get; set; }
            public List<string> Resiver { get; set; }
            public DateTime DateSend { get; set; }
            public DateTime DateDelivere { get; set; }
            public string SendStatus { get; set; }


        }


    }
}
