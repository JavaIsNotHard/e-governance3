using System.ComponentModel.DataAnnotations;

namespace Egovernance.Models;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    [Display(Name = "Confirm password")]
    public string ConfirmPassword { get; set; }
}