using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using System.Text.Json;

namespace openai_api_interactor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoveryController : ControllerBase
    {

        private readonly string _apiKey;
        private readonly ChatClient _chatClient;

        // why is the argument of type IConfiguration instead of just Configuration?
        // cuz it's an interface.
        // why an interface?
        // cuz it's conducive to dependency injection.  Your tests can pass in something satisfying the interface too... like a configuration mock.
        
        // what passes the configuration argument into this class?
        // ASP.NET Core passes it in.  It looks at the method's argument types and surmises that it should pass in the configuration object that satisfies the IConfiguration interface.
        public DiscoveryController (IConfiguration configuration)
        {
            // in c#, using "this" is optional
            // it becomes useful disambiguation when there's a parameter or local variable name that matches the field name
            // standard practice is to omit "this" unless necessary

            // what is this syntax on configuration?  is configuration just an object, with API_KEY as a key?
            // yes, configuration is a collection of config settings
            _apiKey = configuration["API_KEY"] ?? throw new ArgumentNullException(nameof(_apiKey), "API Key not found in configuration.");

            _chatClient = new ChatClient(model: "gpt-4o-mini", _apiKey);
        }

        // this is a c# attribute
        // config can be passed through a funny looking parens syntax
        // it does not get invoked as a function, though.
        [HttpPost]
        // TODO return IActionResult and an Ok() 

        // I will need to change this to a Post handler.  Post requests are for params with complex data.
        // my tasteProfile data is too substantial to pass thru URL string.

        // the framework automagically parses the JSON to instantiate the TastePRofile instance for you.
        async public Task<object> Post([FromBody] TasteProfile tasteProfile)
        {
            Console.WriteLine(1);
            // if you just print the instance, it will call toString() on it, which for some reason, outputs the type:  namespace.TasteProfile
            // looks good - I have my game.
            // Console.WriteLine(JsonSerializer.Serialize(tasteProfile));
            // Console.WriteLine(2);

            // multiline string

            /*string mediaType = "game";*/
            string mediaType = "book";

            string prompt = $"""
                You are a media recommendations engine.  Recommend some {mediaType}s based on things the user likes.

                Your response should include nothing except for 10 {mediaType} titles.  separate the titles with the pipe separator character "|".

                Here are video games they like:
                """;

            foreach (string game in tasteProfile.Games) 
            {
                prompt += $"\n{game}";
            }

            Console.WriteLine(prompt);


            //ChatCompletion completion = await _chatClient.CompleteChatAsync("You are a tsundere assistant.  Tell me some fun facts about Irish culture.");

            ChatCompletion completion = await _chatClient.CompleteChatAsync(prompt);

            // later:  look into structured outputs

            string content = completion.ToString();

            var testObj = new { test = "test", content };
            return testObj;
        }
    }
}
