using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Category : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
