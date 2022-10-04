using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.WriteRepository.User.Kat
{
    public interface IKhat
    {
      
        public KhatModelGet GetKhatbyId(long id);
        public KhatModelGet GetKhatbyIdUser(long id);
        public List<KhatModelGet> GetAllKhatUsers();
        public long AddKhat(KhatModel pro);
        public long DeletKhat(long idpro);
        public long ConfirmKhat(KhatModelGet t);


        public List<PublicKhatModelGet> GetAllKhatOmoomi();
        public List<KhososiKhatModelGet> GetAllKhatKhososiProperties();
        public List<KhososiKhatModelGet> GetKhatKhososibySarkhat(string sarkhat);
        public List<KhososiKhatModelGet> GetKhatKhososibyJustLenghofkhat(int lentofkhat);
        public long GetPricekhossosibysarkhatandlenghNumber(PriceKhatkhososiREquest req);

    }
}
