
namespace HackYeah.Application.Queries.Models;

public class TypeCounterResult
{
    public string EncounterType { get; set; }

    public DateTime LastOccurance { get; set; }

    public int OccuranceCount { get; set; }
}