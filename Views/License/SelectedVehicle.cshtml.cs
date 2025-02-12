using Egovernance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Egovernance.Views.License;

public class LicenseModel : PageModel
{
    private readonly ILogger<LicenseModel> _logger;

    public LicenseModel(ILogger<LicenseModel> logger)
    {
        _logger = logger;
        _logger.LogInformation("asdfffffasdfasdfhahhahahadasf hasdfhashf Selected License");
    }
    
    public List<Vehicle> Vehicles { get; set; } = [];

    [BindProperty]
    public Vehicle SelectedVehicle { get; set; }
    
    public void OnGet()
    {
        var vehicle1 = new Vehicle() { name = "something", code = "A" };
        var vehicle2 = new Vehicle() { name = "something", code = "B" };
        Vehicles = [vehicle1, vehicle2];
        _logger.LogInformation($"Selected vehicle: {vehicle1.name}, {vehicle2.name}");
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("Index", "Home", new { vehicles = SelectedVehicle});
    }
    
}