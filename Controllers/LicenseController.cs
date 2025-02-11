using Egovernance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Egovernance.Controllers;

[Authorize]
public class LicenseController : Controller
{
    private readonly ILogger<LicenseController> _logger;

    public LicenseController(ILogger<LicenseController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult SelectVehicle()
    {
        var categories = new List<VehicleCategory>
        {
            new VehicleCategory("K", "Scooter, Moped"),
            new VehicleCategory("A", "Motorcycle, Scooter, Moped"),
            new VehicleCategory("B", "Car, Jeep, Delivery Van"),
            new VehicleCategory("C", "Tempo, Auto Rickshaw"),
            new VehicleCategory("C1", "E-Rickshaw"),
            new VehicleCategory("D", "Power Tiller"),
            new VehicleCategory("E", "Tractor"),
            new VehicleCategory("H", "Road Roller, Dozer"),
            new VehicleCategory("H1", "Dozer"),
            new VehicleCategory("H2", "Road Roller"),
            new VehicleCategory("I", "Crane, Fire Brigade, Loader"),
            new VehicleCategory("I1", "Crane"),
            new VehicleCategory("I2", "Fire Brigade"),
            new VehicleCategory("I3", "Loader"),
            new VehicleCategory("J1", "Excavator")
        };

        foreach (var category in categories)
        {
            _logger.LogInformation($"Selected category: {category.Name}");
        }
        
        return View(categories);
    }
}