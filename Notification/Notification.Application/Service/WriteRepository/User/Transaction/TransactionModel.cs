using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Transaction
{
    public class TransactionModel
    {
        public  long IdUser { get; set; }
        public string TitleTransaction { get; set; }
        public long price { get; set; }
        public bool IsDone { get; set; }//1= انجام شد. 2= انجام نشد.
        public string? CodeRahgiriPardakht { get; set; }
        public long NewCriditUser { get; set; }
        public DateTime TimeTransaction { get; set; }
        public string? Discription { get; set; }
    }
    public class TransactionModelGet
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string TitleTransaction { get; set; }
        public long price { get; set; }
        public bool IsDone { get; set; }//1= انجام شد. 2= انجام نشد.
        public string? CodeRahgiriPardakht { get; set; }
        public long NewCriditUser { get; set; }
        public DateTime TimeTransaction { get; set; }
        public string? Discription { get; set; }

    }
}
