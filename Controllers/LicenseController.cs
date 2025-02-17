using Egovernance.Data;
using Egovernance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Egovernance.Controllers;

[Authorize]
public class LicenseController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public LicenseController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        var vehicle1 = new Vehicle() { name = "bike", code = "A", imageUrl = "/images/bycicle.png", isSelected = false};
        var vehicle2 = new Vehicle() { name = "scooter", code = "B", imageUrl = "/images/motorcycle.png", isSelected = false};
        var vehicle3 = new Vehicle() { name = "car", code = "A", imageUrl = "/images/car.png", isSelected = false};
        var vehicle4 = new Vehicle() { name = "truck", code = "A", imageUrl = "/images/truck.png", isSelected = false};
        
        var Vehicles = new List<Vehicle>() { vehicle1, vehicle2, vehicle3, vehicle4 };

        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine(vehicle.name);
        }
        
        return View(Vehicles);
    }

    [HttpPost]
    [Route("License/SelectVehicle")]
    public IActionResult SelectVehicle(string selectedCategory, DateTime selectedDate, string selectedProvince)
    {
        Console.WriteLine($"selected category {selectedCategory}");
        Console.WriteLine($"selected date {selectedDate}");
        Console.WriteLine($"selected province {selectedProvince}");
        if (!string.IsNullOrEmpty(selectedCategory) && !string.IsNullOrEmpty(selectedProvince) && !string.IsNullOrEmpty(selectedDate.ToString()))
        {
            HttpContext.Session.SetString("selectedVehicle", selectedCategory);
            HttpContext.Session.SetString("selectedDate", selectedDate.ToString("O"));
            HttpContext.Session.SetString("selectedProvince", selectedProvince);
            return RedirectToAction("NextStep");
        }
        
        TempData["ErrorMessage"] = "Please select a category before proceeding.";
        return RedirectToAction("Index", "License");
    }
    
    [HttpGet]
    public async Task<IActionResult> NextStep()
    {
        var selectedCategory = HttpContext.Session.GetString("selectedVehicle");
        var selectedProvince = HttpContext.Session.GetString("selectedProvince");
        
        var storedDate = HttpContext.Session.GetString("selectedDate");
        DateTime? selectedDate = null;
        if (!string.IsNullOrEmpty(storedDate) && DateTime.TryParse(storedDate, out DateTime parsedDate))
        {
            selectedDate = parsedDate;
        }
        
        Console.WriteLine($"Selected Category is {selectedCategory}");
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }
        
        ViewBag.SelectedCategory = selectedCategory;
        
        var userProfile = _context.LicenseProfiles.FirstOrDefault(x => x.UserId == user.Id);
        userProfile.selectedVehicle = selectedCategory;
        userProfile.selectedProvince = selectedProvince;
        userProfile.selectedOfficeVisit = selectedDate;
        _context.LicenseProfiles.Update(userProfile);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index","License");
    }
    
    
}