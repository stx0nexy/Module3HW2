using System.IO;
using Newtonsoft.Json;

namespace Module3HW2
{
    public class AlphabetService : IAlphabetService
    {
        public AlphabetConfig ReadAlphabet(string jsonFilePath = @"C:\Users\Соня\source\repos\Module3HW2\Module3HW2\Configs\config.json")
        {
            return JsonConvert.DeserializeObject<AlphabetConfig>(File.ReadAllText(jsonFilePath));
        }
    }
}
