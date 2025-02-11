using Microsoft.AspNetCore.Identity;

namespace Egovernance.Data;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
}