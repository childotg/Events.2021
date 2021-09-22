using DataPrep.Database;
using DataPrep.Models;
using DataPrep.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TimeSpanParserUtil;

namespace DataPrep.Importers
{
    internal class RelationalImporter
    {
        public RelationalImporter()
        {
        }

        internal RelationalImporter Reviews()
        {
            var reviewsParser = new BigJsonParser<JsonReview>();
            var reviews = new List<Review>();
            var collection = reviewsParser.Parse(Strings.ReviewsJsonPath);
            foreach (var review in collection)
            {
                var mapped = new Review()
                {
                    IsSpoiler=review.is_spoiler,
                    MovieId=review.movie_id,
                    Rating=decimal.Parse(review.rating),
                    ReviewDate=review.review_date.ToDateTime("dd MMMM yyyy"),
                    ReviewSummary=review.review_summary,
                    ReviewText=review.review_text,
                    UserId=review.user_id
                };
                reviews.Add(mapped);                
            }
            using (var ctx = new DemoContext(Strings.DBConnection))
            {
                ctx.Reviews.AddRange(reviews);
                ctx.SaveChanges();
            }

            return this;
        }

        internal RelationalImporter Movies()
        {
            var moviesParser = new BigJsonParser<JsonMovie>();
            var movies = new List<Movie>();
            foreach (var movie in moviesParser.Parse(Strings.MoviesJsonPath))
            {
                var mapped = new Movie()
                {
                    Duration = TimeSpanParser.Parse(movie.duration),
                    Genre = JsonConvert.SerializeObject(movie.genre),
                    MovieId = movie.movie_id,
                    PlotSummary = movie.plot_summary,
                    PlotSynopsis = movie.plot_synopsis,
                    Rating = decimal.Parse(movie.rating),
                    ReleaseDate = movie.release_date.ToDateTime("yyyy-MM-dd")
                };
                movies.Add(mapped);
            }
            
            using (var ctx=new DemoContext(Strings.DBConnection))
            {
                ctx.Movies.AddRange(movies);
                ctx.SaveChanges();
            }

            return this;
        }
    }
}