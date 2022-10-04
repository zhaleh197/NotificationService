using Notification.Domain.Entities.WriteModels.SMS.SMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.SMS.SMS
{
    public class SMS_Resivers
    {
        [Key]
        public long Id { get; set; }


        public virtual long IdSMS { get; set; }
        [ForeignKey("IdSMS")]
        //[ForeignKey("Id")]
        public virtual SMessageS SMessageS { get; set; }   


        public string Resiver { get; set; }
        //new 14010606
        public int TypeofResiver { get; set; }//0 =number . 1 = Userid
        public DateTime DateSended { get; set; }
        public DateTime DateDelivered { get; set; }
        public int Deliverd { get; set; }

        public string? SendStatus { get; set; } 

    }
}
