using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.SMS
{
    public class SMSClient : BaseEntity<long>
    {

        //[Key]
        //public long Id { get; set; }
        public long IdClient { get; set; }
        public string Resiver { get; set; }
        public string Body { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateDelivere { get; set; }
        public string Status { get; set; }
    }
}
