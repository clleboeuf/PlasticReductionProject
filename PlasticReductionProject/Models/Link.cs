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
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

    }
}