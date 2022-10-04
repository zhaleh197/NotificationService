using Microsoft.EntityFrameworkCore;
using Notification.Application.Interface.Context;

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

        public long SendDoc(DocModel docs)
        {

            var strm = docs.base64imagopDoc;
            //this is a simple white background image
            var myfilename = string.Format(@"{0}", Guid.NewGuid());

            //Generate unique filename
            string filepath = "Uploads/" + myfilename + docs.idUser + docs.idDocumentType + ".jpg";
            var bytess = Convert.FromBase64String(strm);
            using (var imageFile = new FileStream(filepath, FileMode.Create))
            {
                imageFile.Write(bytess, 0, bytess.Length);
                imageFile.Flush();
                ////save in root
                //  await imageFile.CopyToAsync(fileStream);
            }
            string pathsavefile = "file:///C:/Users/Tech-8/source/repos/CQRSNOTIFICATION14010519-Git/Notification/NotificationAPICQRS/" + filepath;

            var d = new Domain.Entities.Common.DocumentsUser
            {
                IdDocumentType = docs.idDocumentType,
                PathofSave = pathsavefile,
                Confirmcheck = false,
                IdUser = docs.idUser,
                IsRemoved = false
            };

            var result = _context.DocumentsUser.Add(d);


            _context.SaveChanges();
            //_context.SaveChangesAsync();
            return result.Entity.Id;
        }
        public long DeletDoc(long iddoc)
        {
            _context.DocumentsUser.Remove(_context.DocumentsUser.Where(d => d.Id == iddoc).FirstOrDefault());
            _context.SaveChanges();
            return iddoc;

        }
        public DocModelresponse getDocpathbyIDUser(long iduser)
        {
            var v = _context.DocumentsUser.Where(d => d.IdUser == iduser).FirstOrDefault();
            if (v != null) return new DocModelresponse { path = v.PathofSave, Confirmcheck = v.Confirmcheck, idDocumentType = v.IdDocumentType, idUser = v.IdUser };
            return null;

        }

        public string getDocTypebyId(long id)
        {
            return _context.DocumentType.Where(d => d.Id == id).FirstOrDefault().Title;

        }

        public List<DocModelresponse> getDocpathbyIDUserList(long iduser)
        {
            var vv = _context.DocumentsUser.Include(t => t.DocumentType).Where(d => d.IdUser == iduser);


            if (vv != null && vv.Count() > 0)
            {
                var Result = new List<DocModelresponse>();
                foreach (var v in vv)
                    Result.Add(new DocModelresponse
                    {
                        path = v.PathofSave,
                        Confirmcheck = v.Confirmcheck,
                        idDocumentType = v.IdDocumentType,
                        idUser = v.IdUser,
                        DocumentType = v.DocumentType.Title
                    });
                return Result;
            }

            return null;

        }

        public DocModelresponse getDocbyId(long id)
        {
            var doc = _context.DocumentsUser.Include(t => t.DocumentType).Where(d => d.Id == id).FirstOrDefault();
            if (doc != null)
            {
                return new DocModelresponse
                {
                    path = doc.PathofSave,
                    Confirmcheck = doc.Confirmcheck,
                    idDocumentType = doc.IdDocumentType,
                    idUser = doc.IdUser,
                    DocumentType = doc.DocumentType.Title
                };
            }
            return null;
        }
    }
}
