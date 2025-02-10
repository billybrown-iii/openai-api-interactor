using openai_api_interactor.Enums;
using openai_api_interactor.Models;
using System.ComponentModel.DataAnnotations;

namespace openai_api_interactor.DTOs
{
    public class DiscoveryRequest(IDiscoverySettings tasteProfile, MediaType selectedMediaType)
    {
        [Required]
        public IDiscoverySettings TasteProfile { get; init; } = tasteProfile;

        [Required]
        public MediaType SelectedMediaType { get; init; } = selectedMediaType;
        [Required]
        public 
    }
}
