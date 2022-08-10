using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.SMS
{
    public class QeueSMSClient : BaseEntity<long>
    {
        ////[Key]
        ////public long Id { get; set; }
        //public long IdClient { get; set; }



        //    [Key]
        //    public long Id { get; set; }

        //////////// Foreign key   
        public virtual long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Users Users { get; set; }
        ////////////
        ///
        //public long IdUser { get; set; }




        public string Resiver { get; set; }
        public string Body { get; set; }
        public DateTime DateSendStart { get; set; }
        public string Periority { get; set; }
        public string Type { get; set; }
    }
}
