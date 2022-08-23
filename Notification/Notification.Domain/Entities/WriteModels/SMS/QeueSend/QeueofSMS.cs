using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.SMS.QeueSend
{
    public class QeueofSMS:BaseEntity<long>
    {

        [Key]
        public long Id { get; set; }

        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }

        public string txt { get; set; }
        public string to { get; set; }
        public bool TypeofResiver { get; set; }//0 =number . 1 = Userid

        //public DateOnly dateOfsend { get; set; }
        //public TimeOnly timeOfsend { get; set; }

        //[DataType(DataType.Date)]
        //[Column(TypeName = "Date")]
        //public DateTime dateOfsend { get; set; }


        //[DataType(DataType.Time)]
        //public TimeSpan timeOfsend { get; set; }


        public string dateOfsend { get; set; }
        public string timeOfsend { get; set; }

        public string dateofLimitet { get; set; }

        public int periority { get; set; }//hidh-normal
        public string periodSendly { get; set; }// none-diaily- hourly- mounthly- yearly

 
         
         


    }
}
