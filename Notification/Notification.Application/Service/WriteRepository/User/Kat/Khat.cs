using Microsoft.EntityFrameworkCore;
using Notification.Application.Interface.Context;

namespace Notification.Application.Service.WriteRepository.User.Kat
{
    public class Khat : IKhat
    {
        private readonly IDatabaseContext _context;
        public Khat(IDatabaseContext context)
        {
            _context = context;
        }

        public List<PublicKhatModelGet> GetAllKhatOmoomi()
        {
            var t = _context.PublicKhotots.ToList();
            var ProsList = t.Select(p => new PublicKhatModelGet
            {
                Id = p.Id,
                IdSarKhat = p.IdSarKhat,
                 LengthofNumber = p.LengthofNumber,
                 LineNumber=p.LineNumber,
                 Statuse=p.Statue
            }).ToList();
            return ProsList;
        }
        public List<KhososiKhatModelGet> GetAllKhatKhososiProperties()
        {
            var t = _context.SpacitalKhotots .ToList();
            var ProsList = t.Select(p => new KhososiKhatModelGet
            {
                Id = p.Id,
                IdSarKhat = p.IdSarKhat,
                LengthofNumber = p.LengthofNumber,
                Price=p.Price
            }).ToList();
            return ProsList;
        }
        public List<KhososiKhatModelGet> GetKhatKhososibySarkhat(string sarkhat)
        {
            var t = _context.SpacitalKhotots.Where(r=>r.SarKhat.SarKhatNumber==sarkhat).ToList();
            var ProsList = t.Select(p => new KhososiKhatModelGet
            {
                Id = p.Id,
                IdSarKhat = p.IdSarKhat,
                LengthofNumber = p.LengthofNumber,
                Price = p.Price
            }).ToList();
            return ProsList;
        }
        public List<KhososiKhatModelGet> GetKhatKhososibyJustLenghofkhat(int lentofkhat)
        {
            var t = _context.SpacitalKhotots.Where(r => r.LengthofNumber==lentofkhat).ToList();
            var ProsList = t.Select(p => new KhososiKhatModelGet
            {
                Id = p.Id,
                IdSarKhat = p.IdSarKhat,
                LengthofNumber = p.LengthofNumber,
                Price = p.Price
            }).ToList();
            return ProsList;
        }
        public long GetPricekhossosibysarkhatandlenghNumber(PriceKhatkhososiREquest req)
        {
            var t = _context.SpacitalKhotots.Include(p => p.SarKhat).Where(p => p.SarKhat.SarKhatNumber == req.SarKhat && p.LengthofNumber == req.LengthofNumber).FirstOrDefault();
            if (t != null)
            {
                return t.Price;
            }
            return -1;
        }

        //////////////////////////////////////////////
        public KhatModelGet GetKhatbyIdUser(long id)
        {
            var t = _context.KhototUsers.Where(p => p.IdUser == id && p.IsRemoved == false).FirstOrDefault();

            if (t != null)
            {
                KhatModelGet t1 = new KhatModelGet
                {
                    Id = t.Id,
                    IdSarKhat = t.IdSarKhat,
                    Statuse = t.Statuse,
                    LineNumber = t.KhatNumber,
                    IdUser = t.IdUser,
                    DedlineKhat = t.DedlineKhat,
                    Type = t.Type
                };
                return t1;
            }
            return null;
        }
        public List<KhatModelGet> GetAllKhatUsers()
        {
            var t = _context.KhototUsers.Where(p => p.IsRemoved == false).ToList();
            //var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.Projects).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);

            var ProsList = t.Select(p => new KhatModelGet
            {
                Id = p.Id,
                IdSarKhat = p.IdSarKhat,
                Statuse = p.Statuse,
                LineNumber = p.KhatNumber,
                IdUser = p.IdUser,
                DedlineKhat = p.DedlineKhat,
                Type = p.Type
            }).ToList();
            return ProsList;
        }
        public long AddKhat(KhatModel t)
        {
            var user = _context.Users.Include(s => s.PackageTariff).Include(s => s.DocumentsUser).Include(s => s.Transactions).Include(s => s.SMessageS).Include(s => s.KhototUser).Include(s => s.PatternSMs).Include(s => s.Tickets).FirstOrDefault(r => r.IdUser == t.IdUser);
            // var doc = _context.DocumentsUser.Where(d => d.IdUser == t.IdUser && d.Id == 6).FirstOrDefault();//6=خرید خط 
            if (user != null)
                if (user.IdUSerType == 1)// if user is Hoghogh //تنها برای کاربران حقوقی خرید خط عمومی امکان پذیر است
                {
                    //check shavad aya pardakht anjam shode???
                    var Idtr = _context.Transactions.Where(tt => tt.Id == t.IdTransaction).FirstOrDefault();
                    if (Idtr != null)// اگر هزینه را پرداخت کرده و تراکنشش ثبت موجود است، خط برایش ثبت شود
                    {
                        //if (doc != null)
                        //    if (doc.Confirmcheck) //اگر مدارک ارسالی او مورد تایید است ارسال شود.
                        //{
                        var res = _context.KhototUsers.Add(new Domain.Entities.WriteModels.SMS.Common.Khat.KhototUser
                        {
                            IdSarKhat = t.IdSarKhat,
                            Statuse = t.Statuse,
                            KhatNumber = t.LineNumber,
                            IdUser = t.IdUser,
                            DedlineKhat = t.DedlineKhat,
                            Type = t.Type
                        });

                       // _context.SaveChangesAsync();
                        _context.SaveChanges();
                       // _context.SaveChangesAsync();
                        return res.Entity.Id;
                    }
                    // }
                }
            return 0;
        }
        public long ConfirmKhat(KhatModelGet t)
        {
            var doc = _context.DocumentsUser.Where(d => d.IdUser == t.IdUser && d.Id == 6).FirstOrDefault();//6=خرید خط 
            if (doc != null)
            {
                if (doc.Confirmcheck) //اگر مدارک ارسالی او مورد تایید است ارسال شود.
                {
                    
                    var Result=_context.KhototUsers.Where(d => d.Id == t.Id).FirstOrDefault();
                    if (Result != null)
                    {
                        Result.Statuse = true;
                       // _context.SaveChangesAsync();
                        _context.SaveChanges();
                       // _context.SaveChangesAsync();
                        return t.Id;
                    }
                }
            }
            return 0;

        }
        public long DeletKhat(long idpro)
        {
            var resulr = _context.KhototUsers.Where(d => d.Id == idpro).FirstOrDefault();
            if (resulr != null)
            {
                _context.KhototUsers.Remove(resulr);
               // _context.SaveChangesAsync();
                _context.SaveChanges();
               // _context.SaveChangesAsync();
                return idpro;
            }
            return 0;
        }

        public KhatModelGet GetKhatbyId(long id)
        {
            var t = _context.KhototUsers.Where(p => p.Id == id && p.IsRemoved == false).FirstOrDefault();
            KhatModelGet t1 = new KhatModelGet
            {
                Id = t.Id,
                IdSarKhat = t.IdSarKhat,
                Statuse = t.Statuse,
                LineNumber = t.KhatNumber,
                IdUser = t.IdUser,
                DedlineKhat = t.DedlineKhat,
                Type = t.Type
            };
            return t1;
        }
    }
}
