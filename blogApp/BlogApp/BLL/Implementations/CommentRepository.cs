using BLL.Interfaces;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _blogDbContext;
        private bool disposed = false;

        public CommentRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = GetCommentById(commentId);

            if(comment != null)
            {
                comment.Deleted = true;
                _blogDbContext.Comments.Remove(comment);
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

        public Comment GetCommentById(int commentId)
        {
            return _blogDbContext.Comments.Find(commentId);
        }

        public List<Comment> GetComments()
        {
            return _blogDbContext.Comments.ToList();
        }

        public List<Comment> GetCommentByOrder()
        {
            return _blogDbContext.Comments.OrderByDescending(comment => comment.Published).ToList();
        }

        public void InsertComment(Comment comment)
        {
            if(comment != null)
            {
                _blogDbContext.Comments.Add(comment);
            }
        }

        public void Save()
        {
            _blogDbContext.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            if (comment != null)
            {
                _blogDbContext.Entry(comment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public List<Reply> GetReplies(int commentId)
        {
            Comment comment = GetCommentById(commentId);
            return comment.Replies.ToList();
        }
    }
}
