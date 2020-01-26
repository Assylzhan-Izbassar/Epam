using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ITagRepository : IDisposable, IBaseRepository
    {
        List<Tag> GetTags();
        Tag GetTagById(int tagId);
        void InsertTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(int tagId);
    }
}
