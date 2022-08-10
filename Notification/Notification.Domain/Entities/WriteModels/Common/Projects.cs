using Notification.Domain.Entities.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Common
{
    public class Projects: BaseEntity<long>
    {

        //[Key]
        //public long Id { get; set; }
        public string TitleProject { get; set; }

        public string Description { get; set; }

        public virtual long IdUser { get; set; }

        //[ForeignKey("IdUser")]
        //public virtual Users User { get; set; }

        public virtual ICollection<KhatSMS> KhatSMS { get; set; }
    }
}
