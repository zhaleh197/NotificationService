using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.Common
{
    public class Ticket:BaseEntity<long>
    { 
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }


        public string TitleQuestion { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public virtual long IdOperator { get; set; }
        public string Statuse { get; set; }//باز// اتمام
    }
}
