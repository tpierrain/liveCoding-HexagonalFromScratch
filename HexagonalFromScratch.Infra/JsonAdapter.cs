using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HexagonalFromScratch.Infra
{
    public class JsonAdapter
    {
        public string Ask()
        {
            return JsonConvert.SerializeObject(new object(), Formatting.Indented);
        }
    }

    public class PoemFileAdapter : IObtainPoems
    {
        private readonly string poem;

        public PoemFileAdapter(string filePath)
        {
            this.poem = File.ReadAllText(filePath);
        }

        public string GetAPoem()
        {
            return this.poem;
        }
    }

    public interface IObtainPoems
    {
        string GetAPoem();
    }
}
