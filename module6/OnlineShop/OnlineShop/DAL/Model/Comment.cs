using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.DAL.Model
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Summary { get; set; }
        public DateTime WroteTime { get; set; }
    }
}
