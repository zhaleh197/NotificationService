using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.SMS.SMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.SMS.QeueSend
{
   public class QeueSMS : BaseEntity<long> // lastmodel
    { 
          

        /*
        //    [Key]
        //    public long Id { get; set; }

        //////////// Foreign key   
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }
        ////////////
        ///
        //public long IdUser { get; set; }



        public string Resiver { get; set; }
        public string Body { get; set; }
        public DateTime DateSendStart { get; set; } 
        public string Periority { get; set; }
        public string Type { get; set; }
        */

        [Key]
        public long Id { get; set; }


        public virtual long IdSMS { get; set; }

        [ForeignKey("IdSMS")]
        public virtual SMSUser SMSUser { get; set; }


        public DateTime DateSendStart { get; set; }
        public string Periority { get; set; }//high/low/mediom
        public string Type { get; set; }//??user/phone



        //public virtual long IdSMSREsiver { get; set; }
        //[ForeignKey("IdSMSREsiver")]
        //public virtual SMS_Resivers SMS_Resivers { get; set; }



        //public string Resiver { get; set; }
        //public DateTime DateSend { get; set; }
        //public DateTime DateDelivere { get; set; }
        //public string SendStatus { get; set; }


    }
}
