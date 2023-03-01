using Newtonsoft.Json;

namespace Challenger.Utils
{
    public class JsonCustomList<T>
    {
        public static List<T>? ListComplete(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);

            List<T>? list = JsonConvert.DeserializeObject<List<T>>(fileContent);

            return list;
        }
        
    }
}