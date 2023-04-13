﻿using SocialNetwork.Core.Helpers;
using SocialNetwork.Core.Models;
using SocialNetwork.Core.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Repository.CQRS.Queries.Abstract
{
    public interface IPostQuery
    {
        Task<IEnumerable<PostResponseModels>> GetAllAsync(string userId);
        Task<IEnumerable<PostResponseModels>> GetAllOwn(string userId);
        Task<Post> GetById(string id);
        Task<ListResult<Post>> GetPaginationAsync(int offset, int limit);



    }
}
