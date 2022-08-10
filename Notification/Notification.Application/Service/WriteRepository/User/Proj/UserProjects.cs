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
            ProjModel t1 = new ProjModel { Id = t.Id,TitleProject = t.TitleProject,idUser=t.IdUser,Description=t.Description};
            return t1;
        }

        public ProjModel GetprobyIdUser(long id)
        {
            var t = _context.Projects.Where(p => p.IdUser == id && p.IsRemoved == false).FirstOrDefault();
            ProjModel t1 = new ProjModel { Id = t.Id,TitleProject = t.TitleProject, idUser = t.IdUser, Description = t.Description };
            return t1;
        }
        public List<ProjModel> GetAllPro()
        {
            var t = _context.Projects.Where(p => p.IsRemoved == false).ToList();
            //var res = _context.Users.Include(s => s.PackageTariff.PackageSMS).Include(s => s.Projects).Include(s => s.DocumentsUser).Include(s => s.USerType).Include(s => s.SMSUser).FirstOrDefault(r => r.IdUser == request);

            var ProsList = t.Select(p => new ProjModel
            {
                Description = p.Description,
                idUser = p.IdUser,  
                TitleProject= p.TitleProject,
                Id=p.Id
            }).ToList();
            return ProsList;
        }

        public long AddPro(ProjModel pro)
        {
           var t=_context.Projects.Add(new Domain.Entities.Common.Projects
            {
                Description = pro.Description,
                TitleProject = pro.TitleProject,
                IdUser=pro.idUser,
                //User=_context.Users.Where(u=>u.Id==pro.idUser).FirstOrDefault(),
                InsertTime = DateTime.Now,
                IsRemoved = false,
                RemoveTime = null,
                UpdateTime = null
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
