using HackYeah.DAL.Models;

namespace HackYeah.Application.Queries.Models;

public class GetMissingPetResult
{
    public string EncounterTypeName { get; set; }
    public Guid EncounterTypeId { get; set; }
    public string Rase { get; set; }
    public string PetName { get; set; }
    public string ReporterName { get; set; }
    public string TelephoneNumber { get; set; }
    public string LongitudeReport { get; set; }
    public string LatitudeReport { get; set; }
    public bool HasCollar { get; set; }
    public string SpecialFeatures { get; set; }
    public string Color { get; set; }
    public string PetSize { get; set; }
}