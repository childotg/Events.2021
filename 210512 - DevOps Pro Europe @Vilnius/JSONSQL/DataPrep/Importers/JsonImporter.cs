using DataPrep.Database;
using DataPrep.Models;
using DataPrep.Utils;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using TimeSpanParserUtil;

namespace DataPrep.Importers
{
    internal class JsonImporter
    {
        public JsonImporter()
        {
        }

        internal JsonImporter Hybrid()
        {
            var movies = new BigJsonParser<JsonMovie>().Parse(Strings.MoviesJsonPath).ToArray();
            var reviews = new BigJsonParser<JsonReview>().Parse(Strings.ReviewsJsonPath)
                .GroupBy(p => p.movie_id)
                .ToDictionary(p => p.Key, p => p.ToArray());

            using (var ctx=new DemoContext(Strings.DBConnection))
            {
                foreach (var movie in movies)
                {
                    var hybridMovie = new MoviesHybrid()
                    {
                        Duration = TimeSpanParser.Parse(movie.duration),
                        Genre = JsonConvert.SerializeObject(movie.genre),
                        MovieId = movie.movie_id,
                        PlotSummary = movie.plot_summary,
                        PlotSynopsis = movie.plot_synopsis,
                        Rating = decimal.Parse(movie.rating),
                        ReleaseDate = movie.release_date.ToDateTime("yyyy-MM-dd")
                    };
                    if (reviews.ContainsKey(movie.movie_id))
                    {
                        hybridMovie.Reviews = JsonConvert.SerializeObject(reviews[movie.movie_id]);
                    }
                    Console.WriteLine($"Saving hybrid movie {movie.movie_id} with its reviews...");
                    ctx.MoviesHybrids.Add(hybridMovie);
                    ctx.SaveChanges();
                }
                
            }
            
            return this;
        }

        internal JsonImporter Full()
        {
            var movies = new BigJsonParser<JsonMovie>().Parse(Strings.MoviesJsonPath)                
                .ToArray();
            var reviews = new BigJsonParser<JsonReview>().Parse(Strings.ReviewsJsonPath)
                .GroupBy(p => p.movie_id)
                .ToDictionary(p => p.Key, p => p.ToArray());

            using (var ctx = new DemoContext(Strings.DBConnection))
            {
                foreach (var movie in movies)
                {
                    var fullMovie = new MoviesFullJson()
                    {
                        MovieId = movie.movie_id,
                        Movie = JsonConvert.SerializeObject(movie)
                    };
                    if (reviews.ContainsKey(movie.movie_id))
                    {
                        fullMovie.Reviews = JsonConvert.SerializeObject(reviews[movie.movie_id]);
                    }
                    Console.WriteLine($"Saving full json movie {movie.movie_id} with its reviews...");
                    ctx.MoviesFullJsons.Add(fullMovie);
                    ctx.SaveChanges();
                }

            }

            return this;
        }


    }
}