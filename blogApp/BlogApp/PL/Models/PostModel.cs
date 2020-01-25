using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Published { get; set; }
        public Category Category { get; set; }
        public IList<Tag> Tags { get; set; }
    }

    public class PostEditModel : PostViewModel
    {
        public int PostId { get; set; }
        public string UrlSlug { get; set; }
        public IList<Category> Categories { get; set; }
        public Tag Tag { get; set; }
    }
}
