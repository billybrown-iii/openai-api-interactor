namespace openai_api_interactor.Services
{
    public class PromptBuilder
    {
        public string FromTasteProfile (TasteProfile tasteProfile, string selectedMediaType)
        {

            // Consider using this type of prompt:
            // Your response should be a JSON collection.  It should be an array of 5 recommendations.  Each recommendation has a title property and a synopsis property.

            string prompt = $"""
                You are a media recommendations engine.  Recommend 5 {selectedMediaType}s based on things the user likes.

                Your response should have nothing except for 5 show titles.  Separate the titles with the pipe separator character "|".

                Here are video games they like:
            """;

            foreach (string game in tasteProfile.Games)
            {
                prompt += $"\n{game}";
            }

            Console.WriteLine(prompt);

            return prompt;
        }
    }
}
