using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.ResponseModels
{
    public class CommentResponseModel:Comment
    {
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
