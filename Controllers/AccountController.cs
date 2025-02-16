using System.Security.Claims;
using Egovernance.Data;
using Egovernance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egovernance.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        ILogger<AccountController> logger, ApplicationDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var existingUser = await _userManager.FindByEmailAsync(model.Email);
        if (existingUser != null)
        {
            ModelState.AddModelError(string.Empty, "Email address already exists");
            return View(model);
        }
        
        var user = new ApplicationUser { UserName = generateRandomUsername(), Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        
        return RedirectToAction("RegistrationSuccess", new { username = user.UserName });
    }

    [HttpGet]
    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await _userManager.FindByNameAsync(model.UsernameOrEmail) ??
                   await _userManager.FindByEmailAsync(model.UsernameOrEmail);

        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            ModelState.AddModelError(string.Empty, "Wrong Password");
            return View(model);
        }
        
        var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

        if (!signInResult.Succeeded)
        {
            _logger.LogInformation("couldn't login");
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(model);
        }
        
        // null pointer exception
        if (_context.LicenseProfiles != null)
        {
            var existingProfile = await _context.LicenseProfiles
                .FirstOrDefaultAsync(lp => lp.UserId == user.Id);

            if (existingProfile == null)
            {
                return RedirectToAction("Create", "LicenseProfile"); // Profile already exists
            }
        }
        
        await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));

        ViewBag.HasLicense = true;
        return RedirectToAction("Index", "License");

    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    private static String generateRandomUsername()
    {
        Random random = new Random();
        var part1 = random.Next(10000, 99999).ToString();
        var part2 = random.Next(1000, 9999).ToString();
        var part3 = random.Next(100, 999).ToString();

        return $"{part1}-{part2}-{part3}";
    }

    public IActionResult RegistrationSuccess(string username)
    {
        ViewBag.GeneratedUsername = username;
        return View();
    }
}