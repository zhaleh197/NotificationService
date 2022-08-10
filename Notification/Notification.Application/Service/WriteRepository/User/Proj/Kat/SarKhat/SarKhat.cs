using Notification.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Proj.Kat.SarKhat
{
    public class SarKhat : ISarKhat
    {
        private readonly IDatabaseContext _context;
        public SarKhat(IDatabaseContext context)
        {
            _context = context;
        }
        public List<SarKhatModel> GetAllsarKhat()
        {
            var t = _context.SarKhats.Where(p => p.IsRemoved == false).ToList();
            //var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.Projects).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);

            var ProsList = t.Select(p => new SarKhatModel
            {
                SarKhatNumber = p.SarKhatNumber,
                Spacial=p.Spacial,
                Id = p.Id
            }).ToList();
            return ProsList;
        }
        public long AddSarKhat(SarKhatModel pro)
        {
            var t = _context.SarKhats.Add(new Domain.Entities.SMS.Common.SarKhat
            {
                SarKhatNumber = pro.SarKhatNumber,
                Spacial = pro.Spacial,
                //User = _context.Users.Where(u => u.Id == pro.idUser).FirstOrDefault(),
                InsertTime = DateTime.Now,
                IsRemoved = false,
                RemoveTime = null,
                UpdateTime = null
            });

            _context.SaveChanges();
            return t.Entity.Id;
        }

        public long DeletsarKhat(long idpro)
        {

            _context.SarKhats.Remove(_context.SarKhats.Where(d => d.Id == idpro).FirstOrDefault());
            _context.SaveChanges();
            return idpro;
        }


    }
}
