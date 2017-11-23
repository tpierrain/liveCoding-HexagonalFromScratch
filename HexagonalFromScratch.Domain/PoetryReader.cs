namespace HexagonalFromScratch.Domain
{
    public class PoetryReader : IRequestVerses
    {
        private readonly IObtainPoems _poetryLibrary;

        public PoetryReader() : this(new HArdCodedPoetryLibrary())
        {
        }

        public PoetryReader(IObtainPoems poetryLibrary)
        {
            _poetryLibrary = poetryLibrary;
        }

        public string GiveMeSomePoetry()
        {
            return _poetryLibrary.GetAPoem();
        }

        // TODO: refactor to avoid an adapter from being part of the domain
        private class HArdCodedPoetryLibrary : IObtainPoems
        {
            public string GetAPoem()
            {
                return "Comme je descendais des Fleuves impassibles,\r\nJe ne me sentis plus guidé par les haleurs :\r\nDes Peaux-Rouges criards les avaient pris pour cibles,\r\nLes ayant cloués nus aux poteaux de couleurs.";
            }
        }
    }
}