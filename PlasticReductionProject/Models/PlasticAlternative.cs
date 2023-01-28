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
        [Name("WordDictionaryId")]
        public int Id { get; set; }

        [Name("WordText")]
        public string Word { get; set; }

        [Name("WordDefinition")]
        public string Definition { get; set; }

    }
}