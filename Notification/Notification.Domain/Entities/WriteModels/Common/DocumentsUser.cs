using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Common
{
    public class DocumentsUser: BaseEntity<long>
    {
        //[Key]
        //public long Id { get; set; }
        public virtual long IdUser { get; set; }

        [ForeignKey("IdUser")]
        public virtual Users User { get; set; }


        public virtual long IdDocumentType { get; set; }

        [ForeignKey("IdDocumentType")]
        public virtual DocumentType DocumentType { get; set; }


        public string PathofSave { get; set; }
        public bool Confirmcheck { get; set; }


    }
}
