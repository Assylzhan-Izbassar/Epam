﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
