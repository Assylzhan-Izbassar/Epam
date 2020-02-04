using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        public int CommentId { get; set; }
        public int? PostId { get; set; }
        public int? ParentReplyId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy H:mm}", ApplyFormatInEditMode = true)]
        public DateTime Published { get; set; }
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Body")]
        [StringLength(1000, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 25)]
        public string CommentBody { get; set; }

        public bool Deleted { get; set; }

        public virtual Post Post { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
