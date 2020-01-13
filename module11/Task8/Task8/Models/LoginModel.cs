using System.ComponentModel.DataAnnotations;

namespace Task6.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is not specified!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is not specified!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
