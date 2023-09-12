using System.ComponentModel.DataAnnotations;

namespace HackYeah.Infrastructure.Configurations
{
    public class JWTSection
    {
        public const string SectionName = "JWT";

        [Required]
        public required string Secret { get; init; }

        [Required]
        public int ExpirationTimeInMinutes { get; init; }
    }
}
