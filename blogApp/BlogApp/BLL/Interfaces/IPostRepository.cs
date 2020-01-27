using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPostRepository : IDisposable, IBaseRepository
    {
        List<Post> GetPosts();
        List<Post> GetPosts(int pageNo, int pageSize);
        List<Post> Search(string type, string item);
        Post GetPostById(int postId);
        void InsertPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
        int TotalPosts();
    }
}
