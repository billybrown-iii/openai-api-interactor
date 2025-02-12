using Microsoft.AspNetCore.Mvc.Formatters;

namespace openai_api_interactor.Models
{
    // can I make these values all immutable?
    public class DiscoverySettings (string mediaType, string genre, string qualities)
    {
        public string MediaType { get; set; } = mediaType;
        public string? Genre { get; set; } = genre;
        public string? Qualities { get; set; } = qualities;
    }
}
