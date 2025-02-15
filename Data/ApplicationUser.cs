using Egovernance.Models;
using Microsoft.AspNetCore.Identity;

namespace Egovernance.Data;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    
    public virtual LicenseProfile LicenseProfile { get; set; }
}