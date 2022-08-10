

namespace Notification.Application.ApplicationbyMediator.UserApplication.Commands
{
    public class userCommand
    {
        public long IdUser { get; set; }

        public long IdUsertype { get; set; }

        public long IdPackagetariffSMS { get; set; }
        public DateTime DeadlinePackage { get; set; }

        public long Idprojects { get; set; }
    }
}
