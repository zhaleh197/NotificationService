using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.SMS.Common;
using Notification.Domain.Entities.SMS.QeueSend;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.SMS.SMS
{
    public class SMSUser : BaseEntity<long>
    {
        //    [Key]
        //    public long Id { get; set; }

        //////////// Foreign key   
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }
        ////////////
        ///
        //public long IdUser {
        //
        //get; set; }


        ///14010402
        ///
        //public virtual long IdKhatSMS { get; set; }
        //[ForeignKey("IdKhatSMS")]
        //public virtual KhatSMS KhatSMS { get; set; }
        //in 14010422 this is deleted. beacuse khat available by user->project->khat.
        /// 


        public string Body { get; set; }//text


        //tashkhis dadam bebaram dakhel SMS_RESIVER 14010420

        //public DateTime DateSend { get; set; }
        //public DateTime DateDelivere { get; set; }
        //public string SendStatus { get; set; }


        public int Price { get; set; }// maybe several sms. so Sum of SMS.
        //تعداد پیام= تعداد کاراکتر/ تعداد کاراکترها برای یک پیام فارسی یا انگلیسی 
        //تعداد پیام * تعرفه هر پیام = هزینه ارسال
        // public string Resiver { get; set; } // in re dar jadvalii digar minevisam baraye handel kardan ersal Grohiii


        public virtual ICollection<SMS_Resivers> SMS_Resivers { get; set; }
        public virtual ICollection<QeueSMS> QeueSMSUser { get; set; }
        
    }
}
