using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Common
{
    public class DocumentType: BaseEntity<long>
    {
        //[Key]
        //public long Id { get; set; }
        public string Title { get; set; }// haghigghi / hoghooghi

    }
}
