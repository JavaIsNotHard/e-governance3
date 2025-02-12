using Egovernance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Egovernance.Controllers;

[Authorize]
public class LicenseController : Controller
{
    
    [HttpGet]
    public IActionResult SelectVehicle()
    {
        var vehicle1 = new Vehicle() { name = "something", code = "A" };
        var vehicle2 = new Vehicle() { name = "something", code = "B" };
        Console.WriteLine(vehicle1.name);
        Console.WriteLine(vehicle2.name);
        
        var Vehicles = new List<Vehicle>() { vehicle1, vehicle2 };

        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine(vehicle.name);
        }
        
        return View(Vehicles);
    }
    
    
}