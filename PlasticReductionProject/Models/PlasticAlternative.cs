using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace PlasticReductionProject.Models
{
    public class PlasticAlternative
    {
        [Key]
        [Name("Alternative_Id")]
        public int Id { get; set; }

        [Name("AlternativeDescription")]
        public string Description { get; set; }


        [Name("ForProductId")]
        public int ProductId { get; set; }

        [Name("Image")]
        public string Image { get; set; }



    }
}