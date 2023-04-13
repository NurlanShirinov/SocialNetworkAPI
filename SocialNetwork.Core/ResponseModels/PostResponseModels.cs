using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.ResponseModels
{
    public class PostResponseModels  : Post
    {
        public string? CommentContent { get; set; }
        public string? FullName { get; set; }
    }
}