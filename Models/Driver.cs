
using System.ComponentModel.DataAnnotations;

namespace restAPI.Models;

public class Driver : BaseEntity
{
    [Key]
    public int Id {get;set;}
    public int TeamId { get; set;}
    public string Name { get; set;}="";
    public int RacingNumber { get; set; }
    public virtual Team Team {get; set;}
    public virtual DriverMedia DriverMedia {get; set;}
}