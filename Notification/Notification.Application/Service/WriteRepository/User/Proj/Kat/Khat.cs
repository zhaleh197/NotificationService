using Notification.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Proj.Kat
{
    public class Khat : IKhat
    {
        private readonly IDatabaseContext _context;
        public Khat(IDatabaseContext context)
        {
            _context = context;
        }   

        public KhatModel GetKhatbyId(long id)
        {
            var t = _context.KhatSMS.Where(p => p.Id == id && p.IsRemoved == false).FirstOrDefault();
            KhatModel t1 = new KhatModel
            {
                Id=t.Id,
                IdSarKhat = t.IdSarKhat,
                Statuse = t.Statuse,
                LineNumber = t.LineNumber,
                IdProjects = t.IdProjects
            };
            return t1; 
        }

        public KhatModel GetKhatbyIdPro(long id)
    {
            var t = _context.KhatSMS.Where(p => p.IdProjects == id && p.IsRemoved == false).FirstOrDefault();
            KhatModel t1 = new KhatModel
            {
                IdSarKhat = t.IdSarKhat,
                Statuse = t.Statuse,
                LineNumber = t.LineNumber,
                IdProjects = t.IdProjects,
                Id=t.Id
            };
            return t1;
        }
        public  List<KhatModel> GetAllKhat()
        {
            var t = _context.KhatSMS.Where(p => p.IsRemoved == false).ToList();
            //var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.Projects).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);

            var ProsList = t.Select(p => new KhatModel
            {
                IdProjects=p.IdProjects,
                Statuse=p.Statuse,
                LineNumber=p.LineNumber,
                IdSarKhat=p.IdSarKhat,
                Id=p.Id
            }).ToList();
            return ProsList;
        }

        public long AddKhat(KhatModel pro)
        {
            var t = _context.KhatSMS.Add(new Domain.Entities.SMS.Common.KhatSMS
            {
                IdProjects=pro.IdProjects,
                IdSarKhat=pro.IdSarKhat,
                LineNumber=pro.LineNumber,
                Statuse=pro.Statuse,
                //User = _context.Users.Where(u => u.Id == pro.idUser).FirstOrDefault(),
                InsertTime = DateTime.Now,
                IsRemoved = false,
                RemoveTime = null,
                UpdateTime = null
            });

            _context.SaveChanges();
            return t.Entity.Id;
        }

        public long DeletKhat(long idpro)
        {

            _context.KhatSMS.Remove(_context.KhatSMS.Where(d => d.Id == idpro).FirstOrDefault());
            _context.SaveChanges();
            return idpro;
        }
         
    }
}
