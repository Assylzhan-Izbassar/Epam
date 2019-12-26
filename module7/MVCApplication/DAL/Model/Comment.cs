using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Summary { get; set; }
        public DateTime WroteTime { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }
       
    }
}
