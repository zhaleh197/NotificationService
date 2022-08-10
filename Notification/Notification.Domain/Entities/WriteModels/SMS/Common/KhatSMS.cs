using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.SMS.SMS;

namespace Notification.Domain.Entities.SMS.Common
{
    public class KhatSMS: BaseEntity<long>
    {
        //[Key]
        //public long Id { get; set; }

        //public  long IdSarKhat { get; set; }
        public virtual long IdSarKhat { get; set; }
        [ForeignKey("IdSarKhat")]
        public virtual SarKhat SarKhat { get; set; }


        public string LineNumber { get; set; }
        public bool Statuse { get; set; }//Active-notAvtive


        public virtual long IdProjects { get; set; }

        [ForeignKey("IdProjects")]
        public virtual Projects Projects { get; set; }


        //public virtual ICollection<Projects> Projects { get; set; }


       // public virtual ICollection<SMSUser> SMSUser { get; set; }
        

    }
}
