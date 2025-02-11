namespace Egovernance.Models;

public class VehicleCategory
{
    public string Code { get; set; }
    public string Name { get; set; }

    public VehicleCategory(string code, string name)
    {
        Code = code;
        Name = name;
    }
}