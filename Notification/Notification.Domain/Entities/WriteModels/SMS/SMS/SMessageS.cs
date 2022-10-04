using Notification.Domain.Entities.Common; 
using Notification.Domain.Entities.WriteModels.SMS.Common;
using Notification.Domain.Entities.WriteModels.SMS.Common.Khat;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.SMS.SMS
{
    public class SMessageS
    {
          [Key]
        public long Id { get; set; }

        //from
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }
        // to is in SMS_REsivers

        public string Txt { get; set; } = string.Empty;

       
        public int CountSms { get; set; }
        //تعداد پیام= تعداد کاراکتر/ تعداد کاراکترها برای یک پیام فارسی یا انگلیسی 

        public double Price { get; set; }// maybe several sms. so Sum of SMS.
        //تعداد پیام * تعرفه هر پیام = هزینه ارسال


                                    //if once = it is == datesend or null.

        public virtual long IdTypeSMS { get; set; }
         [ForeignKey("IdTypeSMS")]
       // [ForeignKey("Id")]
        public virtual TypeSMS? TypeSMS { get; set; } // if null=> the type is sayer


        public string? DateOfsend { get; set; }//if null , send Now.
        public string? TimeOfsend { get; set; }//if null , send Now.

        public string? DateofLimitet { get; set; }//if null, a day after Now. thas logicsal.


        public string PeriodSendly { get; set; } = "Once";// none-diaily- hourly- mounthly- yearly
       // public int IdKhatSend { get; set; }

        public long KhatSend { get; set; }
       // public long IdKhatSend { get; set; }

        //[ForeignKey("Id")]
        //[ForeignKey("IdKhatSend")]
        //public virtual KhototUser KhototUser { get; set; }





        public virtual ICollection<SMS_Resivers> SMS_Resivers { get; set; }
 


    }
}
