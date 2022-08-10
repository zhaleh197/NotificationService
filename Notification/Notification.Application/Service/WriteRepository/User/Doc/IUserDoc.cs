using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Doc
{
    public interface IUserDoc
    {
        public void SendDoc(DocModel docs);
        public void ConfirmDoc(long iduser, bool conORuncon);
        public void DeletDoc(long iddoc);
    }
}
