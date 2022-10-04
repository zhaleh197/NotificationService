using Microsoft.EntityFrameworkCore;
using Notification.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Proj
{
    public class UserProjects : IUserProjects
    {
        private readonly IDatabaseContext _context;
        public UserProjects(IDatabaseContext context)
        {
            _context = context;
        }

        public ProjModel GetprobyId(long id)
        {
            var t = _context.Projects.Where(p => p.Id == id&& p.IsRemoved==false).FirstOrDefault();
            ProjModel t1 = new ProjModel { Id = t.Id,TitleProject = t.TitleProject,idUser=t.KhototUser.IdUser,Description=t.Description,Khat=t.KhototUser.KhatNumber.ToString()};
            return t1;
        }

        public ProjModel GetprobyIdUser(long id)
        {
            var t = _context.Projects.Where(p => p.KhototUser.IdUser == id && p.IsRemoved == false).FirstOrDefault();
            ProjModel t1 = new ProjModel { Id = t.Id, TitleProject = t.TitleProject, idUser = t.KhototUser.IdUser, Description = t.Description, Khat = t.KhototUser.KhatNumber.ToString() };
            return t1;
        }
        public List<ProjModel> GetAllPro()
        {
            var t = _context.Projects.Where(p => p.IsRemoved == false).ToList();
            //var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.Projects).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);

            var ProsList = t.Select(p => new ProjModel
            {
                Description = p.Description,
                idUser = p.KhototUser.IdUser,  
                TitleProject= p.TitleProject,
                Khat=p.KhototUser.KhatNumber.ToString(),
                Id=p.Id
            }).ToList();
            return ProsList;
        }

        public long AddPro(ADDProjModel pro)
        {
           var t=_context.Projects.Add(new Domain.Entities.Common.Projects
            {
                Description = pro.Description,
                TitleProject = pro.TitleProject,
                IdKhototUser=pro.IdKhat
            });

            _context.SaveChanges();
            return t.Entity.Id;
        }

        public long DeletPro(long iddoc)
        {

            _context.Projects.Remove(_context.Projects.Where(d => d.Id == iddoc).FirstOrDefault());
            _context.SaveChanges();
            return iddoc;
        }

         
    }
}
