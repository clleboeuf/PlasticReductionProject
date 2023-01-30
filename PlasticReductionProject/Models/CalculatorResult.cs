using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlasticReductionProject.Models
{
    public class CalculatorResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductResults> Results { get; set; }

        public int OverallRating { get; set; }

        public int PETScore { get; set; }

        public int HDPEScore { get; set; }

        public int PVCScore { get; set; }

        public int LDPEScore { get; set; }

        public int PPScore { get; set; }

        public int PSScore { get; set; }

        public int OtherScore { get; set; }


    }
}