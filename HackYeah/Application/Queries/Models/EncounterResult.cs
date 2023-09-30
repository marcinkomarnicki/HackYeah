using HackYeah.DAL.Models;

namespace HackYeah.Application.Queries.Models;

public class EncounterResult
{
    public decimal Longitude { get; set; }

    public decimal Latitude { get; set; }

    public EncounterType EncounterType { get; set; }

    public DateTime TimeUtc { get; set; }

    public EncounterCategory EncounterCategory { get; set; }

    public int PropabilityOfOccurance { get; set; }
}