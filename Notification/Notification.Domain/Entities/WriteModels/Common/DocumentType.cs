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
        public string Title { get; set; }// شناسنامه/ کارت ملی/ جواز/ فیش پرداختی/ مدارک احراز هویت
        
        //شاید. اینر ا 29/6/1401 اضافه کردم
        //n-1 ba DocumentsUser
        public virtual ICollection<DocumentsUser>? DocumentsUser { get; set; }
    }
}
