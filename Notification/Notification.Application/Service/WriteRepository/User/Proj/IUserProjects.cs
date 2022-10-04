using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Proj
{
    public interface IUserProjects
    {
        public long AddPro(ADDProjModel pro);
        public long DeletPro(long idpro);
        public ProjModel GetprobyId(long id);
        public ProjModel GetprobyIdUser(long id);
        public List<ProjModel> GetAllPro();

    }
}
