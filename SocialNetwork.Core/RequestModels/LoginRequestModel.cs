﻿using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.RequestModels
{
    public class LoginRequestModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
