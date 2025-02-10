using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using openai_api_interactor.DTOs;
using openai_api_interactor.Models;
using openai_api_interactor.Services;
using System.Text.Json;

namespace openai_api_interactor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscoveryController : ControllerBase
    {

        private PromptBuilder _promptBuilder;

        private readonly string _apiKey;
        private readonly ChatClient _chatClient;

        public DiscoveryController (IConfiguration configuration, PromptBuilder promptBuilder)
        {
            _promptBuilder = promptBuilder;
            
            // in c#, using "this" is optional
            _apiKey = configuration["API_KEY"] ?? throw new ArgumentNullException(nameof(_apiKey), "API Key not found in configuration.");
            _chatClient = new ChatClient(model: "gpt-4o-mini", _apiKey);


        }

        [HttpPost]
        // TODO return IActionResult and an Ok() 
        async public Task<object> Post([FromBody] DiscoveryRequest discoveryRequest)
        {
            Console.WriteLine(JsonSerializer.Serialize(discoveryRequest));

            // todo validate the request
            IDiscoverySettings tasteProfile = discoveryRequest.TasteProfile;
            string selectedMediaType = discoveryRequest.SelectedMediaType.ToString().ToLower();  // ex: book

            string prompt = _promptBuilder.FromTasteProfile(tasteProfile, selectedMediaType);

            ChatMessage myMessage = new SystemChatMessage(prompt);
            ChatCompletion completion = await _chatClient.CompleteChatAsync([myMessage]);

            //ChatCompletion completion = await _chatClient.CompleteChatAsync(prompt);

            // TODO validate the chat completion's contents

            // later:  look into structured outputs
            // and maybe more advanced things on top of that, like structured inputs or context loading or continued reinforcement learning.

            string content = completion.ToString();

            Console.WriteLine(content);

            // should I return something besides an anon object?  like a class instance or something that conforms to a response interface?
            var testObj = new { content };
            return testObj;
        }
    }
}
