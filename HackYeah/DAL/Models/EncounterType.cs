using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class EncounterType
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public required string Code { get; set; }
}