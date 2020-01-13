using System;
using System.ComponentModel.DataAnnotations;

namespace Task6.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please, set a name!")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please, set a birthdate!")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Email is not specified!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is not specified!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password is incorrect!")]
        public string ConfirmPassword { get; set; }
    }
}
