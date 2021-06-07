using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPrep.Models
{
    public class JsonReview
    {
        public string review_date { get; set; }
        public string movie_id { get; set; }
        public string user_id { get; set; }
        public bool is_spoiler { get; set; }
        public string review_text { get; set; }
        public string rating { get; set; }
        public string review_summary { get; set; }
    }
}
