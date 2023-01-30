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

        // Chris I think if we use an array of Tuples for the Plastic scores.  For now we can use a string, but I am planning
        // to create a Plastic table seeded from plastics.csv for scoring so eventually instead of the string we could have an in
        // with PlasticId in it.  
        //
        //  You can create a PlasticScores array as follows:
        //
        //    PlasticScores =
        //           { new Tuple<string, Nullable<double>>("PET", 0.0),
        //    new Tuple<string, Nullable<double>>("PET", 0.0),
        //    new Tuple<string, Nullable<double>>("HDPE", 0.0),
        //    new Tuple<string, Nullable<double>>("PVC", 0.0),
        //    new Tuple<string, Nullable<double>>("LDPE", 0.0),
        //    new Tuple<string, Nullable<double>>("PP", 0.0),
        //    new Tuple<string, Nullable<double>>("PS", 0.0),
        //    new Tuple<string, Nullable<double>>("Other", 0.0) }
        //


        Tuple<string, Nullable<double>>[] PlasticScores { get; set; } =
            { new Tuple<string, Nullable<double>>("PET", 0.0),
            new Tuple<string, Nullable<double>>("PET", 0.0),
            new Tuple<string, Nullable<double>>("HDPE", 0.0),
            new Tuple<string, Nullable<double>>("PVC", 0.0),
            new Tuple<string, Nullable<double>>("LDPE", 0.0),
            new Tuple<string, Nullable<double>>("PP", 0.0),
            new Tuple<string, Nullable<double>>("PS", 0.0),
            new Tuple<string, Nullable<double>>("Other", 0.0) };

        public CalculatorResult() { }



        //public int PETScore { get; set; }

        //public int HDPEScore { get; set; }

        //public int PVCScore { get; set; }

        //public int LDPEScore { get; set; }

        //public int PPScore { get; set; }

        //public int PSScore { get; set; }

        //public int OtherScore { get; set; }


    }
}