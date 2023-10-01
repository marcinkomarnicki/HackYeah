namespace HackYeah.Application.Queries.Models;

public class EncounterResult
{
    public decimal Longitude { get; set; }

    public decimal Latitude { get; set; }

    public string EncounterType { get; set; }

    public DateTime TimeUtc { get; set; }

    public bool IsWild { get; set; }

    public int PropabilityOfOccurance { get; set; }
    
    public List<EncounterResultProperties> Properties { get; set; }

    public List<string> Images { get; set; }
}


public class EncounterResultProperties
{
    public string Name { get; set; }
    public string Value { get; set; }
    public string ValueType { get; set; }
}