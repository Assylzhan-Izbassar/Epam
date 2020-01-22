using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPostRepository : IDisposable, IBaseRepository
    {
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetPosts(int pageNo, int pageSize);
        Post GetPostById(int postId);
        void InsertPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
        int TotalPosts();
    }
}
