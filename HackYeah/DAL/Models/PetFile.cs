using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models;

public class PetFile
{
    [Key] public Guid Id { get; set; }
    public string FileName { get; set; }
    public MissingPetReport MissingPetReport { get; set; }
    public Guid MissingPetReportId { get; set; }

}