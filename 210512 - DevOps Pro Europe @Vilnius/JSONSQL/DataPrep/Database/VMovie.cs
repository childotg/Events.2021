using System;
using System.Collections.Generic;

#nullable disable

namespace DataPrep.Database
{
    public partial class VMovie
    {
        public string MovieId { get; set; }
        public string PlotSummary { get; set; }
        public TimeSpan? DurationRaw { get; set; }
        public string Genre { get; set; }
        public decimal? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string PlotSynopsis { get; set; }
    }
}
