using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
    }
}
