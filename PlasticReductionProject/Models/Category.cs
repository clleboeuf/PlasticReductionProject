using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace PlasticReductionProject.Models
{
    internal class Category
    {
        [Key]
        [Name("Id")]
        public int Id { get; set; }

        [Name("Name")]
        public string Name { get; set; }

        public virtual ICollection<Product> ProductsInCategory { get;}
    }
}