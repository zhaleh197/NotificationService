using Notification.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Transaction
{
    public class Transactionss : ITransactionss
    {
        private readonly IDatabaseContext _context;
        public Transactionss(IDatabaseContext context)
        {
            _context = context;
        }

        public TransactionModelGet GetTransactionbyId(long id)
        {
            var t = _context.Transactions.Where(p => p.Id == id && p.IsRemoved == false).FirstOrDefault();
            if (t != null)
            {
                TransactionModelGet t1 = new TransactionModelGet
                {
                    Id = t.Id,
                    IdUser = t.IdUser,
                    CodeRahgiriPardakht = t.CodeRahgiriPardakht,
                    Discription = t.Discription,
                    IsDone = t.IsDone,
                    NewCriditUser = t.NewCriditUser,
                    price = t.price,
                    TimeTransaction = t.TimeTransaction,
                    TitleTransaction = t.TitleTransaction,
                };
                return t1;
            }
            return null;
        }

        public TransactionModelGet GetTransactionbyIdUser(long id)
        {
            var t = _context.Transactions.Where(p => p.IdUser == id && p.IsRemoved == false).FirstOrDefault();
            if (t != null)
            {
                TransactionModelGet t1 = new TransactionModelGet
                {
                    Id = t.Id,
                    IdUser = t.IdUser,
                    CodeRahgiriPardakht = t.CodeRahgiriPardakht,
                    Discription = t.Discription,
                    IsDone = t.IsDone,
                    NewCriditUser = t.NewCriditUser,
                    price = t.price,
                    TimeTransaction = t.TimeTransaction,
                    TitleTransaction = t.TitleTransaction,
                };
                return t1;
            }
            return null;
        }
        public List<TransactionModelGet> GetAllTransaction()
        {
            var tt = _context.Transactions.Where(p => p.IsRemoved == false).ToList();
            if (tt != null)
            {
                var ProsList = tt.Select(t => new TransactionModelGet
            {
                Id = t.Id,
                IdUser = t.IdUser,
                CodeRahgiriPardakht = t.CodeRahgiriPardakht,
                Discription = t.Discription,
                IsDone = t.IsDone,
                NewCriditUser = t.NewCriditUser,
                price = t.price,
                TimeTransaction = t.TimeTransaction,
                TitleTransaction = t.TitleTransaction,
            }).ToList();
            return ProsList;
            }
            return null;
        }

        public long AddTransaction(TransactionModel t)
        { 
                var res = _context.Transactions.Add(new Domain.Entities.WriteModels.Common.Transaction
                {
                    IdUser = t.IdUser,
                    CodeRahgiriPardakht = t.CodeRahgiriPardakht,
                    Discription = t.Discription,
                    IsDone = t.IsDone,
                    NewCriditUser = t.NewCriditUser,
                    price = t.price,
                    TimeTransaction = t.TimeTransaction,
                    TitleTransaction = t.TitleTransaction,
                });

                _context.SaveChanges();
                return res.Entity.Id; 
        }

     


        public long DeletTRansaction(long id )
        {

            _context.Transactions.Remove(_context.Transactions.Where(d => d.Id == id ).FirstOrDefault());
           // _context.SaveChangesAsync();
            _context.SaveChanges();
           // _context.SaveChangesAsync();
            return id ;
        }

    }
}
