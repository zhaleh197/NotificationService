using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Proj.Kat
{
    public interface IKhat
    {
        public long AddKhat(KhatModel pro);
        public long DeletKhat(long idpro);
        public KhatModel GetKhatbyId(long id);
        public KhatModel GetKhatbyIdPro(long id);
        public List<KhatModel> GetAllKhat();
    }
}
