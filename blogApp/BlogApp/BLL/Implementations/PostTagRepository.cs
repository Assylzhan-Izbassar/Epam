using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Implementations
{
    public class PostTagRepository : IPostTagRepository
    {
        private BlogDbContext _blogDbContext;
        private bool disposed = false;

        public PostTagRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _blogDbContext.Dispose();
            }
            disposed = true;
        }

        public IEnumerable<PostTag> GetPostTags()
        {
            return _blogDbContext.PostTags;
        }

        public void Save()
        {
            _blogDbContext.SaveChanges();
        }

        public void AddPostTag(PostTag postTag)
        {
            if (postTag != null)
            {
                _blogDbContext.PostTags.Add(postTag);
            }
        }
    }
}
