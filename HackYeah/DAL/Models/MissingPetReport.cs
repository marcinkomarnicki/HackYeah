using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class MissingPetReport
{
    [Key] public Guid Id { get; set; }
    public EncounterType EncounterType { get; set; }
    public string Rase { get; set; }
    public string PetName { get; set; }
    public string ReporterName { get; set; }
    public string TelephoneNumber { get; set; }
    public string LongitudeReport { get; set; }
    public string LatitudeReport { get; set; }
    public DateTime TimeUtc { get; set; }
    public Guid EncounterTypeId { get; set; }
    public bool IsWild { get; set; }
}

