using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.SMS.Common; 
using Notification.Domain.Entities.WriteModels.Common;
using Notification.Domain.Entities.WriteModels.SMS.Common;
using Notification.Domain.Entities.WriteModels.SMS.Common.Khat;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
using Notification.Domain.Entities.WriteModels.SMS.SMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Common
{
    public class Users:BaseEntity<long>
    {
        public long IdUser { get; set; }
        public string? Phone { get; set; }
        public long IdRole { get; set; }//baraye kam kardane pichidegi
        //==
        //public virtual long IdRole { get; set; }
        //[ForeignKey("IdRole")]
        //public virtual Role Role { get; set; }


        //14010603
        public long CreditFinance { get; set; }//Etebar// Mr Nazari saied here isnt any things of Wallet to save in here.
        public long CridetMeaasage { get; set; }// 100 message


        //public long IdUSerType { get; set; }//baraye kam kardane pichidegi
        ////==
        public  int IdUSerType { get; set; }
        [ForeignKey("IdUSerType")]
        //[ForeignKey("Id")]
        public virtual Usertype USerType { get; set; }


        public long IdPackageTariff { get; set; }
        [ForeignKey("IdPackageTariff")]
       // [ForeignKey("Id")]
        public virtual PackageTariff? PackageTariff { get; set; }




         
        //n-n ba khat
        public virtual ICollection<KhototUser>? KhototUser { get; set; }
        //public DateTime DeadlinePackage { get; set; }//manzol DedlineKhat ast dar //bordan dar table khotoot


        //mande
        //public virtual ICollection<SMSUser>? SMSUser { get; set; }
        public virtual ICollection<SMessageS>? SMessageS { get; set; }


        //n-n ba patternSMS
        public virtual ICollection<PatternSMS>? PatternSMs { get; set; } //درسته پاکش نکنی. ان ب ان است

        //n-1 ba Ticket
        public virtual ICollection<Ticket>? Tickets { get; set; }

        //n-1 ba Transactionc
        public virtual ICollection<Transaction>? Transactions { get; set; }

        //n-1 ba DocumentsUser
        public virtual ICollection<DocumentsUser>? DocumentsUser { get; set; }

        //14010422 // chetor yadam rafte bood!!// n-1 
        public virtual ICollection<QeueofSMS>? QeueofSMS { get; set; }

    }
}
