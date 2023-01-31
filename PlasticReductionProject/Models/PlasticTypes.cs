using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlasticReductionProject.Models
{
    public class PlasticTypes
    {
        [Key]
        [Name("Plastic_Id")]
        public int Id { get; set; }

        [Name("PlasticType")]
        public string Type { get; set; }

        [Name("Acronym")]
        public string Acronym { get; set; }

        [Name("CommonProducts")]
        public string CommonProducts { get; set; }

        [Name("Recyclability")]
        public decimal Recyclability { get; set; }

        [Name("WorldAverage")]
        public decimal WorldAverage { get; set; }

        [Name("RecyclingCode")]
        public int RecyclingCode { get; set; }

        [Name("IconImage")]
        public string Image { get; set; }

        [Name("AnnualTarget")]
        public int AnnualTarget { get; set; }
    }
}