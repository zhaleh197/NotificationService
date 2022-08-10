using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.SMS.SMS
{
    public class SMS_Resivers
    {
        [Key]
        public long Id { get; set; }


        public virtual long IdSMS { get; set; }

        [ForeignKey("IdSMS")]
        public virtual SMSUser SMSUser { get; set; }   


        public string Resiver { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime DateDelivere { get; set; }
        public string SendStatus { get; set; }

    }
}
