using Notification.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Domain.Entities.WriteModels.SMS.Common
{
    public class PatternSMS : BaseEntity<long>
    {
        public string? TitlePattern { get; set; }
        public string? TextPatern { get; set; }
        public int NumberofVariable { get; set; }

        //n-n ba user . har user chan patetrn. har pattern mal chand user
        public virtual ICollection<Users>? User { get; set; }
    }
}
