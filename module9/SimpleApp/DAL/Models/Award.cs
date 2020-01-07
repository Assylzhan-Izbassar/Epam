using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Award
    {
        public int AwardID { get; set; }
        [Required]
        [RegularExpression(@"-:^[A-Z]+[a-zA-Z0-9""'\s]*$"), StringLength(50)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }

        public virtual ICollection<UserAward> Users { get; set; }
    }
}
