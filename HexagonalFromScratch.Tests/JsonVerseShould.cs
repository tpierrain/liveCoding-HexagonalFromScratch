using HexagonalFromScratch.Infra;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HexagonalFromScratch.Tests
{
    [TestFixture]
    public class JsonVerseShould
    {
        [Test]
        public void Be_serialized_as_expected()
        {
            var jsonVerses = new JsonVerses("I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)");

            var json = JsonConvert.SerializeObject(jsonVerses, Formatting.Indented);

            TestContext.WriteLine($"'{json}'");
        }
    }
}