using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class EncounterType
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required decimal Code { get; set; }
}