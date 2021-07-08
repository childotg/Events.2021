using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPrep.Models
{
    public class JsonMovie
    {
        public string movie_id { get; set; }
        public string plot_summary { get; set; }
        public string duration { get; set; }
        public string[] genre { get; set; }
        public string rating { get; set; }
        public string release_date { get; set; }
        public string plot_synopsis { get; set; }
    }
}
