using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.ResponseModels
{
    public class RegisterResponseModel
    {
        public bool SuccesfulLogin { get; set; }
        public string? UserId { get; set; }
    }
}
