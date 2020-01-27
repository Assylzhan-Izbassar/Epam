using BLL.Interfaces;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Implementations
{
    public class PostRepository : IPostRepository
    {
        private BlogDbContext _blogDbContext;
        private bool disposed = false;

        public PostRepository(BlogDbContext dbContext)
        {
            _blogDbContext = dbContext;
        }

        public void DeletePost(int postId)
        {
            Post post = _blogDbContext.Posts.Find(postId);

            if (post != null)
            {
                _blogDbContext.Posts.Remove(post);
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

        public Post GetPostById(int postId)
        {
            return _blogDbContext.Posts.Find(postId);
        }

        public List<Post> GetPosts()
        {
            return _blogDbContext.Posts.ToList();
        }

        public List<Post> GetPosts(int pageNo, int pageSize)
        {
            var posts = _blogDbContext.Posts
                .Include(c => c.Category)
                .Where(p => p.Published)
                .OrderByDescending(p => p.PostedOn)
                .Take(pageSize)
                .ToList();

            var postsId = posts.Select(p => p.PostId).ToList();

            return _blogDbContext.Posts
                .Where(p => postsId.Contains(p.PostId))
                .OrderByDescending(p => p.PostedOn)
                .ToList();
        }

        public void InsertPost(Post post)
        {
            if (post != null)
            {
                _blogDbContext.Posts.Add(post);
            }
        }

        public void Save()
        {
            _blogDbContext.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            if (post != null)
            {
                _blogDbContext.Entry(post).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public int TotalPosts()
        {
            return _blogDbContext.Posts.Where(p => p.Published).Count();
        }

        public List<Post> Search(string type, string item)
        {
            List<Post> posts = null;
            List<int> tagIds = new List<int>();
            switch (type)
            {
                case "Category":
                    posts = _blogDbContext.Posts.Where(p => p.Category.Name.Contains(item) ||
                        p.Category.Name.StartsWith(item) ||
                        p.Category.Name.EndsWith(item)).ToList();
                    break;

                default:
                    List<Tag> tags = _blogDbContext.Tags.ToList();
                    List<PostTag> postTags = _blogDbContext.PostTags.ToList();

                    foreach (var tag in tags)
                    {
                        if(tag.Name.Contains(item) || tag.Name.StartsWith(item))
                        {
                            tagIds.Add(tag.TagId);
                        }
                    }

                    if(tagIds.Any())
                    {
                        posts = new List<Post>();
                        foreach(var postTag in postTags)
                        {
                            if(tagIds.Contains(postTag.TagId) && !posts.Contains(GetPostById(postTag.PostId)))
                            {
                                posts.Add(GetPostById(postTag.PostId));
                            }
                        }
                    }
                        
                    break;
            }
            return posts;
        }
    }
}
