﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPostTagRepository : IDisposable, IBaseRepository
    {
        IEnumerable<PostTag> GetPostTags();
        void AddPostTag(PostTag postTag);
    }
}
