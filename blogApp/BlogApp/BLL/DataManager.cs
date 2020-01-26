using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class DataManager
    {
        private ICategoryRepository categoryRepository;
        private IPostRepository postRepository;
        private ITagRepository tagRepository;
        private IPostTagRepository postTagRepository;
        private ICommentRepository commentRepository;


        public DataManager(ICategoryRepository categoryRepository,
            IPostRepository postRepository, ITagRepository tagRepository,
            IPostTagRepository postTagRepository, ICommentRepository commentRepository)
        {
            this.categoryRepository = categoryRepository;
            this.postRepository = postRepository;
            this.tagRepository = tagRepository;
            this.postTagRepository = postTagRepository;
            this.commentRepository = commentRepository;
        }

        public ICategoryRepository Category { get { return categoryRepository; } }
        public IPostRepository Post { get { return postRepository; } }
        public ITagRepository Tag { get { return tagRepository; } }
        public IPostTagRepository PostTag { get { return postTagRepository; } }
        public ICommentRepository Comment { get { return commentRepository; } }
    }
}
