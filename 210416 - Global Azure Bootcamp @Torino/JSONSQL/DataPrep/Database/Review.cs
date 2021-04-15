using System;
using System.Collections.Generic;

#nullable disable

namespace DataPrep.Database
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public string MovieId { get; set; }
        public string UserId { get; set; }
        public bool? IsSpoiler { get; set; }
        public string ReviewText { get; set; }
        public decimal? Rating { get; set; }
        public string ReviewSummary { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
