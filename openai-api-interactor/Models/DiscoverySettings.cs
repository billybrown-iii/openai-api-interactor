using Microsoft.AspNetCore.Mvc.Formatters;

namespace openai_api_interactor.Models
{
    public class DiscoverySettings (string mediaType, string genre, string qualities)
    {
        public string MediaType { get; init; } = mediaType;
        public string? Genre { get; init; } = genre;
        public string? Qualities { get; init; } = qualities;
    }
}
