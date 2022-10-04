using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Transaction
{
    public interface ITransactionss
    {
        public TransactionModelGet GetTransactionbyId(long id);
        public TransactionModelGet GetTransactionbyIdUser(long id);
        public List<TransactionModelGet> GetAllTransaction();
        public long AddTransaction(TransactionModel t);
        public long DeletTRansaction(long idpro);
    }
}
