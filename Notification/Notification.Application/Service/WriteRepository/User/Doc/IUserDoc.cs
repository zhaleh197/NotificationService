using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Doc
{
    public interface IUserDoc
    {
        public string SendDoc(DocModel docs);
        public bool ConfirmDoc(long iduser, bool conORuncon);
        public long DeletDoc(long iddoc);
        public DocModelresponse getDocpathbyIDUser(long iduser);
    }
}
