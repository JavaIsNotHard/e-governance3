using Egovernance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Egovernance.Controllers;

[Authorize]
public class LicenseController : Controller
{
    
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
    public IActionResult SelectVehicle(string selectedCategory)
    {
        if (!string.IsNullOrEmpty(selectedCategory))
        {
            HttpContext.Session.SetString("selectedVehicle", selectedCategory);
            return RedirectToAction("NextStep");
        }
        
        TempData["ErrorMessage"] = "Please select a category before proceeding.";
        return RedirectToAction("Index", "License");
    }
    
    [HttpGet]
    public IActionResult NextStep()
    {
        var selectedCategory = HttpContext.Session.GetString("selectedVehicle");
        ViewBag.SelectedCategory = selectedCategory;
        return View();
    }
    
    
}