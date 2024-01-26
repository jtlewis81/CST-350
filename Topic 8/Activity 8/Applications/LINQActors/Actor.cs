using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQActors
{
    class Actor
    {
        public string Name { get; set; }
        public decimal TotalGross { get; set; }
        public int MovieCount { get; set; }
        public decimal AvgPerMovie { get; set; }
        public string TopMovie { get; set; }
        public decimal TopMovieGross { get; set; }

        public override string ToString()
        {
            return "Name: " + Name +
                (TotalGross != 0 ? " TotalGross: " + TotalGross : null) +
                (MovieCount != 0 ? " MovieCount: " + MovieCount : null) +
                (AvgPerMovie != 0 ? " AvgPerMovie: " + AvgPerMovie : null) +
                (TopMovie != null ? " TopMovie: " + TopMovie : null) +
                (TopMovieGross != 0 ? " TopMovieGross: " + TopMovieGross : null) +
                "\n";
        }
    }
}
