using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using PlasticReductionProject.DAL;

namespace PlasticReductionProject.Models
{

    public class CalculatorResult
    {
        public static int count;
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ProductResult> Results { get; set; }

        public DateTime DateTime { get; set; }

        public int OverallRating { get; set; }

        public int increment { get; set; }

        // Chris I think if we use an array of Tuples for the Plastic scores.  For now we can use a string, but I am planning
        // to create a Plastic table seeded from plastics.csv for scoring so eventually instead of the string we could have an in
        // with PlasticId in it.  
        //

        Tuple<string, Nullable<double>>[] PlasticScores { get; set; } =
            { new Tuple<string, Nullable<double>>("PET", 0.0),
            new Tuple<string, Nullable<double>>("HDPE", 0.0),
            new Tuple<string, Nullable<double>>("PVC", 0.0),
            new Tuple<string, Nullable<double>>("LDPE", 0.0),
            new Tuple<string, Nullable<double>>("PP", 0.0),
            new Tuple<string, Nullable<double>>("PS", 0.0),
            new Tuple<string, Nullable<double>>("Other", 0.0) };

        public CalculatorResult(int _numberOfProductQuestions) {

            this.Id = count++;
            this.DateTime= DateTime.Now;
            Results = new Collection<ProductResult>();
            for (int i = 1; i <= _numberOfProductQuestions; i++)
            {
                var productResult = new ProductResult();
                productResult.Id = i;
                this.Results.Add(productResult);
            }
            this.increment = 0;

        }

        //public int PETScore { get; set; }

        //public int HDPEScore { get; set; }

        //public int PVCScore { get; set; }

        //public int LDPEScore { get; set; }

        //public int PPScore { get; set; }

        //public int PSScore { get; set; }

        //public int OtherScore { get; set; }


    }
}