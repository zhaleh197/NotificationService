using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.Common
{
    public class Role:BaseEntity<long>
    {
        //[Key]
        //public long Id { get; set; }
        public string Title { get; set; }// مدیر/ اپراتور/ خریدار

    }
}
