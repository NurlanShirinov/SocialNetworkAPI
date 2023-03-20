using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Models
{
    public class Comment:BaseModel
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string? Content { get; set; }

    }
}
