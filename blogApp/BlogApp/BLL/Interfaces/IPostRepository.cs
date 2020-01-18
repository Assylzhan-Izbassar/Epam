using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetPosts();
        Post GetPostById(int postId);
        void InsertPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int postId);
        void SavePost();
    }
}
