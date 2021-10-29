using System;
using System.Collections.Generic;

#nullable disable

namespace DataPrep.Database
{
    public partial class MoviesHybrid
    {
        public string MovieId { get; set; }
        public string PlotSummary { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Genre { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string PlotSynopsis { get; set; }
        public string Reviews { get; set; }
    }
}
