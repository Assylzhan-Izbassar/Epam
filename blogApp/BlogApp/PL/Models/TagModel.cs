using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.Models
{
    public class TagViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
    }

    public class TagEditModel : TagViewModel
    {
        public int TagId { get; set; }
        public int PostId { get; set; }
    }
}
