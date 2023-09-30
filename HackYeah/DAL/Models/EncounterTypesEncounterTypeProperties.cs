using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class EncounterTypesEncounterTypeProperties
{
    [Key] public Guid Id { get; set; }

    public EncounterType EncounterType { get; set; }
    public Guid EncounterTypeId { get; set; }

    public EncounterTypeProperty EncounterTypeProperty { get; set; }

    public Guid EncounterTypePropertyId { get; set; }
}