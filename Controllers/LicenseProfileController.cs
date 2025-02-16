using Egovernance.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Egovernance.Controllers;

public class ProfileController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public ProfileController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Apply()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Apply(ApplicationUser user)
    {
        return View();
    }
}