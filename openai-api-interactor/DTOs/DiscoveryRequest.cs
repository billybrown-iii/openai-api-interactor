using openai_api_interactor.Enums;
using openai_api_interactor.Models;
using System.ComponentModel.DataAnnotations;

namespace openai_api_interactor.DTOs
{
    public class DiscoveryRequest(DiscoverySettings discoverySettings)
    {
        [Required]
        public DiscoverySettings DiscoverySettings { get; init; } = discoverySettings;
    }
}
