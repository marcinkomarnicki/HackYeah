using System.ComponentModel.DataAnnotations;

namespace HackYeah.DAL.Models
{
    public class Demo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Value { get; set; }
    }
}
