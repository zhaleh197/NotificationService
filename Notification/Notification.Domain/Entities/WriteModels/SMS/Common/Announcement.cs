using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Domain.Entities.Common;
namespace Notification.Domain.Entities.SMS.Common
{
    public class Announcement : BaseEntity<long>// Class for show Agahi and Event message
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




        public string TxtAnnouncement { get; set; }
        public DateTime DateStartshow { get; set; }
        public DateTime DateEndtshow { get; set; }
        public bool IsActive { get; set; }

    }
}
