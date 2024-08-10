using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace openai_api_interactor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoveryController : ControllerBase
    {

        private readonly string _apiKey;

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
        }

        // this is a c# attribute
        // config can be passed through a funny looking parens syntax
        // it does not get invoked as a function, though.
        [HttpGet]

        // object is a type that all types inherit from.
        // it's analogous to any.
        public object Get()
        {
            var testObj = new { test = "test", apiKey = _apiKey };
            return testObj;
        }
    }
}
