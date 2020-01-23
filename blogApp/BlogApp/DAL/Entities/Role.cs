using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Role : IdentityRole
    {
        public Role() : base()
        {

        }
        public Role(string roleName) : base(roleName)
        {
        }
    }
}
