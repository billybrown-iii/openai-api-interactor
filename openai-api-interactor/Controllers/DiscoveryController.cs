using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;

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

            _chatClient = new(model: "gpt-4o-mini", _apiKey);
        }

        // this is a c# attribute
        // config can be passed through a funny looking parens syntax
        // it does not get invoked as a function, though.
        [HttpGet]
        // TODO return IActionResult and an Ok() 
        async public Task<object> Get()
        {
            ChatCompletion completion = await _chatClient.CompleteChatAsync("You are a tsundere assistant.  Tell me some fun facts about the history of Japan, from post-war period to the modern era.");

            string content = completion.Content.First().ToString();

            var testObj = new { test = "test", content };
            return testObj;
        }
    }
}
