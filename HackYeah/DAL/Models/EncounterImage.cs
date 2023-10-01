using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models
{
    public class EncounterImage
    {
        [Key] public Guid Id { get; set; }
        [StringLength(200)]
        public string MimeType { get; set; }
        public Encounter Encounter { get; set; }
        public Guid EncounterId { get; set; }
    }
}
