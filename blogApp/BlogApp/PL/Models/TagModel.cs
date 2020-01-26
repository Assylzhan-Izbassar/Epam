using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PL.Models
{
    public class TagViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        [StringLength(40, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Url slug")]
        public string UrlSlug { get; set; }
    }

    public class TagEditModel : TagViewModel
    {
        public int TagId { get; set; }
        public int PostId { get; set; }
    }
}
