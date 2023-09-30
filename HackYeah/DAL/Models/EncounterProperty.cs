using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class EncounterProperty
{
    [Key] public Guid Id { get; set; }

    public EncounterTypeProperty EncounterTypeProperty { get; set; }

    public Guid EncounterTypePropertyId { get; set; }

    public string Value { get; set; }
}