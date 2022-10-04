using Notification.Domain.Entities.SMS.Common;
using Notification.Domain.Entities.WriteModels.SMS.Common.Khat;
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
        public string TitleProject { get; set; }

        public string Description { get; set; }

       // public long IdUser { get; set; }
        //public long KhototUser { get; set; }
        public virtual long IdKhototUser { get; set; }
         [ForeignKey("IdKhototUser")]
        //[ForeignKey("Id")]
        public virtual KhototUser KhototUser { get; set; }
    }
}
