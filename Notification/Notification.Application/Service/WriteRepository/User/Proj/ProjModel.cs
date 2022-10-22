using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.Service.User.Proj
{
    public class ProjModel
    {
        public string TitleProject { get; set; }
        public string Description { get; set; }
        public string Khat { get; set; }
        public long idUser { get; set; }
        public long Id { get; set; }
    }
    public class ADDProjModel
    {
        public string TitleProject { get; set; }
        public string Description { get; set; }
        public long IdKhat { get; set; }
    }

    public class typeuserModel
    {
        public long Id  { get; set; }
        public string Title  { get; set; }

    }
    public class typePackageModel
    {
        public long Id { get; set; }
        public string Titlepack { get; set; }
        public long Pricepack { get; set; }
        public double Zaribtakhfif { get; set; }
    }
    
}
