using DataPrep.Database;
using DataPrep.Models;
using DataPrep.Utils;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace DataPrep.Importers
{
    internal class PlaygroundImporter
    {
        public PlaygroundImporter()
        {
        }

        internal PlaygroundImporter Go()
        {
            using (var ctx = new DemoContext(Strings.DBConnection))
            {
                var movies = new KeyValue()
                {
                    Doc = JsonConvert.SerializeObject(
                        new BigJsonParser<JsonMovie>().Parse(Strings.MoviesJsonPath).ToArray())
                };
                var reviews = new KeyValue()
                {
                    Doc = JsonConvert.SerializeObject(
                        new BigJsonParser<JsonReview>().Parse(Strings.ReviewsJsonPath).ToArray())
                };
                ctx.KeyValues.Add(movies);
                ctx.KeyValues.Add(reviews);
                ctx.SaveChanges();
            }

            return this;
        }
    }
}