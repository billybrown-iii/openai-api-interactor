using openai_api_interactor.Enums;
using System.ComponentModel.DataAnnotations;

namespace openai_api_interactor.DTOs
{
    public class DiscoveryRequest(TasteProfile tasteProfile, MediaType selectedMediaType)
    {
        [Required]
        public TasteProfile TasteProfile { get; init; } = tasteProfile;

        [Required]
        public MediaType SelectedMediaType { get; init; } = selectedMediaType;
    }
}
