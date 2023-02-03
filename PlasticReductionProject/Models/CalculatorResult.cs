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

        public CalculatorResult(int _numberOfProductQuestions) {

            this.Id = count++;
            this.DateTime = DateTime.Now;
            Results = new Collection<ProductResult>();
            for (int i = 1; i <= _numberOfProductQuestions; i++)
            {
                var productResult = new ProductResult();
                productResult.Id = i;
                this.Results.Add(productResult);
            }
            this.increment = 0;

            PlasticScores = new HashSet<PlasticScore>();

            PETScore = 0;
            HDPEScore = 0;
            PVCScore = 0;
            LDPEScore = 0;
            PPScore = 0;
            PPAScore = 0;
            PSScore = 0;
            OtherScore = 0;

            PETAvg = 0;
            HDPEAvg = 0;
            PVCAvg = 0;
            LDPEAvg = 0;
            PPAvg = 0;
            PPAAvg = 0;
            PSAvg = 0;
            OtherAvg = 0;

        }
        public HashSet<PlasticScore> PlasticScores { get; set; } 

        public double PETScore { get; set; }

        public double HDPEScore { get; set; }

        public double PVCScore { get; set; }

        public double LDPEScore { get; set; }

        public double PPScore { get; set; }

        public double PPAScore { get; set; }

        public double PSScore { get; set; }

        public double OtherScore { get; set; }

        public double PETAvg { get; set; }

        public double HDPEAvg { get; set; }

        public double PVCAvg { get; set; }

        public double LDPEAvg { get; set; }

        public double PPAvg { get; set; }

        public double PPAAvg { get; set; }

        public double PSAvg { get; set; }

        public double OtherAvg { get; set; }


    }

    public class PlasticScore
    {
        public string Name;
        public double Score;
        public double Average;

        public PlasticScore(string name, double score, double average)
        {
            Name = name;
            Score = score;
            Average = average;
        }
    }
}