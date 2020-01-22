using BLL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class ListViewModel
    {
        public List<Post> Posts { get; private set; } 
        public IndexViewModel Relation { get; set; }
        public int TotalPosts { get; private set; }

        public ListViewModel(DataManager dataManager, int page)
        {
            Posts = (List<Post>)dataManager.Post.GetPosts(page - 1, 10);
            TotalPosts = dataManager.Post.TotalPosts();
            Relation = new IndexViewModel();
            Relation.Posts = (List<Post>)dataManager.Post.GetPosts();
            Relation.Tags = (List<Tag>)dataManager.Tag.GetTags();
            Relation.PostTags = dataManager.PostTag.GetPostTags();
        }
    }
}
