using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;


namespace PlasticReductionProject.Models
{
    public class PlasticFact
    {
        [Key]
        [Name("Id")]
        public int Id { get; set; }

        [Name("FactText")]
        public string Text { get; set; }

        [Name("FontSizeRatio")]
        public double FontSize { get; set; }

    }
}