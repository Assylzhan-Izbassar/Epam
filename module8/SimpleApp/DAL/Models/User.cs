using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DAL.ViewModel;

namespace DAL.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required(ErrorMessage ="Please, set a name!")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, set a birthdate!")]
        public DateTime Birthdate { get; set; }
        [Range(0,150,ErrorMessage ="Age can not be negative and up to 150!")]
        public int Age { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<UserAward> UserAwards { get; set; }
        public virtual ICollection<Award> Awards { get; set; }
    }
}
