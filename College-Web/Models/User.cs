using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace College_Web.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        override public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
