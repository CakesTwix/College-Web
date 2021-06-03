using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace College_Web.Models
{
    public class UserApp : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string First_Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Middle_Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class Login
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
