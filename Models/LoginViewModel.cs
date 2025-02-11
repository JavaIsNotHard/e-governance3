using System.ComponentModel.DataAnnotations;

namespace Egovernance.Models;

public class LoginViewModel
{
    [Required]
    [Display(Name = "username or email")]
    public string UsernameOrEmail { get; set; }
    
    [Required]
    public string Password { get; set; }
}