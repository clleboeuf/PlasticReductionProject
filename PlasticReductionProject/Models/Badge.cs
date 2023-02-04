using CsvHelper.Configuration.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace PlasticReductionProject.Models
{
    public class Badge
    {
        [Key]
        [Name("Id")]
        public int Id { get; set; }

        [Name("Comment")]
        public string Comment { get; set; }

        [Name("Badge")]
        public string BadgeUrl { get; set; }
    }
}