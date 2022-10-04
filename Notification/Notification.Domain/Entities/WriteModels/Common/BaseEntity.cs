using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.Common
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; } = null;
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; } = null;
    }
}
