using openai_api_interactor.Enums;
using System.ComponentModel.DataAnnotations;

namespace openai_api_interactor.DTOs
{
    public class DiscoveryRequest(TasteProfile tasteProfile, MediaType mediaType)
    {
        // JSON serializer should handle converting the pascalCase JS for you.
        [Required]
        public TasteProfile TasteProfile { get; init; } = tasteProfile;

        [Required]
        public MediaType MediaType { get; init; } = mediaType;
    }
}
