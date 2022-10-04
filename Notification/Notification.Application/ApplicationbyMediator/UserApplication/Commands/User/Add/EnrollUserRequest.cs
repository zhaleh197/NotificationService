using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands.Add
{
    public class EnrollUserRequest:IRequest<EnrollUserResponse>//long is response.
    { 

        public long IdUser { get; set; }
        public string? Phone { get; set; }
        public long IdRole { get; set; }//baraye kam kardane pichidegi
        public int IdUsertype { get; set; }
        //14010603
        public long CreditFinance { get; set; }//Etebar// Mr Nazari saied here isnt any things of Wallet to save in here.
        public long CridetMeaasage { get; set; }// 100 message 



    }
}
