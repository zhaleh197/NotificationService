using Notification.Application.Interface.Context; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Kat.SarKhat
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
                Id = p.Id,
                BasePrice = p.BasePrice,
                EnglishZarib=p.EnglishZarib,
                HamrahAvalZarib=p.HamrahAvalZarib,
                IranselZarib=p.IranselZarib,
                PersianZarib=p.PersianZarib,
                RaytelZarib=p.PersianZarib,
                TejasriLinkZarib=p.PersianZarib
         
            }).ToList();
            return ProsList;
        }

        public long AddSarKhat(SarKhatModel pro)
        {
            var t = _context.SarKhats.Add(new Domain.Entities.WriteModels.SMS.Common.Khat.SarKhat
            {
                SarKhatNumber = pro.SarKhatNumber,
                Spacial = pro.Spacial,
                PersianZarib = pro.PersianZarib,
                TejasriLinkZarib = pro.TejasriLinkZarib,
                RaytelZarib = pro.RaytelZarib,
                IranselZarib = pro.IranselZarib,
                HamrahAvalZarib = pro.HamrahAvalZarib,
                EnglishZarib=pro.EnglishZarib,
                BasePrice=pro.BasePrice
                //InsertTime = DateTime.Now,
                //IsRemoved = false,
                //RemoveTime = null,
                //UpdateTime = null
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

        public SarKhatModel GetSarKhatbyId(long id)
        {
            var t = _context.SarKhats.Where( p => p.Id==id).FirstOrDefault();
            SarKhatModel t1 = new SarKhatModel
            {
                Id = t.Id,
                SarKhatNumber=t.SarKhatNumber,
                BasePrice=t.BasePrice,
                EnglishZarib=t.EnglishZarib,
                HamrahAvalZarib=t.HamrahAvalZarib,
                Spacial=t.Spacial,
                IranselZarib=t.IranselZarib,
                RaytelZarib=t.RaytelZarib,
                TejasriLinkZarib=t.TejasriLinkZarib,
                PersianZarib=t.PersianZarib

            };
            return t1;

        }
    }
}
