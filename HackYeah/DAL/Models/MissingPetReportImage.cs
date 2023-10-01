using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models
{
    public class MissingPetReportImage
    {
        [Key] public Guid Id { get; set; }
        [StringLength(200)]
        public string MimeType { get; set; }
        public MissingPetReport MissingPetReport { get; set; }
        public Guid MissingPetReportId { get; set; }
    }
}
