using HexagonalFromScratch.Domain;
using Newtonsoft.Json;

namespace HexagonalFromScratch.Infra
{
    public class RequestVersesJsonAdapter
    {
        private readonly IRequestVerses _poetryReader;

        public RequestVersesJsonAdapter(IRequestVerses poetryReader)
        {
            _poetryReader = poetryReader;
        }

        public string AskPoetry()
        {
            // Adapt from infra to domain

            // Call business logic
            var rawVerses = _poetryReader.GiveMeSomePoetry();
            
            // Adapt from domain to infra
            var jsonVerses = new JsonVerses(rawVerses);
            var json = JsonConvert.SerializeObject(jsonVerses, Formatting.Indented);
            return json;
        }
    }
}