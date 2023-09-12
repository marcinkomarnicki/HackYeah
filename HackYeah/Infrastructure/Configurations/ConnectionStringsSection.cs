using System.ComponentModel.DataAnnotations;

namespace HackYeah.Infrastructure.Configurations
{
    public class ConnectionStringsSection
    {
        public const string SectionName = "ConnectionStrings";

        [Required]
        public required string HackYeah { get; init; }
    }
}
