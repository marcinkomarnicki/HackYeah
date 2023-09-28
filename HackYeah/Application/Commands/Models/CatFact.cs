using System.Text.Json.Serialization;

namespace HackYeah.Application.Commands.Models
{
    public class CatFact
    {
        [JsonPropertyName("fact")]
        public string Text { get; set; }
    }
}
