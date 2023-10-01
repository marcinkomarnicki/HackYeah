using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class Encounter
{
    [Key] public Guid Id { get; set; }

    public required decimal Longitude { get; set; }

    public required decimal Latitude { get; set; }

    public EncounterType EncounterType { get; set; }

    public DateTime TimeUtc { get; set; }
    public Guid EncounterTypeId { get; set; }

    public List<EncounterProperty> EncounterProperties { get; set; }
}