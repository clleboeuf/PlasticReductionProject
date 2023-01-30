
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace PlasticReductionProject.Models
{
    public class Product
    {

        [Key]
        [Name("ProductId")]
        public int Id { get; set; }

        [Name("ProductDescription")]
        public string Description { get; set; }

        [Name("ProductUseVerb")]
        public string UseVerb { get; set; }

        [Name("ProductCategory")]
        public string Category { get; set; }

        [Name("PlasticType")]
        public int Type { get; set; }

        [Name("Recyclable")]
        public bool IsRecyclable { get; set; }

        [Name("RecyclingType")]
        public string RecyclingFor { get; set; }

        [Name("QuestionSet")]
        public string Questions { get; set; }

        [Name("Mass")]
        public double Weight { get; set; }

        [Name("Image")]
        public string Image { get; set; }

    }
}