using BLL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class WidgetViewModel
    {
        public IList<Category> Categories { get; private set; }
        public IList<Tag> Tags { get; private set; }
        public IList<Post> Posts { get; private set; }

        public WidgetViewModel(DataManager dataManager)
        {
            Categories = dataManager.Category.GetCategories();
            Tags = dataManager.Tag.GetTags();
            Posts = dataManager.Post.GetPosts(0, 5);
        }
    }
}
