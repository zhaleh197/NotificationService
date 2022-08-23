using Notification.Application.Interface.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Doc
{
    public class UserDoc : IUserDoc
    {
        private readonly IDatabaseContext _context;
        public UserDoc(IDatabaseContext context)
        {
            _context = context;
        }

        public bool ConfirmDoc(long iddoc, bool conORuncon)
        {
            _context.DocumentsUser.Where(d => d.Id == iddoc).FirstOrDefault().Confirmcheck = conORuncon;
            _context.SaveChanges();
            return conORuncon;
        }

        public string SendDoc(DocModel docs)
        {

            var strm = docs.base64imagopDoc;
            //this is a simple white background image
            var myfilename = string.Format(@"{0}", Guid.NewGuid());

            //Generate unique filename
            string filepath = "Uploads/" + myfilename+ docs.idUser + docs.idDocumentType + ".zip";
            var bytess = Convert.FromBase64String(strm);
            using (var imageFile = new FileStream(filepath, FileMode.Create))
            {
                imageFile.Write(bytess, 0, bytess.Length);
                imageFile.Flush();
                ////save in root
                //  await imageFile.CopyToAsync(fileStream);
            }
            string pathsavefile = "file:///C:/Users/Tech-8/source/repos/CQRSNOTIFICATION14010519-Git/Notification/NotificationAPICQRS/" + filepath;
            _context.DocumentsUser.Add(new Domain.Entities.Common.DocumentsUser
            {
                DocumentType = _context.DocumentType.Where(d => d.Id == docs.idDocumentType).FirstOrDefault(),
                PathofSave = pathsavefile,
                Confirmcheck=false,
                User=_context.Users.Where(u=>u.Id==docs.idUser).FirstOrDefault(),
                InsertTime=DateTime.Now,
                IsRemoved=false,
                RemoveTime=null,
                UpdateTime=null
            });
            _context.SaveChanges();

            return pathsavefile;
        }
        public long DeletDoc(long iddoc)
        {
            _context.DocumentsUser.Remove(_context.DocumentsUser.Where(d => d.Id == iddoc).FirstOrDefault());
            _context.SaveChanges();
            return iddoc;

        }
        public DocModelresponse getDocpathbyIDUser(long iduser)
        {
            var v=_context.DocumentsUser.Where(d => d.IdUser==iduser).FirstOrDefault();
            if(v!=null) return new DocModelresponse { path=v.PathofSave, Confirmcheck=v.Confirmcheck,idDocumentType=v.IdDocumentType,idUser=v.IdUser};
            return null;

        }
    }
}
