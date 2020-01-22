using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class CategoryEditModel : CategoryViewModel
    {
        public int CategoryId { get; set; }
        public int PostId { get; set; }
        public string UrlSlug { get; set; }
    }
}
