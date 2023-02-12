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

        public int Increment { get; set; }

        public CalculatorResult(int _numberOfProductQuestions)
        {

            this.Id = count++;
            this.DateTime = DateTime.Now;
            Results = new Collection<ProductResult>();
            for (int i = 1; i <= _numberOfProductQuestions; i++)
            {
                var productResult = new ProductResult();
                productResult.Id = i;
                this.Results.Add(productResult);
            }
            this.Increment = 0;

            PlasticScores = new HashSet<PlasticScore>();

       

        }
        public HashSet<PlasticScore> PlasticScores { get; set; }


        public PlasticScore FindHighestPlasticScore()
        {
            double maxScore = this.PlasticScores.Max(y => y.Score);
            return this.PlasticScores.First(x => x.Score == maxScore);
        }

        public PlasticScore FindLowestPlasticScore()
        {
            double minScore = this.PlasticScores.Min(y => y.Score);
            return this.PlasticScores.First(x => x.Score == minScore);
        }


    }


    public class PlasticScore
    {
        public string Name;
        public double Score;
        public double Average;
        public PlasticType Type;
        public double Ranking
        { get { return Score / Average; } }
        public PlasticScore(string name, double score, double average, PlasticType plastic)
        {
            Name = name;
            Score = score;
            Average = average;
            Type = plastic;
        }
    }
}