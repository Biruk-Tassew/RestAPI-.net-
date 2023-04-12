

namespace restAPI.Models;

public class Team : BaseEntity
{
    public Team()
    {
        Drivers = new HashSet<Driver>();
    }
    public int id { get; set;}
    public string Name { get; set;} = "";
    public int Year { get; set; } = 2023;

    public virtual ICollection<Driver> Drivers {get; set;}
}