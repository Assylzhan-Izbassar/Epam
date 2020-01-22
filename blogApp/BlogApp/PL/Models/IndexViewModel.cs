using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class IndexViewModel
    {
        public IList<Post> Posts { get; set; }
        public IList<Tag> Tags { get; set; }
        public IEnumerable<PostTag> PostTags { get; set; }

        public Post Post { get; set; }
        public Tag Tag { get; set; }
        public PostTag PostTag { get; set; }
    }
}
