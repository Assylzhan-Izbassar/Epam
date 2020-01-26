using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICommentRepository : IDisposable, IBaseRepository
    {
        List<Comment> GetComments();
        List<Reply> GetReplies(int commentId);
        Comment GetCommentById(int commentId);
        void InsertComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int commentId);
    }
}
