using SocialNetwork.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Models
{
    public class Notification:BaseModel
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public  NotificationType Type { get; set; }
    }
}
