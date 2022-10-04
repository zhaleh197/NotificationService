using Microsoft.EntityFrameworkCore;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands;
using Notification.Application.Interface.Context;
using Notification.Domain.Entities.Common;
using Notification.Domain.Entities.WriteModels.SMS.Common.Khat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Enroll
{
    public class LocalUser : ILocalUser
    {
        private readonly IDatabaseContext _context;
        public LocalUser(IDatabaseContext context)
        {
            _context = context;
        }
        //public long UserEnroll2(userCommand request)
        //{


        //    Users user = new Users()
        //    {
        //        IdUser = request.IdUser,
        //        DeadlinePackage = request.DeadlinePackage,
        //        InsertTime = DateTime.Now,
        //        PackageTariff = _context.PackageTariff.Where(p => p.Id.Equals(request.IdPackagetariffSMS)).FirstOrDefault(),
        //        USerType = _context.Usertype.Where(p => p.Id.Equals(request.IdUsertype)).FirstOrDefault(),
        //        IsRemoved = false,
        //        RemoveTime = null,
        //        UpdateTime = null
        //    };
        //    _context.Users.Add(user);

        //    _context.SaveChanges();
        //    return user.IdUser;

        //}
        public long UserEnroll(LocalUserMOdel request)
        {
            Users user = new Users()
            {
                IdUser = request.IdUser,
                Phone = request.Phone,
                CreditFinance = 0,
                CridetMeaasage = 0,
                IdRole = request.IdRole,
                //IdPackageTariff=0,
                IdUSerType = request.IdUsertype,
                IdPackageTariff = 4,

            };
            _context.Users.Add(user);
            _context.SaveChanges();
            _context.SaveChangesAsync();
            return user.IdUser;

        }
        public Users GetuserbyIduser(long request, CancellationToken cancellationToken = default)
        {
            //  var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.Projects).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);

            var res = _context.Users.Include(s => s.PackageTariff).Include(s => s.DocumentsUser).Include(s => s.Transactions).Include(s => s.SMessageS).Include(s => s.KhototUser).Include(s => s.PatternSMs).Include(s => s.Tickets).FirstOrDefault(r => r.IdUser == request);
            //var res = _context.Users.FirstOrDefault(r => r.IdUser == request);
            if (res != null)
                return res;
            else return null;

        }

        public string Gettypeofuser(long request)
        {
            var res = _context.Usertype.Where(r => r.Id == request).FirstOrDefault().Title;
            if (res != null)
                return res;
            else return null;

        }

        public string GetRoleofuser(long request)
        {
            var res = _context.Roles.Where(r => r.Id == request).FirstOrDefault().Title;
            if (res != null)
                return res;
            else return null;

        }

        public List<KhototUser> GetKhototUser(long request)
        {
            var res = _context.KhototUsers.Where(r => r.IdUser == request).ToList();
            if (res != null)
                if (res.Count() > 0)
                    return res;
                else return null;
            return null;
        }
        //public List<string> GetKhototUserstring(long request)
        //{
        //    var res = _context.KhototUsers.Where(r => r.IdUser == request);
        //    if (res != null)
        //        return res;
        //    else return null;

        //}


        public long DeleteUser(long request, CancellationToken cancellationToken = default)
        {
            var res = _context.Users.FirstOrDefault(r => r.IdUser == request);
            if (res != null)
            {
                _context.Users.Remove(res);
                _context.SaveChanges();
                _context.SaveChangesAsync();
            }
            return request;

        }

        public long EditUSer(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return 1;
        }


        public long EditPrice(long userid, long newprice)
        {


            var res = _context.Users.Include(s => s.PackageTariff).Include(s => s.DocumentsUser).Include(s => s.Transactions).Include(s => s.SMessageS).Include(s => s.KhototUser).Include(s => s.PatternSMs).Include(s => s.Tickets).FirstOrDefault(r => r.IdUser == userid);
            if (res != null)
            {
                res.CreditFinance = newprice;

                return res.IdUser;
            }
            return 0;
        }
        public List<PackageTariffModl> Getallpackages()
        {
            var t = _context.PackageTariff.ToList();
            var ProsList = t.Select(p => new PackageTariffModl
            {
                Id = p.Id,
                PricePackage = p.PricePackage,
                TitlePackage = p.TitlePackage,
                ZaridTakhfifPaciTareeffe = p.ZaridTakhfifPaciTareeffe
            }).ToList();
            return ProsList;
        }

        public long EditPriceandMessageandpackage(long userid,long oldprice, long price )
        {
            var res = _context.Users.Include(s => s.PackageTariff).Include(s => s.DocumentsUser).Include(s => s.Transactions).Include(s => s.SMessageS).Include(s => s.KhototUser).Include(s => s.PatternSMs).Include(s => s.Tickets).FirstOrDefault(r => r.IdUser == userid);

            var newprice = oldprice + price;


            var packages = Getallpackages();
            double o = 0;
            long idp = 0;
            var gh = 77;//ghaymat base ba sarkhat 1000.

            if (price > 0)
            {
                int maxValue = (int)packages[0].PricePackage;
                int maxIndex = 0;
                for (int p = packages.Count - 1; p > 0; p--)
                {
                    if (maxValue <= packages[p].PricePackage)
                    {
                        maxValue = (int)packages[p].PricePackage;
                        maxIndex = p;
                    }
                    if (newprice == packages[p].PricePackage)
                    {
                        idp = p; break;
                    }
                    else if (newprice < packages[p].PricePackage)
                    {
                        idp = p + 1; break;
                    }
                    else if (p == 1 && idp == 0)
                    {
                        maxIndex = p;
                        idp = maxIndex;
                    }

                }
                 o = packages[(int)idp].ZaridTakhfifPaciTareeffe;
            }
            else
            {
                  o = res.PackageTariff.ZaridTakhfifPaciTareeffe;
            }
            if (res != null)
            {
                var newmessage = Math.Ceiling((double)newprice / (o*gh));

                res.CreditFinance = newprice;

                if (price > 0)
                    res.IdPackageTariff = packages[(int)idp].Id;
                //if (newprice <= 0)
                //    res.IdPackageTariff = res.PackageTariff.Id;

                res.CridetMeaasage = Convert.ToInt64( newmessage);
                _context.Users.Update(res);

                _context.SaveChanges();

                return res.IdUser;
            }
            return 0;
        }


    }
}
