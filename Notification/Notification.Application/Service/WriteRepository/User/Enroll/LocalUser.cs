using Microsoft.EntityFrameworkCore;
using Notification.Application.ApplicationbyMediator.UserApplication.Commands;
using Notification.Application.Interface.Context;
using Notification.Domain.Entities.Common;
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
                IdUser = request. IdUser,
                Phone=request. Phone,
                DeadlinePackage = request.DeadlinePackage,
                InsertTime=DateTime.Now,
                PackageTariff= _context.PackageTariff.Where(p => p.Id.Equals(request.IdPackagetariffSMS)).FirstOrDefault(),
                USerType = _context.Usertype.Where(p => p.Id.Equals(request.IdUsertype)).FirstOrDefault(),
                IsRemoved = false,
                RemoveTime = null,
                UpdateTime = null
            }; 
            _context.Users.Add(user);
            _context.SaveChanges();
            _context.SaveChangesAsync();
            
            return user.IdUser;

        }
        public Users GetuserbyIduser(long request, CancellationToken cancellationToken = default)
        {
          //  var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.Projects).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);

            var res = _context.Users.Include(s=>s.PackageTariff.PackageSMS).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r =>r.IdUser ==request);
            //var res = _context.Users.FirstOrDefault(r => r.IdUser == request);

            return res;
        }
        public long DeleteUser(long request, CancellationToken cancellationToken = default)
        {
            //var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.Projects).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);
            var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);

            _context.Users.Remove(res);
            _context.SaveChanges();
            _context.SaveChangesAsync();
            return request;

        }

    }
}
