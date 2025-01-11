using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using openai_api_interactor.DTOs;

namespace openai_api_interactor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscoveryController : ControllerBase
    {

        private readonly string _apiKey;
        private readonly ChatClient _chatClient;

        public DiscoveryController (IConfiguration configuration)
        {
            // in c#, using "this" is optional
            _apiKey = configuration["API_KEY"] ?? throw new ArgumentNullException(nameof(_apiKey), "API Key not found in configuration.");
            _chatClient = new ChatClient(model: "gpt-4o-mini", _apiKey);
        }

        [HttpPost]
        // TODO return IActionResult and an Ok() 
        async public Task<object> Post([FromBody] DiscoveryRequest discoveryRequest)
        {
            Console.WriteLine(1);
            // if you just print the instance, it will call toString() on it, which for some reason, outputs the type:  namespace.TasteProfile
            //Console.WriteLine(JsonSerializer.Serialize(discoveryRequest));

            TasteProfile tasteProfile = discoveryRequest.TasteProfile;
            string selectedMediaType = discoveryRequest.SelectedMediaType.ToString().ToLower();  // ex: book

            string prompt = $"""
                You are a media recommendations engine.  Recommend some {selectedMediaType}s based on things the user likes.

                Your response should include nothing except for 10 {selectedMediaType} titles.  Separate the titles with the pipe separator character "|".

                Here are video games they like:
                """;

            foreach (string game in tasteProfile.Games) 
            {
                prompt += $"\n{game}";
            }

            Console.WriteLine(prompt);
            ChatCompletion completion = await _chatClient.CompleteChatAsync(prompt);

            // TODO validate the shape

            // later:  look into structured outputs
            // and maybe more advanced things on top of that, like structured inputs or context loading or continued reinforcement learning.

            string content = completion.ToString();

            // should the Discovery controller return a Discovery instance?  Should there be a Discovery model?
            // or a Recommendations model?
            // What's the real C# developer way to go here?

            // Is the controller like my application services layer?
            // so it orchestrates services like RecommendationsFactory.

            var testObj = new { test = "test", content };
            return testObj;
        }
    }
}
