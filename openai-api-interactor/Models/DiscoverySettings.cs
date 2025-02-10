using Microsoft.AspNetCore.Mvc.Formatters;

namespace openai_api_interactor.Models
{
    public class DiscoverySettings
    {
        //public List<string> Books { get; set; } = [];

        public MediaType SelectedMediaType { get; set; }
        public string Genre { get; set; }
        public string Qualities { get; set; }
    }
}
