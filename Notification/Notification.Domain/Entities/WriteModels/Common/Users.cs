using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.SMS.Common;
using Notification.Domain.Entities.SMS.SMS;
using Notification.Domain.Entities.WriteModels.SMS.QeueSend;
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

        // public long Credit { get; set; }//Etebar// Mr Nazari saied here isnt any things of Wallet to save in here.

        public virtual long IdUSerType { get; set; }

        [ForeignKey("IdUSerType")]
        public virtual Usertype USerType { get; set; }



        public virtual long IdPackageTariff { get; set; }

        [ForeignKey("IdPackageTariff")]
        public virtual PackageTariff PackageTariff { get; set; }
        public DateTime DeadlinePackage { get; set; }

        // public virtual Projects projects { get; set; }  // dar project id user ra gozashteiim



        //////////// Foreign key   
        //public virtual long IdSarKhat { get; set; }
        //[ForeignKey("Id")]
        //public virtual SarKhat SarKhat  { get; set; }
        //////////////
        ///
        //m-n
        //public virtual ICollection<SarKhat> SarKhat { get; set; }//delet for solve cycle


       // public virtual ICollection<Projects> Projects { get; set; }


      

        //14010421// nmidonam
        public virtual ICollection<DocumentsUser> DocumentsUser { get; set; }

        //14010422 // chetor yadam rafte bood!!
        public virtual ICollection<SMSUser> SMSUser { get; set; }

        public virtual ICollection<QeueofSMS> QeueofSMS { get; set; }

    }
}
