using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class EncounterType
{
    [Key] public Guid Id { get; set; }
    public List<EncounterTypeProperty> EncounterTypeProperties { get; set; }

    public bool IsSearchable { get; set; }
    public required string Code { get; set; }
}