using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Meta { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
