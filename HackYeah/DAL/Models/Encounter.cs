using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class Encounter
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required decimal Longitude { get; set; }
    
    [Required]
    public required decimal Latitude { get; set; }
    
    [Required]
    public required EncounterType EncounterType { get; set; }
}