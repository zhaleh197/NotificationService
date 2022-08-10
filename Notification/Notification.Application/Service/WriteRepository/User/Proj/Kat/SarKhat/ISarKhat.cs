using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Proj.Kat.SarKhat
{
    public interface ISarKhat
    {
        //public long AddKhat(KhatModel pro);
        //public long DeletKhat(long idpro);
        //public KhatModel GetKhatbyId(long id);
        //public KhatModel GetKhatbyIdPro(long id);
        public List<SarKhatModel> GetAllsarKhat();
        public long AddSarKhat(SarKhatModel pro);
        public long DeletsarKhat(long idpro);
    }
}
