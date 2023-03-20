using SocialNetwork.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Models
{
    public class Request:BaseModel
    {
        public Guid FromUserId { get; set; }
        public Guid ToUserId { get; set; }
        public RequestStatus Status { get; set; }     

    }
}
