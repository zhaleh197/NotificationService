using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.WriteModels.SMS.SMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.SMS.Common.Khat
{
    public class KhototUser:BaseEntity<long>
    { 
        //////////// Foreign key   
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; } 
       
        public long KhatNumber { get; set; }

        public virtual int IdSarKhat { get; set; }//link be sarkhat ha
         [ForeignKey("IdSarKhat")]
       // [ForeignKey("Id")]
        public virtual SarKhat SarKhat { get; set; }


        public bool Type { get; set; }//0==Omoomi . 1= Khososi
        public bool Statuse { get; set; }//Active-notAvtive

        public DateTime DedlineKhat { get; set; }// = insert time(NOW) year+1. baraye omoomi =null - baraye khososi = yek sal.
                                                 // in code: if(type=0) send.  elseif (type== 1){ if (dellinekhat>now) Send.}


        public virtual ICollection<SMessageS> SMessageS { get; set; }
        
    }
}

