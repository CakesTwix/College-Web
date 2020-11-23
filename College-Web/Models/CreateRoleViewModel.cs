using System.ComponentModel.DataAnnotations;

namespace College_Web.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
