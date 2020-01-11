using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class UserAward
    {
        public int UserAwardId { get; set; }
        public int UserId { get; set; }
        public int? AwardId { get; set; }

        public virtual User Users { get; set; }
        public virtual Award Awards { get; set; }
    }
}
