using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Egovernance.Views.License;

public class ApplyForLicenseModel : PageModel
{
    [BindProperty]
    public string SelectedCategory { get; set; }
    
    public IActionResult OnPost()
    {
        if (!string.IsNullOrEmpty(SelectedCategory))
        { 
            return RedirectToPage("/NextStep", new { category = SelectedCategory });
        }

        return Page();
    }
}