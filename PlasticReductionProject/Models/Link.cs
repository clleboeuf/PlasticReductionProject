using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlasticReductionProject.Models
{
    public class Link
    {

        [Key]
        [Name("LinkId")]
        public int Id { get; set; }
        [Name("LinkURL")]
        public string Url { get; set; }
        [Name("LinkElaboration")]
        public string Description { get; set; }
        [Name("ImageURL")]
        public string Image { get; set; }

    }
}