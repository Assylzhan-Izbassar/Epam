using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<User> Users { get; set; } 

        public Role()
        {
            Users = new List<User>();
        }
    }
}
