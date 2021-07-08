using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPrep.Utils
{
    public class BigJsonParser<T>
    {
        public IEnumerable<T> Parse(string path)
        {
            using (StreamReader streamReader = new StreamReader(File.OpenRead(path)))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.SupportMultipleContent = true;

                var serializer = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        var item = serializer.Deserialize<T>(reader);
                        yield return item;
                    }
                }

            }
        }
    }
}
