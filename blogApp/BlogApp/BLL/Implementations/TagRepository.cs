using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Implementations
{
    public class TagRepository : ITagRepository
    {
        private BlogDbContext _blogDbContext;
        private bool disposed = false;

        public TagRepository(BlogDbContext dbContext)
        {
            _blogDbContext = dbContext;
        }

        public void DeleteTag(int tagId)
        {
            Tag tag = _blogDbContext.Tags.Find(tagId);

            if(tag != null)
            {
                _blogDbContext.Tags.Remove(tag);
            }
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

        public Tag GetTagById(int tagId)
        {
            return _blogDbContext.Tags.Find(tagId);
        }

        public IEnumerable<Tag> GetTags()
        {
            return _blogDbContext.Tags.ToList();
        }

        public void InsertTag(Tag tag)
        {
            if(tag != null)
            {
                _blogDbContext.Tags.Add(tag);
            }
        }

        public void UpdateTag(Tag tag)
        {
            if (tag != null)
            {
                _blogDbContext.Entry(tag).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Save()
        {
            _blogDbContext.SaveChanges();
        }
    }
}
