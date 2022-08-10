using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.SMS.Common
{
    public class StockSMS : BaseEntity<long>
    {
        //    [Key]
        //    public long Id { get; set; }

        //////////// Foreign key   
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }
        ////////////
        ///
        //public long IdUser { get; set; }




        public string TitleStockMessage { get; set; }
        public string StockMessage { get; set; }
    }
}
