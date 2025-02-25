using openai_api_interactor.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace openai_api_interactor.Services
{
    public class PromptBuilder
    {
            public string FromDiscoverySettings (DiscoverySettings settings)
            {
                string prompt = $"Hey, I'm looking for some {settings.MediaType} recommendations.\n\n";

                if (!string.IsNullOrWhiteSpace(settings.Genre))
                {
                    prompt += $"Genre: {settings.Genre}\n\n";
                }

                if (!string.IsNullOrWhiteSpace(settings.Qualities))
                {
                    prompt += $"Here are keywords and/or characteristics I'm looking for in my recommendations:\n\n{settings.Qualities}\n\n";
                }

                prompt += $"Please give me four recommendations with title and synopsis.\n\n";
                prompt += "Your synopsis should include a concise and straightforward summary of the plot elements.  It should NOT include any language that sounds like advertising.\n\n";
                prompt += "Your reply should consist solely of a JSON collection of four objects, each with a title property and a synopsis property.  Please do not include any text outside of the JSON.";

                return prompt;
            }
            
//        public string FromTasteProfile (DiscoverySettings tasteProfile, string selectedMediaType)
//        {

//            // Consider using this type of prompt:
//            // Your response should be a JSON collection.  It should be an array of 5 recommendations.  Each recommendation has a title property and a synopsis property.

//            // consider breaking it into a system prompt and a user prompt.
//            // e.g., as the user:  "Please exclude these titles from your recommendations:"

//            string prompt = $"You are a media recommendations engine. Recommend 5 {selectedMediaType}s based on the user's tastes.\n\n";
//            prompt += """
//Your response should be a JSON array. It should be an array of exactly 5 recommendations. Each item should have 2 properties:
//- A "title" property.
//- A "plotSynopsis" property, which describes plot elements.

//Below is a shortened example (with only 1 item) that shows the structure you must follow.
//However, your *actual* output should always have 5 items.

//[
//  {
//    "title": "Example Title 1",
//    "plotSynopsis": "Brief synopsis.",
//  },
//]

//""";

//            prompt += $"\n\nPlease ONLY return raw JSON.  Please ONLY include {selectedMediaType}s, and no other media types.\n\n";

//            if (tasteProfile.Books.Count > 0)
//            {
//                prompt += "Here is a list of books the user likes:";

//                foreach (string book in tasteProfile.Books)
//                {
//                    prompt += $"\n- {book}";
//                }

//                prompt += "\n\n";

//            }

//            if (tasteProfile.Films.Count > 0)
//            {
//                prompt += "Here is a list of films the user likes:";

//                foreach (string film in tasteProfile.Films)
//                {
//                    prompt += $"\n- {film}";
//                }

//                prompt += "\n\n";
//            }

//            if (tasteProfile.Shows.Count > 0)
//            {
//                prompt += "Here is a list of shows the user likes:";

//                foreach (string show in tasteProfile.Shows)
//                {
//                    prompt += $"\n- {show}";
//                }

//                prompt += "\n\n";
//            }

//            if (tasteProfile.Games.Count > 0)
//            {
//                prompt += "Here is a list of games the user likes:";

//                foreach (string game in tasteProfile.Games)
//                {
//                    prompt += $"\n- {game}";
//                }

//                prompt += "\n\n";
//            }

//            Console.WriteLine(prompt);

//            return prompt;
        //}
    }
}
