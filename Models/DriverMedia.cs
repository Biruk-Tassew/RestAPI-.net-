
using System.ComponentModel.DataAnnotations;

namespace restAPI.Models;

public class DriverMedia : BaseEntity
{
    [Key]
    public int Id { get; set;}
    public int DriverId { get; set; }
    public string Media { get; set; } = "";
    public virtual Driver Driver{get; set;}
}