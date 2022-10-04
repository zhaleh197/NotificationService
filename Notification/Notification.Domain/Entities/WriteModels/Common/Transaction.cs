using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.Common
{
    public class Transaction : BaseEntity<long>
    {
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }
        public string TitleTransaction { get; set; }
        public long price { get; set; }
        public bool IsDone { get; set; }//1= انجام شد. 2= انجام نشد.
        public string? CodeRahgiriPardakht { get; set; } 
        public long NewCriditUser { get; set; }
        public DateTime TimeTransaction { get; set; }

        public string? Discription { get; set; }
    }
}
