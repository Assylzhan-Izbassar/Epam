using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Url slug")]
        public string UrlSlug { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
