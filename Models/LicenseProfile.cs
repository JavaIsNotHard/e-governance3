using System.Runtime.InteropServices.JavaScript;
using Egovernance.Data;

namespace Egovernance.Models;

public class LicenseProfile
{
    public int id { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public string gender { get; set; }
    public string province { get; set; }
    public string district { get; set; }
    public DateTime dateofbirth { get; set; }
    public int citizenshipNo { get; set; }
    public string? selectedVehicle { get; set; }
    public string? selectedProvince { get; set; }
    public DateTime? selectedOfficeVisit { get; set; }
    
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    
}