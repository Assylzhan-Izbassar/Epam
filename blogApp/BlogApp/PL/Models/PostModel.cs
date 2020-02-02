using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PL.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; }
    }

    public class PostEditModel : PostViewModel
    {
        public int PostId { get; set; }
    }
}
