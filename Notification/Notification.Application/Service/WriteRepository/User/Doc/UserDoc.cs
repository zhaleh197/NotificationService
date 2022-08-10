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

        public void ConfirmDoc(long iddoc, bool conORuncon)
        {
            _context.DocumentsUser.Where(d => d.Id == iddoc).FirstOrDefault().Confirmcheck = conORuncon;
            _context.SaveChanges();
        }

        public void SendDoc(DocModel docs)
        {

            var strm = docs.base64imagopDoc;
            //this is a simple white background image
            var myfilename = string.Format(@"{0}", Guid.NewGuid());

            //Generate unique filename
            string filepath = "Uploads/" + myfilename+ docs.idUser + docs.idDocumentType + ".jpeg";
            var bytess = Convert.FromBase64String(strm);
            using (var imageFile = new FileStream(filepath, FileMode.Create))
            {
                imageFile.Write(bytess, 0, bytess.Length);
                imageFile.Flush();
                ////save in root
                //  await imageFile.CopyToAsync(fileStream);
            }
            string pathsavefile = "file:///C:/Users/Tech-8/source/repos/CmsRebin/Endpoint.WebAPI/" + filepath;
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

        }
        public void DeletDoc(long iddoc)
        {
            _context.DocumentsUser.Remove(_context.DocumentsUser.Where(d => d.Id == iddoc).FirstOrDefault());
            _context.SaveChanges();

        }
    }
}
