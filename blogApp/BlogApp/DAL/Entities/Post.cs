using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Short description")]
        [StringLength(250, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 20)]
        public string ShortDescription { get; set; }

        [Required]
        [Display(Name = "Article")]
        [StringLength(5000, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 500)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "UrlSlug")]
        [StringLength(150, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 5)]
        public string UrlSlug { get; set; }

        [Required]
        [Display(Name = "Meta")]
        [StringLength(25, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 5)]
        public string Meta { get; set; }

        public bool Published { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PostedOn { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Modified { get; set; }

        public Category Category { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
