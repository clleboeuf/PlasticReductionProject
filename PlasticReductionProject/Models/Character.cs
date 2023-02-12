using CsvHelper.Configuration.Attributes;

using System.ComponentModel.DataAnnotations;


namespace PlasticReductionProject.Models
{
    public class Character
    {
        [Key]
        [Name("Id")]
        public int Id { get; set; }

        [Name("GifURL")]
        public string URL { get; set; }

        [Name("StyleString")]
        public string Style { get; set; }

        [Name("Name")]
        public string Name { get; set; }

    }
}