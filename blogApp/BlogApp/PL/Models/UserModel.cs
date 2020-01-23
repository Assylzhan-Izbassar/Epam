using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PL.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class UserEditModel : UserViewModel
    {
        public string UserId { get; set; }
    }

    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }

    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public IList<Role> Roles { get; set; }
        public IList<string> UserRoles { get; set; }

        public ChangeRoleViewModel()
        {
            Roles = new List<Role>();
            UserRoles = new List<string>();
        }
    }
}
