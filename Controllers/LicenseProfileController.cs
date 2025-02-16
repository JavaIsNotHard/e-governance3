using Egovernance.Data;
using Egovernance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Egovernance.Controllers;

public class LicenseProfileController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public LicenseProfileController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null) return RedirectToAction("Login", "Account");
        
        var existingProfile = _context.LicenseProfiles.FirstOrDefault(lp => lp.UserId.Equals(user.Id));
        if (existingProfile != null)
        {
            return RedirectToAction("Index", "License");
        }
        
        return View(new LicenseProfile());
    }

    [HttpPost]
    public async Task<IActionResult> Create(LicenseProfile model)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return RedirectToAction("Login", "Account");

        // Set UserId to associate LicenseProfile with logged-in user
        model.UserId = user.Id;

        _context.LicenseProfiles.Add(model);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "License");
    }
    
}