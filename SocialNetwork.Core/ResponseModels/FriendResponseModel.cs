﻿using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.ResponseModels
{
    public class FriendResponseModel:Friend
    {
        public string? Fullname { get; set; }
    }
}
