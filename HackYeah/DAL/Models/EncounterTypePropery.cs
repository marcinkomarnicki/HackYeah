using System.ComponentModel.DataAnnotations;
using HackYeah.Application.Enums;

namespace HackYeah.DAL.Models;

public class EncounterTypeProperty
{
    [Key] public Guid Id { get; set; }

    public string Name { get; set; }
    public EValueType ValueType { get; set; }
    
    public List<EncounterType> EncounterTypes { get; set; }
}